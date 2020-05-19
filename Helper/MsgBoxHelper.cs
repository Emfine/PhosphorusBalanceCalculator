using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PhosphorusBalanceCalculator.Helper
{
    public class MsgBoxHelper
    {
        public static void Info(string text)
        {
            MessageBox.Show(text, "通知", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Error(string text)
        {
            MessageBox.Show(text, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}