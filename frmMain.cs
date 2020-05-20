using PhosphorusBalanceCalculator.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PhosphorusBalanceCalculator
{
    public partial class frmMain : Form
    {
        private List<TextBox> availableCalcList;

        public decimal A { get { return string.IsNullOrWhiteSpace(txtA.Text) ? 0m : decimal.Parse(txtA.Text); } }
        public decimal B { get { return string.IsNullOrWhiteSpace(txtB.Text) ? 0m : decimal.Parse(txtB.Text); } }
        public decimal C { get { return string.IsNullOrWhiteSpace(txtC.Text) ? 0m : decimal.Parse(txtC.Text); } }
        public decimal D { get { return string.IsNullOrWhiteSpace(txtD.Text) ? 0m : decimal.Parse(txtD.Text); } }
        public decimal E { get { return string.IsNullOrWhiteSpace(txtE.Text) ? 0m : decimal.Parse(txtE.Text); } }
        public decimal F { get { return string.IsNullOrWhiteSpace(txtF.Text) ? 0m : decimal.Parse(txtF.Text); } }
        public decimal G { get { return string.IsNullOrWhiteSpace(txtG.Text) ? 0m : decimal.Parse(txtG.Text); } }
        public decimal H { get { return string.IsNullOrWhiteSpace(txtH.Text) ? 0m : decimal.Parse(txtH.Text); } }
        public decimal I { get { return string.IsNullOrWhiteSpace(txtI.Text) ? 0m : decimal.Parse(txtI.Text); } }
        public decimal J { get { return string.IsNullOrWhiteSpace(txtJ.Text) ? 0m : decimal.Parse(txtJ.Text); } }
        public decimal K { get { return string.IsNullOrWhiteSpace(txtK.Text) ? 0m : decimal.Parse(txtK.Text); } }
        public decimal L { get { return string.IsNullOrWhiteSpace(txtL.Text) ? 0m : decimal.Parse(txtL.Text); } }
        public decimal M { get { return string.IsNullOrWhiteSpace(txtM.Text) ? 0m : decimal.Parse(txtM.Text); } }
        public decimal N { get { return string.IsNullOrWhiteSpace(txtN.Text) ? 0m : decimal.Parse(txtN.Text); } }
        public decimal O { get { return string.IsNullOrWhiteSpace(txtO.Text) ? 0m : decimal.Parse(txtO.Text); } }
        public decimal P { get { return string.IsNullOrWhiteSpace(txtP.Text) ? 0m : decimal.Parse(txtP.Text); } }
        public decimal Q { get { return string.IsNullOrWhiteSpace(txtQ.Text) ? 0m : decimal.Parse(txtQ.Text); } }
        public decimal Pi { get { return string.IsNullOrWhiteSpace(txtPi.Text) ? 0m : decimal.Parse(txtPi.Text); } }

        public frmMain()
        {
            InitializeComponent();
            availableCalcList = new List<TextBox> { txtD, txtE, txtPi, txtC, txtJ, txtL, txtN, txtP };
        }

        private void frmMain_Load(object sender, EventArgs args)
        {
            initialCalc();
        }

        private void btnCalcTXCS_Click(object sender, EventArgs args)
        {
            calc(txtD, () =>
            {
                decimal diet = MathHelper.CalcDiet(C);
                decimal drug = MathHelper.CalcDrug(I, J, K, L, M, N, O, P);
                decimal beta = MathHelper.CalcBeta(H);
                decimal dialysis = diet * 0.7m - drug - Pi - 68m * 7m;
                decimal divider = 80.3m * F - 0.024m * A + 0.07m * B - beta * H - 8.14m - G * (E - 4m) * 0.06m * Q;
                if (0m == divider) throw new Exception($"除数不能为0{Environment.NewLine}请调整{Environment.NewLine}【{txtA.Tag}】{Environment.NewLine}【{txtB.Tag}】{Environment.NewLine}【{txtE.Tag}】{Environment.NewLine}【{txtF.Tag}】{Environment.NewLine}【{txtG.Tag}】{Environment.NewLine}【{txtH.Tag}】{Environment.NewLine}【{txtQ.Tag}】");
                decimal d = dialysis / 31m / divider;
                return d;
            });
        }

        private void btnCalcTXSJ_Click(object sender, EventArgs args)
        {
            calc(txtE, () =>
            {
                decimal diet = MathHelper.CalcDiet(C);
                decimal drug = MathHelper.CalcDrug(I, J, K, L, M, N, O, P);
                decimal beta = MathHelper.CalcBeta(H);
                decimal dialysis = diet * 0.7m - drug - Pi - 68m * 7m;
                if (0m == D) throw new Exception($"【{txtD.Tag}】不能为0");
                if (0m == G) throw new Exception($"【{txtG.Tag}】不能为0");
                if (0m == Q) throw new Exception($"【{txtQ.Tag}】不能为0");
                decimal e = (dialysis / D / 31m - 80.3m * F + 0.024m * A - 0.07m * B - beta * H + 8.14m) / G / 0.06m / Q + 4m;
                return e;
            });
        }

        private void btnCalcLZL_Click(object sender, EventArgs args)
        {
            calc(txtPi, () =>
            {
                decimal diet = MathHelper.CalcDiet(C);
                decimal dialysis = MathHelper.CalcDialysis(A, B, D, E, F, G, H, Q);
                decimal drug = MathHelper.CalcDrug(I, J, K, L, M, N, O, P);
                decimal pi = diet * 0.7m - dialysis - drug - 68m * 7m;
                return pi;
            });
        }

        private void btnCalcLSR_Click(object sender, EventArgs args)
        {
            calc(txtC, () =>
            {
                decimal dialysis = MathHelper.CalcDialysis(A, B, D, E, F, G, H, Q);
                decimal drug = MathHelper.CalcDrug(I, J, K, L, M, N, O, P);
                decimal c = (Pi + dialysis + drug + 68m * 7m) / 0.7m / 7m;
                return c;
            });
        }

        private void btnCalcTSG_Click(object sender, EventArgs args)
        {
            calc(txtJ, () =>
            {
                decimal diet = MathHelper.CalcDiet(C);
                decimal dialysis = MathHelper.CalcDialysis(A, B, D, E, F, G, H, Q);
                decimal drug = diet * 0.7m - dialysis - Pi - 68m * 7m;
                decimal csg = MathHelper.CalcCSG(K, L);
                decimal tsswlm = MathHelper.CalcTSSWLM(M, N);
                decimal tsl = MathHelper.CalcTSL(O, P);
                if (0m == I) throw new Exception($"【{txtI.Tag}】不能为0");
                decimal j = (drug - csg - tsswlm - tsl) * 500m / 23.36m / I;
                return j;
            });
        }

        private void btnCalcCSG_Click(object sender, EventArgs args)
        {
            calc(txtL, () =>
            {
                decimal diet = MathHelper.CalcDiet(C);
                decimal dialysis = MathHelper.CalcDialysis(A, B, D, E, F, G, H, Q);
                decimal drug = diet * 0.7m - dialysis - Pi - 68m * 7m;
                decimal tsg = MathHelper.CalcTSG(I, J);
                decimal tsswlm = MathHelper.CalcTSSWLM(M, N);
                decimal tsl = MathHelper.CalcTSL(O, P);
                if (0m == K) throw new Exception($"【{txtK.Tag}】不能为0");
                decimal l = (drug - tsg - tsswlm - tsl) * 667m / 29.5m / K;
                return l;
            });
        }

        private void btnCalcTSSWLM_Click(object sender, EventArgs args)
        {
            calc(txtN, () =>
            {
                decimal diet = MathHelper.CalcDiet(C);
                decimal dialysis = MathHelper.CalcDialysis(A, B, D, E, F, G, H, Q);
                decimal drug = diet * 0.7m - dialysis - Pi - 68m * 7m;
                decimal tsg = MathHelper.CalcTSG(I, J);
                decimal csg = MathHelper.CalcCSG(K, L);
                decimal tsl = MathHelper.CalcTSL(O, P);
                if (0m == M) throw new Exception($"【{txtM.Tag}】不能为0");
                decimal n = (drug - tsg - csg - tsl) * 800m / 21m / M;
                return n;
            });
        }

        private void btnCalcTSL_Click(object sender, EventArgs args)
        {
            calc(txtP, () =>
            {
                decimal diet = MathHelper.CalcDiet(C);
                decimal dialysis = MathHelper.CalcDialysis(A, B, D, E, F, G, H, Q);
                decimal drug = diet * 0.7m - dialysis - Pi - 68m * 7m;
                decimal tsg = MathHelper.CalcTSG(I, J);
                decimal csg = MathHelper.CalcCSG(K, L);
                decimal tsswlm = MathHelper.CalcTSSWLM(M, N);
                if (0m == O) throw new Exception($"【{txtO.Tag}】不能为0");
                decimal p = (drug - tsg - csg - tsswlm) * 500m / 67.5m / O;
                return p;
            });
        }

        private void btnClear_Click(object sender, EventArgs args)
        {
            initialCalc();
        }

        private void initialCalc()
        {
            txtA.Text = "0";
            txtB.Text = "0";
            txtC.Text = "0";
            txtD.Text = "0";
            txtE.Text = "0";
            txtF.Text = "0";
            txtG.Text = "0";
            txtH.Text = "0";
            txtQ.Text = "0";
            txtI.Text = "0";
            txtJ.Text = "0";
            txtK.Text = "0";
            txtL.Text = "0";
            txtM.Text = "0";
            txtN.Text = "0";
            txtO.Text = "0";
            txtP.Text = "0";
            txtPi.Text = "0";
            initalColor();
        }

        private void initalColor()
        {
            availableCalcList.ForEach(x => x.BackColor = Color.White);
        }

        private bool checkInput(Control parent, TextBox except)
        {
            foreach (Control child in parent.Controls)
            {
                if (child.Controls.Count > 0)
                {
                    return checkInput(child, except);
                }
                else
                {
                    if (child is TextBox)
                    {
                        var txt = child as TextBox;
                        if (txt != except)
                        {
                            var result = txt.TryPraseDecimal();
                            if (0 == result.IsSucceeded)
                            {
                                MsgBoxHelper.Error(result.Message);
                                txt.SelectAll();
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        private void calc(TextBox target, Func<decimal> calcAction)
        {
            try
            {
                if (!checkInput(this, target)) return;
                if (0m != G && 4m >= E)
                {
                    MsgBoxHelper.Error($"【{txtE.Tag}】大于4小时才需要填写【{txtG.Tag}】");
                    return;
                }
                decimal result = calcAction();
                initalColor();
                target.SetResult(result.ToString());
            }
            catch (Exception ex)
            {
                MsgBoxHelper.Error(ex.Message);
            }
        }
    }
}