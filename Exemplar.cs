using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal class Exemplar
    {
        private int tombo;
        private List<Emprestimo> emprestimos;

        // Construtor da classe Exemplar
        public Exemplar(int tombo)
        {
            this.tombo = tombo;
            this.emprestimos = new List<Emprestimo>();
        }

        // Método para emprestar o exemplar
        public bool Emprestar()
        {
            if (Disponivel())
            {
                emprestimos.Add(new Emprestimo(DateTime.Now));
                return true;
            }
            return false; // Retorna false se o exemplar não estiver disponível
        }

        // Método para devolver o exemplar
        public bool Devolver()
        {
            foreach (var emprestimo in emprestimos)
            {
                if (emprestimo.DtDevolucao == default(DateTime)) // Verifica se o empréstimo ainda não foi devolvido
                {
                    emprestimo.DtDevolucao = DateTime.Now;
                    return true;
                }
            }
            return false; // Retorna false se não houver empréstimo ativo para devolver
        }

        // Método que verifica se o exemplar está disponível para empréstimo
        public bool Disponivel()
        {
            // O exemplar está disponível se não houver empréstimos ou se o último empréstimo foi devolvido
            return emprestimos.Count == 0 || emprestimos[emprestimos.Count - 1].DtDevolucao != default(DateTime);
        }

        // Método que retorna a quantidade de vezes que o exemplar foi emprestado
        public int QtdeEmprestimos()
        {
            return emprestimos.Count;
        }

        // Propriedade para acessar o tombo do exemplar
        public int Tombo => tombo;
    }
}
