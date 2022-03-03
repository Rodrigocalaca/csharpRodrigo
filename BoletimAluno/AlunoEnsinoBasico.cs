namespace RelatorioAlunos
{
    public class AlunoEnsinoBasico : Aluno
    {
        public string? Serie { get; set; }
        public string? Responsavel { get; set; }

        public AlunoEnsinoBasico(string nome, double p1, double p2, string matricula, string serie, string responsavel) : base(nome, p1, p2, matricula)
        {
            Serie = serie;

            Responsavel = responsavel;
        }
    }
}