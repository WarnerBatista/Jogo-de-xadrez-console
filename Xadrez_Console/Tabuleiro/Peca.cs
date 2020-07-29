using System;
using System.Collections.Generic;
using System.Text;

namespace tabuleiro
{
    abstract class Peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qteMovimentos { get; protected set; }
        public Tabuleiro tab { get; protected set; }

        public Peca(Tabuleiro tabuleiro, Cor cor)
        {
            this.posicao = null;
            this.cor = cor;
            this.tab = tabuleiro;
            this.qteMovimentos = 0;
        }

        public void incrementarQtdeMovimentos()
        {
            qteMovimentos++;
        }

        public abstract bool[,] movimentospossiveis();

        public bool existeMovimentospossiveis()
        {
            bool[,] mat = movimentospossiveis();
            for (int i=0; i<tab.linhas; i++)
            {
                for(int j=0; j<tab.colunas; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool podeMoverPara(Posicao pos)
        {
            return movimentospossiveis()[pos.Linha, pos.Coluna];
        }
    }
}
