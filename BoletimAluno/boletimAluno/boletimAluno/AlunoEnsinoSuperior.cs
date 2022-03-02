namespace RelatorioAlunos
{
    public class AlunoEnsinoSuperior : Aluno
    {
        public string? TurnoDasAulas { get; set; }

        public string? Periodo { get; set; }

        public AlunoEnsinoSuperior(string nome, double p1, double p2, string matricula, string turnoDasAulas, string periodo) : base(nome, p1, p2, matricula)
        {
            TurnoDasAulas = turnoDasAulas;

            Periodo = periodo;

        }
    }
}