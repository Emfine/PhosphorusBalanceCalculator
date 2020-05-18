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
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
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
            txtDeltP.Text = "0";
        }
    }
}
