using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal class Livro
    {
        
        private int isbn;
        private string titulo;
        private string autor;
        private string editora;
        private List<Exemplar> exemplares;

        // Construtor da classe Livro
        public Livro(int isbn, string titulo, string autor, string editora)
        {
            this.isbn = isbn;
            this.titulo = titulo;
            this.autor = autor;
            this.editora = editora;
            this.exemplares = new List<Exemplar>();
        }

        // Método para adicionar um exemplar ao livro
        public void AdicionarExemplar(Exemplar exemplar)
        {
            exemplares.Add(exemplar);
        }

        // Método que retorna a quantidade total de exemplares do livro
        public int QtdeExemplares()
        {
            return exemplares.Count;
        }

        // Método que retorna a quantidade de exemplares disponíveis (não emprestados)
        public int QtdeDisponiveis()
        {
            int disponiveis = 0;
            foreach (var exemplar in exemplares)
            {
                if (exemplar.Disponivel())
                    disponiveis++;
            }
            return disponiveis;
        }

        // Método que retorna a quantidade total de empréstimos realizados para o livro
        public int QtdeEmprestimos()
        {
            int totalEmprestimos = 0;
            foreach (var exemplar in exemplares)
            {
                totalEmprestimos += exemplar.QtdeEmprestimos();
            }
            return totalEmprestimos;
        }

        // Método que calcula o percentual de disponibilidade dos exemplares do livro
        public double PercDisponibilidade()
        {
            int totalExemplares = QtdeExemplares();
            int disponiveis = QtdeDisponiveis();

            return totalExemplares > 0 ? (double)disponiveis / totalExemplares * 100 : 0;
        }

        // Propriedades públicas para acessar informações do livro (opcional)
        public int Isbn => isbn;
        public string Titulo => titulo;
        public string Autor => autor;
        public string Editora => editora;
        public List<Exemplar> Exemplares => exemplares;
    }
}
