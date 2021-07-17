using System;
using System.Runtime.InteropServices;

namespace AntiAFK
{
    public static class HotKey
    {
        //библиотеки горячих клавишей
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
        
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        
        //константы горячих клавишей и сообщения горячей клавиши
        public const int ModAlt = 0x1;
        public const int ModControl = 0x2;
        public const int ModShift = 0x4;
        public const int ModWin = 0x8;
        public const int WmHotkey = 0x312;
    }
}