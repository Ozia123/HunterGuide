﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace HunterGuide.Forms.AdminUI
{
    public partial class AllTestForm : MetroForm
    {
        public AllTestForm()
        {
            InitializeComponent();

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}