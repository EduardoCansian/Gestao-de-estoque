using System;
using System.Collections.Generic;

namespace Classes
{
    internal class Program
    {
        private static List<Produto> produtos = new List<Produto>();
        static Produto novoproduto;
        static void Main(string[] args)
        {
            int op = char.MinValue;

            while(op != 4)
            {
                Console.Clear();
                Console.WriteLine("--------- Gestão de Estoque ---------");
                Console.WriteLine("");
                Console.WriteLine("Menu principal: \n1) Comprar produto \n2) Vender produto \n3) Acessar estoque \n4) Sair");
                Console.Write("Selecione uma das opções acima:");
                op = int.Parse(Console.ReadLine()!);

                switch (op)
                {
                    case 1:
                        Console.Clear();
                        ComprarProduto();
                        break;
                    case 2:
                        Console.Clear();
                        VenderProduto();
                        break;
                    case 3:
                        Console.Clear();
                        ListarProduto();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Obrigado por utilizar nosso sistema. Volte sempre :D");
                        break;

                    default: 
                        Console.WriteLine("Opção inválida.Tente novamente.");
                        break;
                }

            }

            static void ComprarProduto()
            {
                novoproduto = new Produto();

                Console.WriteLine("Digite o nome do produto:");
                novoproduto.Nome = Console.ReadLine()!;

                Console.WriteLine("Digite o preço do produto:");
                novoproduto.Preco = double.Parse(Console.ReadLine()!);

                Console.WriteLine("Digite a quantidade desse produto:");
                novoproduto.Estoque = int.Parse(Console.ReadLine()!);

                novoproduto.Quant_Vendida = 0;
                produtos.Add(novoproduto);

                Console.Clear();
                Console.WriteLine("Produto adicionado com sucesso ao estoque.");
                Console.WriteLine("");
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu inicial.");
                Console.ReadKey();
            }

            static void VenderProduto()
            {
                Console.WriteLine();
                if (produtos.Count > 0)
                {
                    Console.WriteLine(">>>>>> Produtos disponíveis para vender <<<<<<");
                    Console.WriteLine("");
                    foreach (var p in produtos)
                    {
                        Console.WriteLine(p.ObterTexto());
                    }
                    Console.WriteLine("");
                    Console.WriteLine("Selecione um produto que deseja vender:");
                    string p_vendido = Console.ReadLine()!;

                    if (produtos.Exists(nome => nome.Nome == p_vendido))
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Digite a quantidade desse produto que deseja vender:");
                        int quant_vendida = int.Parse(Console.ReadLine()!);

                        if (novoproduto != null && novoproduto.Estoque >= quant_vendida)
                        {
                            novoproduto.Estoque -= quant_vendida;
                            novoproduto.Quant_Vendida += quant_vendida;

                            Console.Clear();
                            Console.WriteLine($"Venda realizada com sucesso. \n\n{quant_vendida} unidades de {novoproduto.Nome} vendidas.");
                            Console.WriteLine("");
                            Console.WriteLine("Pressione qualquer tecla para voltar ao menu inicial.");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Quantidade insuficiente para a venda.");
                            Console.WriteLine("");
                            Console.WriteLine("Pressione qualquer tecla para voltar ao menu inicial.");
                            Console.ReadKey();
                        }
                    }

                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Nenhum produto cadastrado no estoque possui este nome.");
                        Console.WriteLine("Pressione qualquer tecla para voltar ao menu inicial.");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("Não é possível vender um produto pois não há nenhum cadastrado no estoque.");
                    Console.WriteLine("Pressione qualquer tecla para voltar ao menu inicial.");
                    Console.ReadKey();
                }
            }

            static void ListarProduto()
            {
                if (produtos.Count > 0)
                {
                    Console.WriteLine(">>>>>> Estoque de produtos: <<<<<<");

                    foreach (var p in produtos)
                    {
                        Console.WriteLine(p.ObterTexto());
                    }
                    Console.WriteLine("");
                    Console.WriteLine("Pressione qualquer tecla para voltar ao menu inicial.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("Ainda não nenhum produto cadastrado no sistema.");
                    Console.WriteLine("Pressione qualquer tecla para voltar ao menu inicial.");
                    Console.ReadKey();
                }
            }

        }
    }
}
