using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _80fame
{
    public partial class HOME : Form
    {
        Cliente Cliente = new Cliente();
        Proprietario Proprietario = new Proprietario();
        public HOME()
        {
            InitializeComponent();
        }
        string ps = leggi(@"./menu/login.txt");
        static string leggi(string filename)
        {
            StreamReader sr = new StreamReader(filename);
            string line;
            string count = "0";
            while ((line = sr.ReadLine()) != null)
            {
                count = line;
                sr.Close();
                return count;
            }
            sr.Close();
            return count;

        }
        private void btHOME_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void HOME_Load(object sender, EventArgs e)
        {
            Reset();
            if (File.Exists(@"./menu"))
            {
            }
            else
            {
                MessageBox.Show("Seguire le indicazioni del file README.md", "Errore");
                Application.Exit();
            }
        }
        public void Reset()
        {
            pnINIZIAMO.Visible = false;
            pnPROPETARIO.Visible = false;
            tbPASSWORD.Text = "";
        }

        private void btINIZIAMO_Click(object sender, EventArgs e)
        {
            pnINIZIAMO.Visible = true;
        }

        private void btCLIENTE_Click(object sender, EventArgs e)
        {
            Cliente.Show();
            this.Visible = false;
        }

        private void btPROPETARIO_Click(object sender, EventArgs e)
        {
            pnPROPETARIO.Visible = true;
        }
        private void btPASSWORD_Click(object sender, EventArgs e)
        {
            if(tbPASSWORD.Text == ps )
            {
                Proprietario.Show();
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("Password errata", "Errore");
                tbPASSWORD.Text = "";
            }
        }
    }
}
