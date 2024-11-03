using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Livros biblioteca = new Livros();
            int opcao;

            do
            {
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("0. Sair");
                Console.WriteLine("1. Adicionar livro");
                Console.WriteLine("2. Pesquisar livro (sintético)");
                Console.WriteLine("3. Pesquisar livro (analítico)");
                Console.WriteLine("4. Adicionar exemplar");
                Console.WriteLine("5. Registrar empréstimo");
                Console.WriteLine("6. Registrar devolução");
                Console.Write("Opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 0:
                        Console.WriteLine("Saindo...");
                        break;
                    case 1:
                        AdicionarLivro(biblioteca);
                        break;
                    case 2:
                        PesquisarLivroSintetico(biblioteca);
                        break;
                    case 3:
                        PesquisarLivroAnalitico(biblioteca);
                        break;
                    case 4:
                        AdicionarExemplar(biblioteca);
                        break;
                    case 5:
                        RegistrarEmprestimo(biblioteca);
                        break;
                    case 6:
                        RegistrarDevolucao(biblioteca);
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }

                Console.WriteLine(); // Adiciona uma linha em branco para melhor legibilidade
            } while (opcao != 0);
        }

        // Métodos para cada funcionalidade
        public static void AdicionarLivro(Livros biblioteca)
        {
            Console.WriteLine("Informe o ISBN do livro:");
            int isbn = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe o título do livro:");
            string titulo = Console.ReadLine();

            Console.WriteLine("Informe o autor do livro:");
            string autor = Console.ReadLine();

            Console.WriteLine("Informe a editora do livro:");
            string editora = Console.ReadLine();

            Livro livro = new Livro(isbn, titulo, autor, editora);
            biblioteca.Adicionar(livro);
        }

        public static void PesquisarLivroSintetico(Livros biblioteca)
        {
            Console.WriteLine("Informe o ISBN do livro para pesquisa:");
            int isbn = int.Parse(Console.ReadLine());

            Livro livro = biblioteca.Pesquisar(isbn);
            if (livro != null)
            {
                Console.WriteLine($"Título: {livro.Titulo}, Autor: {livro.Autor}, Editora: {livro.Editora}");
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }
        }

        public static void PesquisarLivroAnalitico(Livros biblioteca)
        {
            Console.WriteLine("Informe o ISBN do livro para pesquisa analítica:");
            int isbn = int.Parse(Console.ReadLine());

            Livro livro = biblioteca.Pesquisar(isbn);
            if (livro != null)
            {
                Console.WriteLine($"Título: {livro.Titulo}, Autor: {livro.Autor}, Editora: {livro.Editora}");
                Console.WriteLine($"Quantidade de exemplares: {livro.QtdeExemplares()}");
                Console.WriteLine($"Exemplares disponíveis: {livro.QtdeDisponiveis()}");
                Console.WriteLine($"Total de empréstimos: {livro.QtdeEmprestimos()}");
                Console.WriteLine($"Percentual de disponibilidade: {livro.PercDisponibilidade():F2}%");
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }
        }

        public static void AdicionarExemplar(Livros biblioteca)
        {
            Console.WriteLine("Informe o ISBN do livro para adicionar exemplar:");
            int isbn = int.Parse(Console.ReadLine());

            Livro livro = biblioteca.Pesquisar(isbn);
            if (livro != null)
            {
                Console.WriteLine("Informe o tombo do exemplar:");
                int tombo = int.Parse(Console.ReadLine());

                Exemplar exemplar = new Exemplar(tombo);
                livro.AdicionarExemplar(exemplar);
                Console.WriteLine("Exemplar adicionado com sucesso!");
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }
        }

        public static void RegistrarEmprestimo(Livros biblioteca)
        {
            Console.WriteLine("Informe o ISBN do livro para registrar empréstimo:");
            int isbn = int.Parse(Console.ReadLine());

            Livro livro = biblioteca.Pesquisar(isbn);
            if (livro != null)
            {
                foreach (var exemplar in livro.Exemplares)
                {
                    if (exemplar.Disponivel())
                    {
                        exemplar.Emprestar();
                        Console.WriteLine("Empréstimo registrado com sucesso!");
                        return;
                    }
                }
                Console.WriteLine("Nenhum exemplar disponível para empréstimo.");
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }
        }

        public static void RegistrarDevolucao(Livros biblioteca)
        {
            Console.WriteLine("Informe o ISBN do livro para registrar devolução:");
            int isbn = int.Parse(Console.ReadLine());

            Livro livro = biblioteca.Pesquisar(isbn);
            if (livro != null)
            {
                Console.WriteLine("Informe o tombo do exemplar para devolução:");
                int tombo = int.Parse(Console.ReadLine());

                Exemplar exemplar = livro.Exemplares.Find(e => e.Tombo == tombo);
                if (exemplar != null && !exemplar.Disponivel())
                {
                    exemplar.Devolver();
                    Console.WriteLine("Devolução registrada com sucesso!");
                }
                else
                {
                    Console.WriteLine("Exemplar não encontrado ou já está disponível.");
                }
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }
        }
    }
}
