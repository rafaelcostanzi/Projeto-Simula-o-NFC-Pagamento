using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Protótipo_Projeto_Sistemas_Microcontrolados
{
    public partial class Form1 : Form
    {
        cartao meuCartao = null;
        public Form1()
        {
            InitializeComponent();
        }

        string selected = null;

        private void positionChanged(int x, int y, string name)
        {
            int xmin = this.Location.X + 15;
            int ymin = this.Location.Y + 25;
            int threshhold = 80;
            if (x > xmin && y > ymin && x < xmin+threshhold && y < ymin+threshhold && selected != name)
            {
                selected = name;
                string[] thisitem = null;
                foreach(string item in listBanco.Items)
                    if (item.StartsWith(name)) thisitem = item.Split('&');

                lblDados.Text = string.Concat("Nome: ", thisitem[0], "\r\nNumero cartão: ", thisitem[1], "\r\nTelefone: ", thisitem[2]);
            }
        }

        private void cartaoClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (meuCartao != null)
                meuCartao.Close();

            meuCartao = new cartao(btn.Text, positionChanged);
            meuCartao.Show();
        }

        private void refreshCards()
        {
            panelCartoes.Controls.Clear();
            foreach(string item in listBanco.Items)
            {
                Button newBtn = new Button();
                newBtn.Text = item.Split('&')[0];
                newBtn.Click += cartaoClick;
                panelCartoes.Controls.Add(newBtn);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            listBanco.Items.Add(string.Concat(txtNome.Text, "&", txtNumero.Text, "&", txtTelefone.Text));
            txtNome.Clear();
            txtNumero.Clear();
            txtTelefone.Clear();

            refreshCards();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (listBanco.SelectedIndex >= 0)
                listBanco.Items.RemoveAt(listBanco.SelectedIndex);

            refreshCards();
        }
    }
}
