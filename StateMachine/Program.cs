using System;
using System.Windows.Forms;

namespace StateMachine
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.Run(new Form1());
        }
    }
}