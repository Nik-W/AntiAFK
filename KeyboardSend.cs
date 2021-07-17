using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AntiAFK
{
    public static class KeyboardSend
    {
        [DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
        private const int KeyeventfExtendedkey = 1;
        private const int KeyeventfKeyup = 2;
        private const int KeystrokeTimeout = 500;

        private static void KeyDown(Keys vKey)
        {   //метод нажатия клавиши
            keybd_event((byte)vKey, 0, KeyeventfExtendedkey, 0);
        }

        private static void KeyUp(Keys vKey)
        {   //метод отпускания клавиши
            keybd_event((byte)vKey, 0, KeyeventfExtendedkey | KeyeventfKeyup, 0);
        }

        public static void Key(Keys vKey)
        {
            KeyDown(vKey);
            System.Threading.Thread.Sleep(KeystrokeTimeout);
            KeyUp(vKey);
        }
    }
}