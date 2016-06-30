using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilosofosQueJantam
{
    class Filosofo
    {
        #region Atributos
        public String nome { get; set; }
        public bool[] Garfo { get; set; }
        public bool[] Sujo { get; set; }
        public bool[] Token { get; set; }
        public byte EstadoFilosofo { get; set; }
        public Filosofo[] Vizinhos { get; set; }
        #endregion

        #region Contrutor
        public Filosofo()
        {
            this.Garfo = new bool[2];
            this.Garfo[0] = false;
            this.Garfo[1] = true;

            this.Sujo = new bool[2];
            this.Sujo[0] = true;
            this.Sujo[1] = true;

            this.Token = new bool[2];
            this.Token[0] = true;
            this.Token[1] = false;

            this.EstadoFilosofo = 0;
        }
        #endregion

        #region Metodos
        public void AdicionarVizinhos(Filosofo vizinhoEsq, Filosofo vizinhoDir)
        {
            this.Vizinhos = new Filosofo[2];
            Vizinhos[0] = vizinhoEsq;
            Vizinhos[1] = vizinhoDir;
        }

        public void Validar()
        {
            if (this.EstadoFilosofo == 1 )
                this.Comer();
            if (this.Vizinhos[0].EstadoFilosofo == 1)
                this.Vizinhos[0].Comer();
            if (this.Vizinhos[1].EstadoFilosofo == 1)
                this.Vizinhos[1].Comer();
        }

        public void EnviarGarfo(int lado)
        {
            if (this.EstadoFilosofo != 2 && this.Token[1 - lado] == false && this.Garfo[1 - lado] == true && this.Sujo[1 - lado] == true)
            {
                //pegando o tokeng
                this.Token[1 - lado] = true;
                Vizinhos[1 - lado].Token[lado] = false;

                //Enviando o garfo
                this.Garfo[1 - lado] = false;
                Vizinhos[1 - lado].Garfo[lado] = true;

                //Limpar o garfo 
                Vizinhos[1 - lado].Sujo[lado] = false;

                //Mandando o vizinho comer
                Vizinhos[1 - lado].Comer();
            }
            else
            {
                //Pegando o token do vizinho
                Vizinhos[1 - lado].Token[lado] = false;
                this.Token[1 - lado] = true;
            }
        }

        public void Comer()
        {
            //Vendo se tenho 2 garfos
            if (this.Garfo[0] == true && this.Garfo[1] == true)
            {
                this.EstadoFilosofo = 2;
                this.Sujo[0] = true;
                this.Sujo[1] = true;
            }
            else
            {
                if (this.Token[0] && this.Garfo[0] == false)
                    Vizinhos[0].EnviarGarfo(0);
                if (this.Token[1] && this.Garfo[1] == false)
                    Vizinhos[1].EnviarGarfo(1);

            }
        }

        public void PararDeComer()
        {
            if (this.EstadoFilosofo != 0)
                this.EstadoFilosofo = 0;

            //Dando garfo para o vizinho da esquerda, caso solicitado
            if (this.Token[0] == true)
            {
                //Limpando Garfo
                this.Sujo[0] = false;

                //Enviando garfo
                this.Garfo[0] = false;
                Vizinhos[0].Garfo[1] = true;

                if (Vizinhos[0].EstadoFilosofo == 1)
                {
                    Vizinhos[0].Comer();
                }
            }

            //Dando garfo para o vizinho da direita, caso solicitado
            if (this.Token[1] == true)
            {
                //Limpando Garfo
                this.Sujo[1] = false;

                //Enviando garfo
                this.Garfo[1] = false;
                Vizinhos[1].Garfo[0] = true;
                if (Vizinhos[1].EstadoFilosofo == 1)
                {
                    Vizinhos[1].Comer();
                }
            }
        }
        #endregion

    }

}
