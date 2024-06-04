using MineFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalcAuto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fnCalc();
        }

        public void fnCalc()
        {
            if (string.IsNullOrEmpty(tbPrice.Text))
            {
                MessageBox.Show("기준금액을 입력하세요.");
                tbPrice.Focus();
                return;
            }

            if (string.IsNullOrEmpty(tbplusrate.Text))
            {
                MessageBox.Show("매도(+)금액을 입력하세요.");
                tbplusrate.Focus();
                return;
            }

            if (string.IsNullOrEmpty(tbminusrate.Text))
            {
                MessageBox.Show("매도(-)금액을 입력하세요.");
                tbminusrate.Focus();
                return;
            }

            float f_price = float.Parse(tbPrice.Text);
            double plus_price = Math.Round(f_price * ((100 + float.Parse(tbplusrate.Text)) / 100));
            double minus_price = Math.Round(f_price * ((100 - float.Parse(tbminusrate.Text)) / 100));

            lblprice.Text = StringCls.AmountComma(f_price.ToString()) + " 원";
            lblplusprice.Text = StringCls.AmountComma(plus_price.ToString()) + " 원";
            lblminusprice.Text = StringCls.AmountComma(minus_price.ToString()) + " 원";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tbplusrate.Text = "1.0";
            tbminusrate.Text = "3.0";
        }

        private void tbPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbPrice.Text = StringCls.AmountComma(tbPrice.Text);
                fnCalc();
            }
        }
    }
}
