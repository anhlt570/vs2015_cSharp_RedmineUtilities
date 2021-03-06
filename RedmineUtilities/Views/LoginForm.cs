﻿using RedmineUtilities.Controllers;
using RedmineUtilities.Models.user_models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RedmineUtilities.Views
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        public string userId;
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            performLoginAsync();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                performLoginAsync();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public async Task performLoginAsync()
        {
            var username = tbUsername.Text;
            var password = tbPassword.Text;
            User user = null;
            user = await NetworkUtils.getInstance().GetUserAsync("anh.le.tuan@ntq-solution.com.vn", "leanh128");
            if (user == null)
            {
                MessageBox.Show("There are somthing wrong");
            }
            else
            {
                var APIKey = user.api_key;
                if (cbAutoLogin.Checked)
                {
                    RegistryUtils.createValue(Constants.REGISTRY_CURRENT_USER, APIKey);
                }
                else RegistryUtils.createValue(Constants.REGISTRY_CURRENT_USER, "");
                userId = user.api_key;
                NetworkUtils.getInstance().addHeaderKey("X-Redmine-API-Key", userId);
                Close();
            }
        }
    }
}
