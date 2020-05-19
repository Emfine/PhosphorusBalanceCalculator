using PhosphorusBalanceCalculator.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PhosphorusBalanceCalculator
{
    public static class ControlExtended
    {
        public static Result TryPraseDecimal(this TextBox txt)
        {
            var result = new Result { IsSucceeded = 1 };
            if (!string.IsNullOrWhiteSpace(txt.Text)
                && !decimal.TryParse(txt.Text, out decimal num))
            {
                result.IsSucceeded = 0;
                result.Message = $"请在【{txt.Tag}】中输入有效数字";
            }
            return result;
        }

        public static void SetResult(this TextBox txt, string result)
        {
            txt.Text = result;
            txt.BackColor = Color.Yellow;
        }
    }
}