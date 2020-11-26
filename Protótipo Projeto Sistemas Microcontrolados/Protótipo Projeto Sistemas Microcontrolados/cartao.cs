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
    public partial class cartao : Form
    {
        Action<int, int, string> changed;

        public cartao(string nome, Action<int, int, string> _changed)
        {
            InitializeComponent();
            changed = _changed;

            lblNome.Text = nome;
        }
        private bool mouseDown;
        private Point lastLocation;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
                changed(this.Location.X, this.Location.Y, lblNome.Text);
            }
        }
    }
}
