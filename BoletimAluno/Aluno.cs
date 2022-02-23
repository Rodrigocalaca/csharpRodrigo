namespace RelatorioAlunos
{
    class Aluno
    {
        private readonly string _nome;
        private string _matricula;
        private double nota1, nota2;

        public Aluno(string nome, double p1, double p2, string matricula)
        {
            _nome = nome;
            this.nota1 = p1;
            this.nota2 = p2;
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

        public double PrimeiraProva
        {
            get { return nota1; }
        }

        public double SegundaProva
        {
            get { return nota2; }
        }

        public double Media => (nota1 + nota2) / 2;
        

        public bool Aprovado
        {
            get
            {
                return Media >= 6;
            }
        }
        public void ImprimirAlunos()
        {
            List<Aluno> alunos = new();
            Console.WriteLine();
            Console.WriteLine("Alunos aprovados");
            Console.WriteLine("================================================");
            Console.WriteLine();

            foreach (Aluno a in alunos)
            {
                if (a.Aprovado)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Matricula: {a.Matricula} - Aluno: {a.Nome} - Media: {a.Media}");
                    Console.WriteLine();
                }
            }

            Console.WriteLine();
            Console.WriteLine("Alunos Reprovados");
            Console.WriteLine("================================================");
            Console.WriteLine();
            foreach (Aluno a in alunos)
            {
                if (!a.Aprovado)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Matricula: {a.Matricula} - Aluno: {a.Nome} - Media: {a.Media}");
                    Console.WriteLine();
                }
            }
        }
    }
}