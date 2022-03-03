using RelatorioAlunos;

namespace boletimAluno
{
    public static class MetodosDeAluno
    {
        public static string ObtenhaOpcaoSelecionada()
        {

            Console.WriteLine("----------------------------------");
            Console.WriteLine("Digite a opcao desejada: ");
            Console.WriteLine("[1] - Adicionar aluno");
            Console.WriteLine("[2] - Consulta geral da turma");
            Console.WriteLine("[3] - Buscar aluno");
            Console.WriteLine("[4] - Excluir aluno");
            Console.WriteLine("[X] - Sair");
            Console.WriteLine("----------------------------------");

            string? opcaoMenu = Console.ReadLine() ?? "";

            return opcaoMenu;
        }
        public static string ObtenhaMenuDeContinuacao()
        {
            while (true)
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine("Digite a opcao desejada");
                Console.WriteLine("[1] - Continuar o processo");
                Console.WriteLine("[2] - Ir para o menu");
                Console.WriteLine("[X] - Sair do programa");
                Console.WriteLine("----------------------------------");

                string? validarResposta = Console.ReadLine();

                if (validarResposta != null)
                {
                    if (validarResposta == "1" || validarResposta == "2" || validarResposta == "X" || validarResposta == "x")
                    {
                        return validarResposta;

                    }
                }
                else
                {
                    Console.WriteLine("Insira uma opcao valida\n");
                }
            }
        }
        public static void ImprimirResumoAluno(Aluno aluno, string tipoDeEnsino)
        {
            if (tipoDeEnsino == "1")
            {
                AlunoEnsinoBasico ImprimirAlunoBasico = (AlunoEnsinoBasico)aluno;
                Console.WriteLine();
                Console.WriteLine($"Matricula: {aluno.Matricula} - Aluno: {aluno.Nome} - Media: {aluno.Media}\n" +
                    $"Serie: {ImprimirAlunoBasico.Serie}º Ano - Responsavel: {ImprimirAlunoBasico.Responsavel}");
                Console.WriteLine();
            }
            else if(tipoDeEnsino == "2")
            {
                AlunoEnsinoSuperior ImprimirAlunoSuperior = (AlunoEnsinoSuperior)aluno;
                Console.WriteLine();
                Console.WriteLine($"Matricula: {aluno.Matricula} - Aluno: {aluno.Nome} - Media: {aluno.Media}\n" +
                    $"Turno das aulas: {ImprimirAlunoSuperior?.TurnoDasAulas} - Periodo: {ImprimirAlunoSuperior?.Periodo}º");
                Console.WriteLine();

            }
        }
        public static void ImprimirMenuAprovacao(string texto)
        {
            Console.WriteLine();
            Console.WriteLine($"{texto}");
            Console.WriteLine("================================================");
            Console.WriteLine();
        }
        public static Aluno BuscaMatricula(string? matricula, List<Aluno> alunos)
        {
            Aluno? alunoBuscado = alunos.FirstOrDefault(aluno => aluno.Matricula == matricula);

            return alunoBuscado;
        }
        public static string SwitchCaseDoMenu(string opcaoDigitada, string opcaoDoMenu)
        {
            switch (opcaoDigitada)
            {
                case "1":
                    return opcaoDoMenu;
                case "2":
                    return ObtenhaOpcaoSelecionada();
                case "X":
                    return "X";
                default:
                    Console.WriteLine("Insira uma opcao valida");
                    break;
            }
            return "0";
        }
        public static void ImprimaConsultaGeralDaTurma(List<Aluno> alunos, string tipoDeEnsino)
        {
            string texto = "Alunos Aprovados";
            MetodosDeAluno.ImprimirMenuAprovacao(texto);
            foreach (Aluno aluno in alunos)
            {
                if (aluno.Aprovado)
                {
                    MetodosDeAluno.ImprimirResumoAluno(aluno, tipoDeEnsino);
                }
            }
            texto = "Alunos Reprovados";
            MetodosDeAluno.ImprimirMenuAprovacao(texto);
            foreach (Aluno aluno in alunos)
            {
                if (!aluno.Aprovado)
                {
                    MetodosDeAluno.ImprimirResumoAluno(aluno, tipoDeEnsino);
                }
            }
        }
    }
}