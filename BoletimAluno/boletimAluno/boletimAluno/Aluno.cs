using boletimAluno;

namespace RelatorioAlunos
{
    public class Aluno : IAluno
    {
        private readonly string _nome;
        private readonly string _matricula;
        private readonly double nota1;
        private readonly double nota2;



        public Aluno()
        {

        }

        public Aluno(string nome, double p1, double p2, string matricula)
        {
            _nome = nome;
            this.nota1 = p1;
            this.nota2 = p2;
            this._matricula = matricula;

        }

        public string Nome => _nome;

        public string Matricula => _matricula;

        public double PrimeiraProva => nota1;

        public double SegundaProva => nota2;

        public double Media => (nota1 + nota2) / 2;

        public bool Aprovado => Media >= 6;
    }
}