﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailingListFormsApp
{
    public partial class frmMailingList : Form
    {
        DateTime lastNow;
        TimeSpan elapsedTime;
        public frmMailingList()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            btnPause.Enabled = false;
            btnStart.Enabled = true;
            btnExit.Enabled = true;

            timSeconds.Enabled = false;

            grpMail.Enabled = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnExit.Enabled = false;
            btnPause.Enabled = false;

            lastNow = DateTime.Now;
            timSeconds.Enabled = true;

            grpMail.Enabled = true;
            txtName.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timSeconds_Tick(object sender, EventArgs e)
        {
            elapsedTime += DateTime.Now - lastNow;
            txtElapsedTime.Text = Convert.ToString(new TimeSpan(elapsedTime.Hours, elapsedTime.Minutes, elapsedTime.Seconds));
            lastNow = DateTime.Now;
        }
        private void txtInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            String boxName = ((TextBox)sender).Name;

            if((int) e.KeyChar == 13)
            {
                switch (boxName)
                {
                    case "txtName":
                        txtAddress.Focus();
                        break;
                    case "txtAddress":
                        txtCity.Focus();
                        break;
                    case "txtCity":
                        txtState.Focus();
                        break;
                    case "txtState":
                        txtState.Focus();
                        break;
                    case "txtZip":
                        btnAccept.Focus();
                        break;
                }
            }
            if (boxName.Equals("txtZip"))
            {
                if((e.KeyChar >= '0' && e.KeyChar <='9') || (int) e.KeyChar == 8)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            string s;

            if(txtName.Text.Equals("") || txtAddress.Text.Equals("") || txtCity.Text.Equals("") || txtState.Text.Equals("") || txtZip.Text.Equals(""))
            {
                MessageBox.Show("Each box must have an entry!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
                return;
            }
            s = txtName.Text + "\r\n" + txtAddress.Text + "\r\n";
            s += txtCity.Text + ", " + txtState.Text + " " + txtZip.Text;
            MessageBox.Show(s, "Mailing Label", MessageBoxButtons.OK);
            btnClear.PerformClick();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtAddress.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtZip.Text = "";
            txtName.Focus();
        }
    }
}
