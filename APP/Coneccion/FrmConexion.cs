using Microsoft.Win32;
using Negocios.NClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP.Coneccion
{
    public partial class FrmConexion : Form
    {
        public FrmConexion()
        {
            InitializeComponent();
        }

        private void GetInstanceName()
        {
            string ServerName = Environment.MachineName;
            RegistryView registryView = Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32;
            using (RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView))
            {
                RegistryKey instanceKey = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL", false);
                if (instanceKey != null)
                {
                    foreach (var instanceName in instanceKey.GetValueNames())
                    {
                        _ = cboServer.Items.Add(ServerName + "\\" + instanceName);
                    }
                }
            }
        }

        private void FrmConexion_Load(object sender, EventArgs e)
        {
            GetInstanceName();
            _ = cboServer.Items.Add(string.Format(@"{0}\(null)", Environment.MachineName));
            cboServer.SelectedIndex = 0;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            string connectionString;
            if (string.IsNullOrEmpty(txtUser.Text) && string.IsNullOrEmpty(txtClave.Text))
            {
                connectionString = string.Format(@"Server = {0}; DataBase = {1}; Integrated Security = true", cboServer.Text, txtDataBase.Text);
            }
            else
            {
                connectionString = string.Format(@"Server = {0}; DataBase = {1}; User Id = {2}; Password = {3}", cboServer.Text, txtDataBase.Text, txtUser.Text, txtClave.Text);
            }
            try
            {
                NSqlHelper helper = new NSqlHelper();
                if (helper.IsConnetion(connectionString))
                {
                    _ = MessageBox.Show("Test Connecton succeeded.", "Msj", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message, "Msj", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string connectionString;
            if (string.IsNullOrEmpty(txtUser.Text) && string.IsNullOrEmpty(txtClave.Text))
            {
                connectionString = string.Format(@"Server = {0}; DataBase = {1}; Integrated Security = true", cboServer.Text, txtDataBase.Text);
            }
            else
            {
                connectionString = string.Format(@"Server = {0}; DataBase = {1}; User Id = {2}; Password = {3}", cboServer.Text, txtDataBase.Text, txtUser.Text, txtClave.Text);
            }
            try
            {
                NSqlHelper helper = new NSqlHelper();
                if (helper.IsConnetion(connectionString))
                {
                    NAppSetting setting = new NAppSetting();
                    setting.SaveConnectionString("cn", connectionString);
                    MessageBox.Show("Connection Saved");
                    Close();
                }
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message, "Msj", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
