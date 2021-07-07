﻿using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AntiAFK
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        private static extern int SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        //[DllImport("user32.dll")]
        //public static extern void SetCursorPos(int x, int y);
        private const int SW_RESTORE = 4; //режим отображения

        private static readonly string[] ArrowKeys = { "{Down}", "{Up}", "{Left}", "{Right}" };
        private static readonly string[] MotionKeys = { "{S}", "{W}", "{A}", "{D}" };
        private string[] _randomKeys = ArrowKeys;

        private void Form1_Load(object sender, EventArgs e)
        {
            GetProcessList();
        }

        private void GetProcessList()
        {
            //очистка списка процессов в компоненте
            processComboBox.Items.Clear();
            //получение всех процессов с дескриптором окна, отсортированные по времени создания
            var processList = Process.GetProcesses()
                .Where(p => p.MainWindowHandle != IntPtr.Zero && p.ProcessName != "explorer" && p.ProcessName != "AntiAFK")
                .OrderByDescending(x => x.StartTime).ToList();
            //запись имён процессов в список
            processList.ForEach(proc => processComboBox.Items.Add(proc.ProcessName));
            processComboBox.Text = processComboBox.Items[0].ToString();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            GetProcessList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!timer.Enabled)
            {
                //установка интервала таймера
                if (int.TryParse(timerInterval.Text, out var n))
                {
                    timer.Interval = n * 1000; //установка интервала
                }
                else
                {
                    MessageBox.Show("Интервал не является целым числом!\nВведите целое число!", "Ошибка!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }

                var str = processComboBox.Text;
                //взятие процесса по названию
                var processes =
                    Process.GetProcessesByName(str); //разворачивает окно процесса без exe  //notepad  //SoTGame //csgo
                if (processes.Any()) //если есть какой либо процесс
                {
                    var handle = processes.First().MainWindowHandle; //берём его дескриптор
                    ShowWindow(handle, SW_RESTORE); //разворачиваем окно
                    SetForegroundWindow(handle); //даём окну управление
                }
                else //если процессов нет
                {
                    MessageBox.Show(
                        "Процесс с таким именем не запущен!\nЗапустите процесс или проверьте имя процесса, в нём не должно быть \".exe\"",
                        "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }

                if (arrowRadioButton.Checked) _randomKeys = ArrowKeys;
                if (motionRadioButton.Checked) _randomKeys = MotionKeys;

                timerInterval.Enabled = false;
                escCheckBox.Enabled = false;
                arrowRadioButton.Enabled = false;
                motionRadioButton.Enabled = false;

                System.Threading.Thread.Sleep(3000); //ожидание 3 сек для разворачивания окна
                timerButton.Image = Properties.Resources.stop;
                timer.Start();
            }
            else
            {
                timerInterval.Enabled = true;
                escCheckBox.Enabled = true;
                arrowRadioButton.Enabled = true;
                motionRadioButton.Enabled = true;
                timerButton.Image = Properties.Resources.play;
                timer.Stop();      //выключение таймера
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (escCheckBox.Checked)
                SendKeys.SendWait("{ESC}"); //эмуляция нажатия Esc
            for (var i = 0; i < 5; i++)
            {
                System.Threading.Thread.Sleep(100);
                SendKeys.SendWait(_randomKeys[new Random().Next(0, _randomKeys.Length)]);
            }
        }

        private void topMostButton_Click(object sender, EventArgs e)
        {
            if (TopMost)
            {
                TopMost = false;
                topMostButton.Image = Properties.Resources.attach;
            }
            else
            {
                TopMost = true;
                topMostButton.Image = Properties.Resources.unpin;
            }
        }
    }
}