using RelatorioAlunos;

namespace boletimAluno
{
    public static class OperacoesDeMatricula
    {
        public static string ObtenhaMenuComparacao()
        {
            Console.WriteLine("------------------------");
            Console.WriteLine("O que deseja comparar?: ");
            Console.WriteLine("[1] - NOTA");
            Console.WriteLine("[2] - SERIE");
            Console.WriteLine("[3] - PERIODO");
            Console.WriteLine("[X] - Voltar ao menu");
            Console.WriteLine("------------------------");
            string comparacao = Console.ReadLine()?.Trim() ?? string.Empty;

            return comparacao;
        }
        public static T Comparar<T>(T dado1, T dado2) where T : IComparable<T>
        {
            if (dado1.CompareTo(dado2) > 0)
            {
                return dado1;
            }
            return dado2;
        }
        public static void ImprimaComparacao<T>(T dado1, T dado2, string nome1, string nome2) where T : IComparable<T>
        {
            var maior = Comparar(dado1, dado2);
            Console.Write($"O aluno mais avançado entre {nome1} e {nome2} é: ");
            if (maior.Equals(dado1))
            {
                Console.WriteLine(nome1);
            }
            else
            {
                Console.WriteLine(nome2);
            }
        }
        public static void FazAComparacao(string matricula1, string matricula2, string tipoDeEnsino, List<Aluno> alunos)
        {
            string? dado1 = "";
            string? dado2 = "";
            string? nome1 = "";
            string? nome2 = "";
            foreach (Aluno aluno in alunos.Where(aluno => aluno.Matricula == matricula1))
            {
                if (tipoDeEnsino == "1")
                {
                    AlunoEnsinoBasico pegarAlunoBasico1 = (AlunoEnsinoBasico)aluno;
                    dado1 = pegarAlunoBasico1.Serie;
                    nome1 = pegarAlunoBasico1.Nome;
                }
                else
                {
                    AlunoEnsinoSuperior pegarAlunoSuperior1 = (AlunoEnsinoSuperior)aluno;
                    dado1 = pegarAlunoSuperior1.Periodo;
                    nome1 = pegarAlunoSuperior1.Nome;
                }
            }
            foreach (Aluno aluno in alunos.Where(aluno => aluno.Matricula == matricula2))
            {
                if (tipoDeEnsino == "1")
                {
                    AlunoEnsinoBasico pegarAlunoBasico2 = (AlunoEnsinoBasico)aluno;
                    dado2 = pegarAlunoBasico2.Serie;
                    nome2 = pegarAlunoBasico2.Nome;
                }
                else
                {
                    AlunoEnsinoSuperior pegarAlunoSuperior2 = (AlunoEnsinoSuperior)aluno;
                    dado2 = pegarAlunoSuperior2.Periodo;
                    nome2 = pegarAlunoSuperior2.Nome;
                }
            }
            VerificarDadosIguais(dado1, dado2, nome1, nome2);
        }
        public static void EncontraMatriculaDosAlunos(List<Aluno> alunos, string opcaoDoMenuDeEnsino, string matriculaAPesquisar1, string matriculaAPesquisar2)
        {
            if (!MetodosDeAluno.AchaMatricula(matriculaAPesquisar1, alunos))
            {
                Console.WriteLine("O aluno não foi encontrado");
            }
            if (!MetodosDeAluno.AchaMatricula(matriculaAPesquisar2, alunos))
            {
                Console.WriteLine("O aluno não foi encontrado");
            }
            else
            {
                FazAComparacao(matriculaAPesquisar1, matriculaAPesquisar2, opcaoDoMenuDeEnsino, alunos);
            }
        }
        public static string PesquisaMatricula(List<Aluno> alunos)
        {
            string matriculaAPesquisar = MetodosDeAluno.ValidaMatricula(MetodosDeAluno.PegaMatricula());
            while (!MetodosDeAluno.AchaMatricula(matriculaAPesquisar, alunos))
            {
                matriculaAPesquisar = MetodosDeAluno.ValidaMatricula(MetodosDeAluno.PegaMatricula());
            }
            return matriculaAPesquisar;
        }
        public static void VerificarDadosIguais<T>(T dado1, T dado2, string nome1, string nome2) where T : IComparable<T>
        {
            if (dado1.Equals(dado2))
            {
                Console.WriteLine("Valores iguais");
            }
            else
            {
                ImprimaComparacao(dado1, dado2, nome1, nome2);
            }
        }
    }
}