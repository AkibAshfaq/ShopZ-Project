﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmaZon
{
    public partial class AdminLog : Form
    {
        public AdminLog()
        {
            InitializeComponent();
            errortag.Visible = false;
        }

        SqlConnection connection;
        public void DBconnection()
        {
            connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\CODE Files\\VS 2022\\ShopzZ\\DB\\DemoDB.mdf\";Integrated Security=True;Connect Timeout=30;Encrypt=false");
            connection.Open();
        }

        //showpass
        public bool show_button = false;
        private void showpass_CheckedChanged(object sender, EventArgs e)
        {
            if (showpass.Checked == true)
            {
                password.UseSystemPasswordChar = false;
            }
            else
            {
                password.UseSystemPasswordChar = true;
            }
        }

        // Email Box Design
        private void mail_Enter(object sender, EventArgs e)
        {
            if (mail.Text == "Email")
            {
                mail.Text = "";
                mail.ForeColor = System.Drawing.Color.Black;
            }


        }

        private void mail_Leave(object sender, EventArgs e)
        {
            if (mail.Text == "")
            {
                mail.Text = "Email";
                mail.ForeColor = System.Drawing.Color.LightGray;
            }
        }


        // Password Box Design
        private void password_Enter(object sender, EventArgs e)
        {

            if (showpass.Checked == true)
            {
                password.UseSystemPasswordChar = false;
            }
            else
            {
                password.UseSystemPasswordChar = true;
            }


            if (password.Text == "Password")
            {
                password.Text = "";
                password.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void password_Leave(object sender, EventArgs e)
        {
            if (showpass.Checked == true)
            {
                password.UseSystemPasswordChar = false;
            }
            else
            {
                password.UseSystemPasswordChar = true;
            }


            if (password.Text == "")
            {
                password.UseSystemPasswordChar = false;
                password.Text = "Password";
                password.ForeColor = System.Drawing.Color.LightGray;
            }

        }

        private void login_Click(object sender, EventArgs e)
        {
            string pass = password.Text;
            string email = mail.Text;

            try
            {
                DBconnection();

                

                // Chaecking if exists or not
                SqlCommand sqlCommand2 = new SqlCommand("SELECT * from adminTable WHERE admin_mail = @email and admin_pass = @password", connection);
                sqlCommand2.Parameters.AddWithValue("@email", email);
                sqlCommand2.Parameters.AddWithValue("@password", pass);
                DataTable dtbl2 = new DataTable();
                SqlDataReader sdr2 = sqlCommand2.ExecuteReader();
                dtbl2.Load(sdr2);


                if (dtbl2.Rows.Count == 1 )
                {
                    {
                        SqlCommand saveid = new SqlCommand("select AID_number from admintable where admin_mail = @email and admin_pass = @password", connection);
                        saveid.Parameters.AddWithValue("@email", mail.Text);
                        saveid.Parameters.AddWithValue("@password", password.Text);
                        int idnum = Convert.ToInt32(saveid.ExecuteScalar());
                        connection.Close();
                        this.Hide();
                        AdminPage page = new AdminPage();
                        page.adminid = idnum;
                        page.Visible = true;
                    }
                }
                else
                {
                    errortag.Visible = true;
                    errortag.Text = "Invalid Credential";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Log in check not working");
            }
        }

        private void userback_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogPage log =new LogPage();
            log.Visible = true;
        }
    }
}
