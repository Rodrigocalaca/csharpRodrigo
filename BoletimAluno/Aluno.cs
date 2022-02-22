using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RelatorioAlunos
{
    class Aluno
    {
        private string _nome, _matricula;
        private double p1, p2;

        public Aluno(string nome, double p1, double p2, string matricula)
        {
            this._nome = nome;
            this.p1 = p1;
            this.p2 = p2;
            this._matricula = matricula;
        }


        public string Nome
        {
            get { return _nome; }
        }

        public string Matricula
        {
            get { return _matricula; }
        }

        public double Media => (p1 + p2) / 2;
        

        public bool Aprovado
        {
            get
            {
                return Media >= 6;
            }
        }
    }
}