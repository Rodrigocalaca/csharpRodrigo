namespace RelatorioAlunos
{
    class Aluno
    {
        private readonly string _nome;
        private string _matricula;
        private double p1, p2;

        public Aluno(string nome, double p1, double p2, string matricula)
        {
            _nome = nome;
            this.p1 = p1;
            this.p2 = p2;
            this._matricula = matricula;
        }

        public string Nome { get; }

        public string Matricula
        {
            get { return _matricula; }
        }

        public double PrimeiraProva
        {
            get { return p1; }
        }

        public double SegundaProva
        {
            get { return p2; }
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