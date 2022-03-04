using RelatorioAlunos;

namespace boletimAluno
{
    public static class MetodosDeAluno
    {
        public static string ObtenhaOpcaoMenuPrincipal()
        {

            Console.WriteLine("---------------MENU---------------");;
            Console.WriteLine("[1] - Adicionar aluno");
            Console.WriteLine("[2] - Consulta geral da turma");
            Console.WriteLine("[3] - Buscar aluno");
            Console.WriteLine("[4] - Excluir aluno");
            Console.WriteLine("[X] - Sair");
            Console.WriteLine("----------------------------------");

            string opcaoMenu = Console.ReadLine()?.Trim() ?? String.Empty;

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

                string validarResposta = Console.ReadLine()?.Trim() ?? String.Empty;

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
        public static void ImprimaResumoAluno(Aluno aluno, string tipoDeEnsino)
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
        public static void ImprimaCabecalhoAprovacao(string texto)
        {
            Console.WriteLine();
            Console.WriteLine($"{texto}");
            Console.WriteLine("================================================");
            Console.WriteLine();
        }
        public static IEnumerable<out T> MetodoDeBusca()
        {           
            IEnumerable<string> valorASerBuscado;
            
        }
        public static bool AchaMatricula(string matricula, List<Aluno> alunos)
        {
            if(alunos.Exists(aluno => aluno.Matricula == matricula)) { return true; }
            else { return false; }        
        }
        public static string SwitchCaseDoMenu(string opcaoDigitada, string opcaoDoMenu)
        {
            switch (opcaoDigitada)
            {
                case "1":
                    return opcaoDoMenu;
                case "2":
                    return ObtenhaOpcaoMenuPrincipal();
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
            MetodosDeAluno.ImprimaCabecalhoAprovacao(texto);
            foreach (Aluno aluno in alunos)
            {
                if (aluno.Aprovado)
                {
                    MetodosDeAluno.ImprimaResumoAluno(aluno, tipoDeEnsino);
                }
            }
            texto = "Alunos Reprovados";
            MetodosDeAluno.ImprimaCabecalhoAprovacao(texto);
            foreach (Aluno aluno in alunos)
            {
                if (!aluno.Aprovado)
                {
                    MetodosDeAluno.ImprimaResumoAluno(aluno, tipoDeEnsino);
                }
            }
        }
        public static string ImprimaMenuOpcaoDeEnsino()
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("[1] - Aluno Ensino Básico\n[2] - Aluno Ensino Superior");
            Console.WriteLine("---------------------------");
            string opcaoDoMenuDeEnsino = Console.ReadLine()?.Trim() ?? string.Empty;

            return opcaoDoMenuDeEnsino;
        }
        public static string PegaMatricula()
        {
            Console.Write("Digite a matricula: ");
            string matricula = Console.ReadLine()?.Trim() ?? string.Empty;

            return matricula;
        }

        public static string PegaNome()
        {
            Console.Write("Digite o nome: ");
            string nomeAluno = Console.ReadLine()?.Trim() ?? String.Empty;

            return nomeAluno;
        }

        public static string PegaSerie()
        {
            Console.Write("Série: ");
            string serie = Console.ReadLine()?.Trim() ?? string.Empty;

            return serie;
        }
        public static string PegaResponsavel()
        {
            Console.Write("Nome do responsável: ");
            string responsavel = Console.ReadLine()?.Trim() ?? string.Empty;

            return responsavel;
        }
        public static string PegaPeriodo()
        {
            Console.Write("Periodo de curso: Ex.: [1º Periodo/2º Periodo]: ");
            string periodo = Console.ReadLine()?.Trim() ?? string.Empty;

            return periodo;
        }
        public static string ConfereAlunos()
        {
            Console.WriteLine("Não há nenhum aluno cadastrado");
            string opcaoMenu = MetodosDeAluno.ObtenhaOpcaoMenuPrincipal();

            return opcaoMenu;
        }
        public static string CasoContinuar(string texto)
        {
            string continuar = MetodosDeAluno.ObtenhaMenuDeContinuacao().ToUpper();
            string opcaoMenu = MetodosDeAluno.SwitchCaseDoMenu(continuar, texto);

            return opcaoMenu;
        }
        public static double TryCatchDasNotas()
        {
            while (true)
            {
                try
                {
                    double nota = double.Parse(Console.ReadLine() ?? "");
                    return nota;
                }
                catch (Exception)
                {
                    Console.Write("Insira uma nota válida\nNota 2: ");
                }
            }
        }
        public static double PegaNotaValida(double nota, string texto)
        {
            while (nota < 0 || nota > 10)
            {
                Console.WriteLine("Insira uma nota válida");
                Console.Write($"{texto}: ");
                nota = double.Parse(Console.ReadLine() ?? "");
            }
            return nota;
        }

        public static List<Aluno> OrdenaAlunos(List<Aluno> alunos)
        {
            List<Aluno> alunosOrdenadosPorNota = alunos.OrderBy(aluno => aluno.Media).ToList();

            return alunosOrdenadosPorNota;
        }
    }
}