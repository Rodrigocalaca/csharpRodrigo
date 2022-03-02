using RelatorioAlunos;

namespace boletimAluno
{
    public interface IAluno
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
        public static void ImprimirResumoAluno(Aluno aluno, bool tipoDeEnsino)
        {
            if (tipoDeEnsino)
            {
                var ImprimirAlunoBasico = aluno as AlunoEnsinoBasico;
                if (aluno is AlunoEnsinoBasico)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Matricula: {aluno.Matricula} - Aluno: {aluno.Nome} - Media: {aluno.Media}\n" +
                        $"Serie: {ImprimirAlunoBasico?.Serie}º Ano - Responsavel: {ImprimirAlunoBasico?.Responsavel}");
                    Console.WriteLine();
                }
            }
            if (!tipoDeEnsino)
            {
                var ImprimirAlunoSuperior = aluno as AlunoEnsinoSuperior;
                if (aluno is AlunoEnsinoSuperior)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Matricula: {aluno.Matricula} - Aluno: {aluno.Nome} - Media: {aluno.Media}\n" +
                        $"Turno das aulas: {ImprimirAlunoSuperior?.TurnoDasAulas} - Periodo: {ImprimirAlunoSuperior?.Periodo}º");
                    Console.WriteLine();
                }

            }
        }
        public static void ImprimirMenuAprovacao(string texto)
        {
            Console.WriteLine();
            Console.WriteLine($"{texto}");
            Console.WriteLine("================================================");
            Console.WriteLine();
        }
        public static IEnumerable<Aluno> BuscaMatricula(string matricula, List<Aluno> alunosT)
        {
            IEnumerable<Aluno> alunoBuscado =
               from aluno in alunosT
               where aluno.Matricula == matricula
               select aluno;

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
    }
}