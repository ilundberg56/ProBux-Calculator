using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace ProBux_Earnings_Calculator_3
{
    public partial class Form1 : Telerik.WinControls.UI.RadForm
    {
        public double accType = 0.005;
        public double accType2 = 0.04;
        public int nbrReferrals = 0;
        public int nbrClicks = 1;
        bool result = false;

        public Form1()
        {
            InitializeComponent();

            ThemeResolutionService.ApplicationThemeName = themeDark.ThemeName;

            cmbAccType.SelectedIndex = 0;
            cmbClicks.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            totalProfit(Equation(accType, nbrReferrals, nbrClicks, accType2));
        }

        private void cmbAccType_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            switch (cmbAccType.SelectedIndex)
            {
                case 0:
                    {
                        accType = .005;
                        accType2 = .04;
                        totalProfit(Equation(accType, nbrReferrals, nbrClicks, accType2));
                        break;
                    }
                case 1:
                    {
                        accType = .01;
                        accType2 = .08;
                        totalProfit(Equation(accType, nbrReferrals, nbrClicks, accType2));
                        break;
                    }
                case 2:
                    {
                        accType = .01;
                        accType2 = .2;
                        totalProfit(Equation(accType, nbrReferrals, nbrClicks, accType2));
                        break;
                    }
            }
        }

        private void cmbClicks_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            switch (cmbClicks.SelectedIndex)
            {
                case 0:
                    {
                        nbrClicks = 1;
                        totalProfit(Equation(accType, nbrReferrals, nbrClicks, accType2));
                        break;
                    }
                case 1:
                    {
                        nbrClicks = 2;
                        totalProfit(Equation(accType, nbrReferrals, nbrClicks, accType2));
                        break;
                    }
                case 2:
                    {
                        nbrClicks = 3;
                        totalProfit(Equation(accType, nbrReferrals, nbrClicks, accType2));
                        break;
                    }
                case 3:
                    {
                        nbrClicks = 4;
                        totalProfit(Equation(accType, nbrReferrals, nbrClicks, accType2));
                        break;
                    }
                case 4:
                    {
                        nbrClicks = 5;
                        totalProfit(Equation(accType, nbrReferrals, nbrClicks, accType2));
                        break;
                    }
                case 5:
                    {
                        nbrClicks = 6;
                        totalProfit(Equation(accType, nbrReferrals, nbrClicks, accType2));
                        break;
                    }
            }
        }

        private void txtReferrals_TextChanged(object sender, EventArgs e)
        {
            result = int.TryParse(txtReferrals.Text, out nbrReferrals);
            if (result)
            {
                totalProfit(Equation(accType, nbrReferrals, nbrClicks, accType2));
            }
        }

        private double Equation(double accountType, int nmbrReferrals, int nmbrClicks, double accountType2)
        {
            if (result)
            {
                if (nbrReferrals > 0)
                {
                    double total = (accountType * nmbrClicks) * nmbrReferrals + accountType2;
                    return total;
                }
            }
            return 0;
        }

        private void totalProfit(double value)
        {
            radLabel4.Text = "<html><size=14><color=green><b>" + value.ToString("C") +"</b><color=ControlLight><size=8.25> per day";
            radLabel5.Text = "<html><size=14><color=green><b>" + (value * 30).ToString("C") + "</b><color=ControlLight><size=8.25> per month";
            radLabel6.Text = "<html><size=14><color=green><b>" + (value * 365).ToString("C") + "</b><color=ControlLight><size=8.25> per year";
        }

        private void txtReferrals_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) >= 65 && (Convert.ToInt32(e.KeyChar) <= 122))
            {
                MessageBox.Show("You cannot type letters in place of referrals.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtReferrals.Text = "0";
            }
        }
    }
}
