using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilosofosQueJantam
{
    public partial class Form1 : Form
    {
        Filosofo f1 = new Filosofo();
        Filosofo f2 = new Filosofo();
        Filosofo f3 = new Filosofo();


        public Form1()
        {
            InitializeComponent();

            f1.AdicionarVizinhos(f3, f2);
            f2.AdicionarVizinhos(f1, f3);
            f3.AdicionarVizinhos(f2, f1);

            f1.nome = "F1";
            f2.nome = "F2";
            f3.nome = "F3";

            imgF1.Image = FilosofosQueJantam.Properties.Resources.pensando;
            imgF2.Image = FilosofosQueJantam.Properties.Resources.pensando;
            imgF3.Image = FilosofosQueJantam.Properties.Resources.pensando;

            Validar();
        }

        private void Validar()
        {
            switch (f1.EstadoFilosofo)
            {
                case 0:
                    imgF1.Image = FilosofosQueJantam.Properties.Resources.pensando;
                    break;
                case 1:
                    imgF1.Image = imgF2.Image = FilosofosQueJantam.Properties.Resources.com_fome;
                    break;
                case 2:
                    imgF1.Image = FilosofosQueJantam.Properties.Resources.comendo;
                    break;
            }

            switch (f2.EstadoFilosofo)
            {
                case 0:
                    imgF2.Image = FilosofosQueJantam.Properties.Resources.pensando;
                    break;
                case 1:
                    imgF2.Image = FilosofosQueJantam.Properties.Resources.com_fome;
                    break;
                case 2:
                    imgF2.Image = FilosofosQueJantam.Properties.Resources.comendo;
                    break;
            }

            switch (f3.EstadoFilosofo)
            {
                case 0:
                    imgF3.Image = FilosofosQueJantam.Properties.Resources.pensando;
                    break;
                case 1:
                    imgF3.Image = FilosofosQueJantam.Properties.Resources.com_fome;
                    break;
                case 2:
                    imgF3.Image = FilosofosQueJantam.Properties.Resources.comendo;
                    break;
            }


            #region validando garfo
            if (f1.Garfo[0] == true)
                f1GarfoEsq.BackColor = System.Drawing.Color.Green;
            else
                f1GarfoEsq.BackColor = System.Drawing.Color.Gray;

            if (f2.Garfo[0] == true)
                f2GarfoEsq.BackColor = System.Drawing.Color.Green;
            else
                f2GarfoEsq.BackColor = System.Drawing.Color.Gray;

            if (f3.Garfo[0] == true)
                f3GarfoEsq.BackColor = System.Drawing.Color.Green;
            else
                f3GarfoEsq.BackColor = System.Drawing.Color.Gray;

            if (f1.Garfo[1] == true)
                f1GarfoDir.BackColor = System.Drawing.Color.Green;
            else
                f1GarfoDir.BackColor = System.Drawing.Color.Gray;

            if (f2.Garfo[1] == true)
                f2GarfoDir.BackColor = System.Drawing.Color.Green;
            else
                f2GarfoDir.BackColor = System.Drawing.Color.Gray;

            if (f3.Garfo[1] == true)
                f3GarfoDir.BackColor = System.Drawing.Color.Green;
            else
                f3GarfoDir.BackColor = System.Drawing.Color.Gray;
            #endregion

            #region validando Token
            if (f1.Token[0] == true)
                f1TokenESQ.BackColor = System.Drawing.Color.Aqua;
            else
                f1TokenESQ.BackColor = System.Drawing.Color.Gray;

            if (f2.Token[0] == true)
                f2TokenEsq.BackColor = System.Drawing.Color.Aqua;
            else
                f2TokenEsq.BackColor = System.Drawing.Color.Gray;

            if (f3.Token[0] == true)
                f3TokenEsq.BackColor = System.Drawing.Color.Aqua;
            else
                f3TokenEsq.BackColor = System.Drawing.Color.Gray;

            if (f1.Token[1] == true)
                f1TokenDir.BackColor = System.Drawing.Color.Aqua;
            else
                f1TokenDir.BackColor = System.Drawing.Color.Gray;

            if (f2.Token[1] == true)
                f2TokenDir.BackColor = System.Drawing.Color.Aqua;
            else
                f2TokenDir.BackColor = System.Drawing.Color.Gray;

            if (f3.Token[1] == true)
                f3TokenDir.BackColor = System.Drawing.Color.Aqua;
            else
                f3TokenDir.BackColor = System.Drawing.Color.Gray;
            #endregion
        }

        private void imgF1_Click(object sender, EventArgs e)
        {
            if (f1.EstadoFilosofo == 2)
                f1.PararDeComer();
            else
                f1.EstadoFilosofo = 1;
                f1.Validar();
            Validar();
        }

        private void imgF2_Click(object sender, EventArgs e)
        {
            if (f2.EstadoFilosofo == 2)
                f2.PararDeComer();
            else
                f2.EstadoFilosofo = 1;
                f2.Validar();
            Validar();
        }

        private void imgF3_Click(object sender, EventArgs e)
        {
            if (f3.EstadoFilosofo == 2)
                f3.PararDeComer();
            else
                f3.EstadoFilosofo = 1;
                f3.Validar();
            Validar();
        }
    }
}
