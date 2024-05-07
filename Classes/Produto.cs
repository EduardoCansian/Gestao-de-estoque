using System;
using System.Text;

namespace Classes
{
    internal class Produto
    {
        private string nome;

        public string Nome
        {
            get { return nome; }        // É executado quando a propriedade é lida

            set                         // É executado quando a propriedade recebe um valor
            {
                if (value.Length > 1)
                {
                    nome = value;
                }
                else
                {
                    throw new Exception("Nome do produto deve ter pelo menos 2 caracteres.");
                }
            }

        }

        public double Preco     // Propriedade auto implementada
        {
             get; set; 
        }

        public int Estoque
        {
            get; set;
        }

        public int Quant_Vendida
        {
            get; set;
        }

        public Produto()        // Método construtor
        {
            this.Estoque = 0;       // Todo novo objeto do tipo Produto que for criado em Estoque recebe o valor 0
        }

        public Produto(string nome, double preco, int quant, int quant_vendida)
        {
            this.Nome = nome;               // this representa o objeto que está sendo criado
            this.Preco = preco;
            this.Estoque = quant;
            this.Quant_Vendida = 0;
        }

        public Produto(int quant_vendida)
        {
            this.Quant_Vendida = quant_vendida;

        }

        public string ObterTexto()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("---------------------------");
            sb.Append($"\nNome: {this.Nome}\n");
            sb.Append($"\nPreço: R$ {this.Preco}\n");
            sb.Append($"\nEstoque: {this.Estoque}\n");
            sb.Append($"\nVendidos: {this.Quant_Vendida}");
            return sb.ToString();
        }

    }
}
