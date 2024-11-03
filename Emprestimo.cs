using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal class Emprestimo
    {
        private DateTime dtEmprestimo;
        private DateTime dtDevolucao;

        // Construtor da classe Emprestimo, inicializa com a data do empréstimo e deixa dtDevolucao como valor padrão (não devolvido)
        public Emprestimo(DateTime dtEmprestimo)
        {
            this.dtEmprestimo = dtEmprestimo;
            this.dtDevolucao = default(DateTime); // A devolução será definida quando o exemplar for devolvido
        }

        // Propriedade para acessar a data de empréstimo
        public DateTime DtEmprestimo
        {
            get { return dtEmprestimo; }
        }

        // Propriedade para acessar e definir a data de devolução
        public DateTime DtDevolucao
        {
            get { return dtDevolucao; }
            set { dtDevolucao = value; }
        }

        // Método que verifica se o empréstimo está em aberto (não devolvido)
        public bool EmAberto()
        {
            return dtDevolucao == default(DateTime);
        }
    }
}
