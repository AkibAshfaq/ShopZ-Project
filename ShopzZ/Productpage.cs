﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmaZon
{
    public partial class Productpage : Form
    {
        public Productpage()
        {
            InitializeComponent();
        }

        private void addtocart_Click(object sender, EventArgs e)
        {

        }

        private void backtoHome_Click(object sender, EventArgs e)
        {
            HomePage home = new HomePage();
        }
    }
}
