using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AntiAFK
{
    /*
        todo:
        Проверка W A S D 
        Добавление Пробел
        Добавление движения мыши
        Проверка горячей клавиши
        
        Настройка метода работы (старый и новый). Учесть, что на старом метода уже функционал (или вырезать старый?)
        Добавить справку.

        Придумать ещё функционал.

        Код в классы:
            Захват клавиш в один класс
            Горячие клавиши в другой класс. (регистрация, АНрегистрация, обработка нажатия)
            Класс констант набора клавиш отдельно
         
    */

    public partial class Form1 : Form
    {
        static class KeyboardSend
        {
            [DllImport("user32.dll")]
            private static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
            private const int KEYEVENTF_EXTENDEDKEY = 1;
            private const int KEYEVENTF_KEYUP = 2;
            private const int SleepTimeout = 500;

            private static void KeyDown(Keys vKey)
            {   //метод нажатия клавиши
                keybd_event((byte)vKey, 0, KEYEVENTF_EXTENDEDKEY, 0);
            }

            private static void KeyUp(Keys vKey)
            {   //метод отпускания клавиши
                keybd_event((byte)vKey, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
            }

            public static void Key(Keys vKey)
            {
                KeyDown(vKey);
                System.Threading.Thread.Sleep(SleepTimeout);
                KeyUp(vKey);
            }
        }

        [DllImport("user32.dll")]
        private static extern int SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        //[DllImport("user32.dll")]
        //public static extern void SetCursorPos(int x, int y);
        private const int SW_RESTORE = 4; //режим отображения

        //константы клавиш - старый метод
        //private static readonly string[] ArrowKeys = { "{Down}", "{Up}", "{Left}", "{Right}" };
        //private static readonly string[] MotionKeys = { "{S}", "{W}", "{A}", "{D}" };
        //private string[] _randomKeys = ArrowKeys;
        //константы клавиш - новый метод
        private static readonly Keys[] ArrowKeys = new Keys[4] { Keys.Up, Keys.Left, Keys.Down, Keys.Right };
        private static readonly Keys[] MotionKeys = new Keys[4] { Keys.W, Keys.A, Keys.S, Keys.D };
        private Keys[] _randomKeys = ArrowKeys;

        //библиотеки горячих клавишей
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        //необходимые константы
        public const int MOD_ALT = 0x1;
        public const int MOD_CONTROL = 0x2;
        public const int MOD_SHIFT = 0x4;
        public const int MOD_WIN = 0x8;
        public const int WM_HOTKEY = 0x312;
        
        //обработчик сообщений для окна
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_HOTKEY)
            {
                //обработка горячей клавиши
                if (timer.Enabled) TimerStop();
                m.Result = (IntPtr)0;
                return;
            }
            base.WndProc(ref m);
        }

        public Form1()
        {
            InitializeComponent();
            
            //регистрация горячей клавиши
            bool res = RegisterHotKey(this.Handle, 1, MOD_ALT, (uint)Keys.S);
            if (res == false) MessageBox.Show("RegisterHotKey failed");

            GetProcessList();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //освобождение зарегистрированной клавиши
            UnregisterHotKey(this.Handle, 1);
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

        private void timerButton_Click(object sender, EventArgs e)
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
                TimerStop();
            }
        }

        //отключение таймера и установка настроек
        private void TimerStop()
        {
            timerInterval.Enabled = true;
            escCheckBox.Enabled = true;
            arrowRadioButton.Enabled = true;
            motionRadioButton.Enabled = true;
            timerButton.Image = Properties.Resources.play;
            timer.Stop();      //выключение таймера
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //старый метод SendKeys
            //if (escCheckBox.Checked)
            //    SendKeys.SendWait("{ESC}"); //эмуляция нажатия Esc
            //for (var i = 0; i < 5; i++)
            //{
            //    System.Threading.Thread.Sleep(100);
            //    SendKeys.SendWait(_randomKeys[new Random().Next(0, _randomKeys.Length)]);
            //}

            //новый метод KeyboardSend
            if (escCheckBox.Checked)
            {
                KeyboardSend.Key(Keys.Escape);
            }
            for (var i = 0; i < 5; i++)
            {
                System.Threading.Thread.Sleep(100);
                KeyboardSend.Key(_randomKeys[new Random().Next(0, _randomKeys.Length)]);
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

        private void updateButton_Click(object sender, EventArgs e)
        {
            GetProcessList();
        }
    }
}
