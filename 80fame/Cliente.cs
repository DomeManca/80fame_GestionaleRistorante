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
    public partial class Cliente : Form
    {
        public Cliente()
        {
            InitializeComponent();
        }
        public int tot = 0;
        public int n = 0;
        public struct Piatto
        {
            public string nome;
            public int prezzo;
            public int quantità;
        }
        Piatto[] ordini = new Piatto[50];
        private void Cliente_Load(object sender, EventArgs e)
        {
            Carica();
        }
        private void Cliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        public void Reset()
        {
            pnOR.Visible = false;
            pnCA.Visible = false;
        }
        public void Carica()
        {
            for (int i = ordini.Length; i > 0; i--)
            {
                ordini[i - 1].nome = "/";
            }
            tot = 0;
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
        //bt HOME
        private void btHOME_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
        private void btOR_Click(object sender, EventArgs e)
        {
            Reset();
            pnOR.Visible = true;
            pnOR.Location = new System.Drawing.Point(12, 122);
            lbOR.Text = "";
            dOR.Text = "";
            lblNVIS.Text = "-";
            lblTOR.Text = "-";
            lblPoVIS.Text = "-";
            lblPrVIS.Text = "-";
            lbl1VIS.Text = "-";
            lbl2VIS.Text = "-";
            lbl3VIS.Text = "-";
            lbl4VIS.Text = "-";
            dOR.Text = "Antipasto";
        }
        private void btCA_Click(object sender, EventArgs e)
        {
            Reset();
            pnCA.Visible = true;
            pnCA.Location = new System.Drawing.Point(12, 122);
            Aggiorna();
        }
        //Ordinazioni
        private void dOR_SelectedItemChanged(object sender, EventArgs e)
        {
            lbOR.Items.Clear();
            string portata = dOR.Text;
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
                    lbOR.Items.Add(nome);
                }
            }
        }
        private void lbOR_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nome = lbOR.Text;
            string portata = dOR.Text;
            string percorso = "";
            bool v = true;
            if (nome == string.Empty)
                v = false;
            Cartella(ref percorso, ref v, portata);
            percorso = percorso + nome + ".txt";
            if (v == true)
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
                MessageBox.Show("Dati non validi", "Errore");
            }
        }
        private void btVOR_Click(object sender, EventArgs e)

        {
            Piatto o;
            o.nome = lblNVIS.Text;
            o.prezzo = int.Parse(lblPrVIS.Text);
            o.quantità = Convert.ToInt32(nOR.Value);
            ordini[n] = o;
            n++;
            for (int i = o.quantità; i > 0; i--)
            {
                tot += int.Parse(lblPrVIS.Text);
                lblTOR.Text = Convert.ToString(tot);
            }
            nOR.Value = 1;
        }
        private void btEOR_Click(object sender, EventArgs e)
        {
            Carica();
            lblTOR.Text = Convert.ToString(tot);
        }
        //Carrello
        public void Aggiorna()
        {
            tot = 0;
            lvCA.Items.Clear();
            for (int i = ordini.Length; i > 0; i--)
            {
                if (ordini[i - 1].nome != "/")
                {
                    tot = tot + (ordini[i - 1].prezzo * ordini[i - 1].quantità);
                    string[] row = { ordini[i - 1].nome, Convert.ToString(ordini[i - 1].prezzo), Convert.ToString(ordini[i - 1].quantità) };
                    var listViewItem = new ListViewItem(row);
                    lvCA.Items.Add(listViewItem);
                }
            }
            lblTCA.Text = Convert.ToString(tot);
        }
        public void Elimina(string nome)
        {
            for (int i = ordini.Length; i > 0; i--)
            {
                if (ordini[i - 1].nome == nome)
                    ordini[i - 1].nome = "/";
            }
        }
        private void btECA_Click(object sender, EventArgs e)
        {
            string nome = "";
            try
            {
                nome = lvCA.SelectedItems[0].Text;
            }
            catch
            {
                MessageBox.Show("Seleziona un piatto", "Errore");
            }

            Elimina(nome);
            Aggiorna();

        }
        private void btPCA_Click(object sender, EventArgs e)
        {
            string nome = "";
            try
            {
                nome = lvCA.SelectedItems[0].Text;
            }
            catch
            {
                MessageBox.Show("Seleziona un piatto", "Errore");
            }

            for (int i = ordini.Length; i > 0; i--)
            {
                if (ordini[i - 1].nome == nome)
                    ordini[i - 1].quantità += 1;
            }
            Aggiorna();
        }
        private void btMCA_Click(object sender, EventArgs e)
        {
            string nome = "";
            try
            {
                nome = lvCA.SelectedItems[0].Text;
            }
            catch
            {
                MessageBox.Show("Seleziona un piatto", "Errore");
            }

            for (int i = ordini.Length; i > 0; i--)
            {
                if (ordini[i - 1].nome == nome)
                {
                    if (ordini[i - 1].quantità == 1)
                    {
                        Elimina(nome);
                    }
                    else
                    {
                        ordini[i - 1].quantità -= 1;
                    }
                }
            }
            Aggiorna();

        }
        private void btVCA_Click(object sender, EventArgs e)
        {
            Scrivi();

            int nr = 0;
            for (int i = ordini.Length; i > 0; i--)
            {
                if (ordini[i - 1].nome != "/")
                {
                    nr += ordini[i - 1].quantità;
                }
            }
            lblTCA.Text = Convert.ToString(tot);
            MessageBox.Show($"Hai ordinato {nr} piatto/i per un totale di {tot}€.", "Ordine effetuato");
            Carica();
            Aggiorna();
        }
        public void Scrivi()
        {
            StreamWriter sw = new StreamWriter(@".\menu\ordine.txt");
            sw.WriteLine(Conta());
            for (int i = ordini.Length; i > 0; i--)
            {
                if (ordini[i - 1].nome != "/")
                {
                    sw.WriteLine(ordini[i - 1].nome);
                    sw.WriteLine(ordini[i - 1].prezzo);
                    sw.WriteLine(ordini[i - 1].quantità);
                }
            }
            sw.Close();
        }
        public int Conta()
        {
            int f = 0;
            for (int i = ordini.Length; i > 0; i--)
            {
                if (ordini[i - 1].nome != "/")
                {
                    f++;


                }
            }
            return f;
        }
    }
}
