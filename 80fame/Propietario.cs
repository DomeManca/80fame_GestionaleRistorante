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
    public partial class Proprietario : Form
    {
        public Proprietario()
        {
            InitializeComponent();
        }
        public string tmp;
        public void Reset()
        {
            pnRIC.Visible = false;
            pnMODPASS.Visible = false;
            pnAGG.Visible = false;
            pnELI.Visible = false;
            pnMOD.Visible = false;
            pnVIS.Visible = false;
            pnREC.Visible = false;
            pnUO.Visible = false;
        }
        public struct Piatto
        {
            public string nome;
            public int prezzo;
            public int quantità;
        }
        private void Proprietario_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        public void Cartella(ref string percorso, ref bool v, string key) //in base alla portata seleziono una cartella differente
        {
            switch (key)
            {
                case "Antipasto":
                    percorso = @".\menu\1\";
                    break;
                case "Primo":
                    percorso = @".\menu\2\";
                    break;
                case "Secondo":
                    percorso = @".\menu\3\";
                    break;
                case "Dessert":
                    percorso = @".\menu\4\";
                    break;
                default:
                    v = false;
                    break;
            }
        }
        public string CercaPiatto(string piatto) //Controllo se il piatto esiste o meno
        {
            //ANTIPASTO
            string percorso = $@".\menu\1\{piatto}.txt";
            if (File.Exists(percorso))
            {
                lblPoRIC.Text = "Antipasto";
                cbMOD.Text = "Antipasto";
                return percorso;
            }
            //PRIMO
            percorso = $@".\menu\2\{piatto}.txt";
            if (File.Exists(percorso))
            {
                lblPoRIC.Text = "Primo";
                cbMOD.Text = "Primo";
                return percorso;
            }
            //SECONDO
            percorso = $@".\menu\3\{piatto}.txt";
            if (File.Exists(percorso))
            {
                lblPoRIC.Text = "Secondo";
                cbMOD.Text = "Secondo";
                return percorso; ;
            }
            //DESSERT
            percorso = $@".\menu\4\{piatto}.txt";
            if (File.Exists(percorso))
            {
                lblPoRIC.Text = "Dessert";
                cbMOD.Text = "Dessert";
                return percorso;
            }
            //ERRORE
            MessageBox.Show("Piatto inesistente", "Errore");
            return null;
        }
        //Modifca Password
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
        public static void scrivi(string filename, string content)
        {
            StreamWriter sw = new StreamWriter(filename);
            sw.WriteLine(content);
            sw.Close();
        }
        private void btVMODPASS_Click(object sender, EventArgs e)
        {
            if (tbVPASS.Text == leggi(@"./menu/login.txt"))
            {
                if (tbPASS1.Text == tbPASS2.Text)
                {
                    scrivi(@"./menu/login.txt", tbPASS1.Text);
                    MessageBox.Show("Password cambiata correttamente", "Successo");
                    tbVPASS.Text = "";
                    tbPASS1.Text = "";
                    tbPASS2.Text = "";
                }
                else
                {
                    MessageBox.Show("Password non coincidono", "Errore");
                    tbPASS1.Text = "";
                    tbPASS2.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Password errata", "Errore");
                tbVPASS.Text = "";
            }
        }
        //Aggiungi
        private void btVAGG_Click(object sender, EventArgs e)
        {
            string percorso = "";
            bool v = true;
            if (tbNAGG.Text == string.Empty)
            {
                v = false;
                MessageBox.Show("Inserire nome del piatto", "Errore");
            }
            if (tbPAGG.Text == string.Empty)
            {
                v = false;
                MessageBox.Show("Inserire prezzo del piatto", "Errore");
            }
            if (cbAGG.Text == string.Empty)
            {
                v = false;
                MessageBox.Show("Inserire portata del piatto", "Errore");
            }
            if (tb1AGG.Text == string.Empty || tb2AGG.Text == string.Empty || tb3AGG.Text == string.Empty || tb4AGG.Text == string.Empty)
            {
                v = false;
                MessageBox.Show("Inserire tutti gli ingredienti del piatto", "Errore");
            }
            Cartella(ref percorso, ref v, cbAGG.Text);
            if (File.Exists(percorso))
            {
                MessageBox.Show("Il piatto esiste già", "Errore");
                v = false;
            }
            if (v == true)
            {
                percorso = percorso + tbNAGG.Text + ".txt";
                ScriviAGG(percorso);
                MessageBox.Show("Piatto aggiunto con succeso", "Successo");
                tb1AGG.Text = "";
                tb2AGG.Text = "";
                tb3AGG.Text = "";
                tb4AGG.Text = "";
                tbNAGG.Text = "";
                tbPAGG.Text = "";
                cbAGG.Text = "";
            }
        }
        public void ScriviAGG(string percorso)
        {
            StreamWriter sw = new StreamWriter(percorso);
            sw.WriteLine(tbPAGG.Text);
            sw.WriteLine(tb1AGG.Text);
            sw.WriteLine(tb2AGG.Text);
            sw.WriteLine(tb3AGG.Text);
            sw.WriteLine(tb4AGG.Text);
            sw.Close();
        }
        //Ricerca
        private void btVRIC_Click(object sender, EventArgs e)
        {
            string key = tbNRIC.Text;
            lblNRIC.Text = "";
            lblPoRIC.Text = "";
            lblPrRIC.Text = "";
            lbl1RIC.Text = "";
            lbl2RIC.Text = "";
            lbl3RIC.Text = "";
            lbl4RIC.Text = "";
            tbNRIC.Text = "";

            if (key != string.Empty)
            {
                string percorso = CercaPiatto(key);
                if (percorso != null) //Lettura file
                {
                    LeggiRIC(percorso);
                    lblNRIC.Text = key;
                }
            }
            else
            {
                MessageBox.Show("Inserisci il nome del piatto", "Errore");
            }

        }
        public void LeggiRIC(string path) //lettura file
        {
            StreamReader sr = new StreamReader(path);
            lblPrRIC.Text = sr.ReadLine();
            lbl1RIC.Text = sr.ReadLine();
            lbl2RIC.Text = sr.ReadLine();
            lbl3RIC.Text = sr.ReadLine();
            lbl4RIC.Text = sr.ReadLine();
            sr.Close();
        }
        //Modifica
        private void btRICMOD_Click(object sender, EventArgs e)
        {
            string key = tbMOD.Text;
            tbNMOD.Text = "";
            tbPMOD.Text = "";
            cbMOD.Text = "";
            tb1MOD.Text = "";
            tb2MOD.Text = "";
            tb3MOD.Text = "";
            tb4MOD.Text = "";
            tbMOD.Text = "";

            if (key != string.Empty)
            {
                string percorso = CercaPiatto(key);
                if (percorso != null) //Lettura file
                {
                    LeggiMOD(percorso);
                    tmp = percorso;
                    tbNMOD.Text = key;
                }
            }
            else
            {
                MessageBox.Show("Inserisci il nome del piatto", "Errore");
            }

        }
        public void LeggiMOD(string path) //lettura file
        {
            StreamReader sr = new StreamReader(path);
            tbPMOD.Text = sr.ReadLine();
            tb1MOD.Text = sr.ReadLine();
            tb2MOD.Text = sr.ReadLine();
            tb3MOD.Text = sr.ReadLine();
            tb4MOD.Text = sr.ReadLine();
            sr.Close();
        }
        private void btVMOD_Click(object sender, EventArgs e)
        {
            System.IO.File.Delete(tmp);
            string percorso = "";
            bool v = true;
            if (tbNMOD.Text == string.Empty)
            {
                v = false;
                MessageBox.Show("Inserire nome del piatto", "Errore");
            }
            if (tbPMOD.Text == string.Empty)
            {
                v = false;
                MessageBox.Show("Inserire prezzo del piatto", "Errore");
            }
            if (cbMOD.Text == string.Empty)
            {
                v = false;
                MessageBox.Show("Inserire portata del piatto", "Errore");
            }
            if (tb1MOD.Text == string.Empty || tb2MOD.Text == string.Empty || tb3MOD.Text == string.Empty || tb4MOD.Text == string.Empty)
            {
                v = false;
                MessageBox.Show("Inserire tutti gli ingredienti del piatto", "Errore");
            }
            Cartella(ref percorso, ref v, cbMOD.Text);
            if (File.Exists(percorso))
            {
                MessageBox.Show("Il piatto esiste già", "Errore");
                v = false;
            }
            if (v == true)
            {
                percorso = percorso + tbNMOD.Text + ".txt";
                ScriviMOD(percorso);
                MessageBox.Show("Piatto aggiunto con succeso", "Successo");
                tb1MOD.Text = "";
                tb2MOD.Text = "";
                tb3MOD.Text = "";
                tb4MOD.Text = "";
                tbNMOD.Text = "";
                tbPMOD.Text = "";
                cbMOD.Text = "";
            }
        }
        public void ScriviMOD(string percorso)
        {
            StreamWriter sw = new StreamWriter(percorso);
            sw.WriteLine(tbPMOD.Text);
            sw.WriteLine(tb1MOD.Text);
            sw.WriteLine(tb2MOD.Text);
            sw.WriteLine(tb3MOD.Text);
            sw.WriteLine(tb4MOD.Text);
            sw.Close();
        }
        //Elimina
        private void cbELI_CheckedChanged(object sender, EventArgs e)
        {
            if (cbELI.Checked == true)
                MessageBox.Show("Se mantieni questa spunta non sarai più in grado di recuperare questo piatto", "Attenzione");
        }
        private void btVELI_Click(object sender, EventArgs e)
        {
            string key = tbELI.Text;
            
            if (key != string.Empty)
            {
                string percorso = CercaPiatto(key);
                if (percorso != null) //Lettura file
                {
                    if (cbELI.Checked == true)
                    {
                        System.IO.File.Delete(percorso);
                        MessageBox.Show("Piatto eliminato definitivamente", "Successo");
                    }
                    else
                    {
                        string n = percorso.Substring(7, 1);
                        System.IO.File.Move(percorso, $@".\menu\5\{n}{key}.txt");
                        MessageBox.Show("Piatto spostato nel cestino", "Successo");
                    }
                }
            }
            else
            {
                MessageBox.Show("Inserisci il nome del piatto", "Errore");
            }
        }
        //Menù
        private void cbPVIS_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbNVIS.Items.Clear();
            string portata = cbPVIS.Text;
            string percorso = "";
            bool v = true;
            Cartella(ref percorso, ref v, portata);
            if (v == true)
            {
                List<string> dirs = new List<string>(Directory.EnumerateFiles(percorso, "*.txt", SearchOption.AllDirectories));
                foreach (string dir in dirs)
                {
                    string nome = $"{dir.Substring(dir.LastIndexOf(Path.DirectorySeparatorChar) + 1)}";
                    int count = nome.Count();
                    nome = nome.Remove(count - 4);
                    cbNVIS.Items.Add(nome);
                }
            }
            else
            {
                MessageBox.Show("Nome portata non valida", "Errore");
            }     
        }
        private void cbNVIS_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nome = cbNVIS.Text;
            string portata = cbPVIS.Text;
            string percorso = "";
            bool v = true;
            Cartella(ref percorso, ref v, portata);
            percorso = percorso + nome + ".txt";
            if (v==true)
            {
                StreamReader sr = new StreamReader(percorso);
                lblPrVIS.Text = sr.ReadLine();
                lbl1VIS.Text = sr.ReadLine();
                lbl2VIS.Text = sr.ReadLine();
                lbl3VIS.Text = sr.ReadLine();
                lbl4VIS.Text = sr.ReadLine();
                sr.Close();
                lblNVIS.Text = nome;
                lblPoVIS.Text = portata;
            }
            else
            {
                MessageBox.Show("Nome portata non valida", "Errore");
            }
        }
        //Cestino
        private void btVREC_Click(object sender, EventArgs e)
        {
            string key = lbREC.SelectedItem.ToString();
            string n = key.Substring(0,1);
            lbREC.Items.Remove(key);
            key = key.Remove(0,1);
            string percorso = $@".\menu\{n}\{key}.txt";
            System.IO.File.Move($@".\menu\5\{n}{key}.txt", percorso);
            MessageBox.Show("Piatto riaggiunto al menù", "Successo");
        }
        //bt HOME
        private void btHOME_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
        private void btVIS_Click(object sender, EventArgs e)
        {
            Reset();
            pnVIS.Visible = true;
            pnVIS.Location = new System.Drawing.Point(138, 64);
            cbNVIS.Text = "";
            cbPVIS.Text = "";
            lblNVIS.Text = "-";
            lblPoVIS.Text = "-";
            lblPrVIS.Text = "-";
            lbl1VIS.Text = "-";
            lbl2VIS.Text = "-";
            lbl3VIS.Text = "-";
            lbl4VIS.Text = "-";
        }
        private void btELI_Click(object sender, EventArgs e)
        {
            Reset();
            pnELI.Visible = true;
            pnELI.Location = new System.Drawing.Point(138, 64);
            tbELI.Clear();
            cbELI.Checked = false;
        }
        private void btMOD_Click(object sender, EventArgs e)
        {
            Reset();
            pnMOD.Visible = true;
            pnMOD.Location = new System.Drawing.Point(138, 64);
            tbNMOD.Clear();
            tbMOD.Clear();
            tbPMOD.Clear();
            tb1MOD.Clear();
            tb2MOD.Clear();
            tb3MOD.Clear();
            tb4MOD.Clear();
            cbMOD.Text = "";
        }
        private void btAGG_Click(object sender, EventArgs e)
        {
            Reset();
            pnAGG.Visible = true;
            pnAGG.Location = new System.Drawing.Point(138, 64);
            tbNAGG.Clear();
            tbPAGG.Clear();
            tb1AGG.Clear();
            tb2AGG.Clear();
            tb3AGG.Clear(); 
            tb4AGG.Clear();
            cbAGG.Text = "";
        }
        private void btRIC_Click(object sender, EventArgs e)
        {
            Reset();
            pnRIC.Visible = true;
            pnRIC.Location = new System.Drawing.Point(138, 64);
            tbNRIC.Clear();
            lblNRIC.Text = "-";
            lblPoRIC.Text = "-";
            lblPrRIC.Text = "-";
            lbl1RIC.Text = "-";
            lbl2RIC.Text = "-";
            lbl3RIC.Text = "-";
            lbl4RIC.Text = "-";
        }
        private void btMODPASS_Click(object sender, EventArgs e)
        {
            Reset();
            pnMODPASS.Visible = true;
            pnMODPASS.Location = new System.Drawing.Point(138, 64);
            tbVPASS.Clear();
            tbPASS1.Clear();
            tbPASS2.Clear();
        }
        private void btREC_Click(object sender, EventArgs e)
        {
            lbREC.Items.Clear();
            Reset();
            pnREC.Visible = true;
            pnREC.Location = new System.Drawing.Point(138, 64);
            lbREC.Text = "";
            string percorso = $@".\menu\5\";
            List<string> dirs = new List<string>(Directory.EnumerateFiles(percorso, "*.txt", SearchOption.AllDirectories));
            foreach (string dir in dirs)
            {
                string nome = $"{dir.Substring(dir.LastIndexOf(Path.DirectorySeparatorChar) + 1)}";
                int count = nome.Count();
                nome = nome.Remove(count - 4);
                lbREC.Items.Add(nome);
            }
        }
        private void btUO_Click(object sender, EventArgs e)
        {
            Reset();
            pnUO.Visible = true;
            pnUO.Location = new System.Drawing.Point(138, 64);
            int tot = 0;
            Piatto[] vecchiordini = new Piatto[50];
            if (File.Exists(@".\menu\ordine.txt"))
            {
                StreamReader sr = new StreamReader(@".\menu\ordine.txt");
                int c = int.Parse(sr.ReadLine());
                for (int i = 0; i < c; i++)
                {
                    vecchiordini[i].nome = sr.ReadLine();
                    vecchiordini[i].prezzo = int.Parse(sr.ReadLine());
                    vecchiordini[i].quantità = int.Parse(sr.ReadLine());
                    tot = tot + (vecchiordini[i].prezzo * vecchiordini[i].quantità);
                    string[] row = { vecchiordini[i].nome, Convert.ToString(vecchiordini[i].prezzo), Convert.ToString(vecchiordini[i].quantità) };
                    var listViewItem = new ListViewItem(row);
                    lvUO.Items.Add(listViewItem);
                }
                sr.Close();
                lblTUO.Text = Convert.ToString(tot);
            }
        }
    }
}