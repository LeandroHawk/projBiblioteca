using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal class Livros
    {
        private List<Livro> acervo;

        // Construtor da classe Livros
        public Livros()
        {
            acervo = new List<Livro>();
        }

        // Método para adicionar um livro ao acervo
        public void Adicionar(Livro livro)
        {
            if (acervo.Exists(l => l.Isbn == livro.Isbn))
            {
                Console.WriteLine("O livro com esse ISBN já está no acervo.");
            }
            else
            {
                acervo.Add(livro);
                Console.WriteLine("Livro adicionado ao acervo com sucesso.");
            }
        }

        // Método para pesquisar um livro no acervo pelo ISBN
        public Livro Pesquisar(int isbn)
        {
            return acervo.Find(l => l.Isbn == isbn);
        }

    }
}
