using System.Text.RegularExpressions;

namespace RelatorioAlunos
{
    class Program
    {
        static void Main()
        {
            List<Aluno> alunos = new();
            var opcaoMenu = ObtenhaOpcaoSelecionada().ToUpper();
            int validacaoNumero;
            bool testeDeTurno = false;
            bool tipoDeEnsino = false;
            string? serie = "";
            string? responsavel = "";
            string? turnoDasAulas = "";
            string? periodo = "";

            Console.WriteLine("---------------------------");
            Console.WriteLine("[1] - Aluno Ensino Básico\n[2] - Aluno Ensino Superior");
            Console.WriteLine("---------------------------");
            string opcaoDoMenuDeEnsino = Console.ReadLine() ?? "";
            while (opcaoDoMenuDeEnsino != "1" || opcaoDoMenuDeEnsino != "2")
            {
                if (opcaoDoMenuDeEnsino == "1")
                {
                    tipoDeEnsino = true;
                    break;

                }
                else if (opcaoDoMenuDeEnsino == "2")
                {
                    tipoDeEnsino = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Insira uma opcao Valida");
                    Console.WriteLine("---------------------------");
                    Console.WriteLine("[1] - Aluno Ensino Básico\n[2] - Aluno Ensino Superior");
                    Console.WriteLine("---------------------------");
                    opcaoDoMenuDeEnsino = Console.ReadLine() ?? "";
                }
            }

            while (opcaoMenu.ToUpper() != "X")
            {
                switch (opcaoMenu)
                {
                    case "1":
                        

                        Console.WriteLine("Digite a matricula: ");
                        string matricula = Console.ReadLine() ?? "";
                        matricula = matricula.Trim();
                        bool testeMatricula = Int32.TryParse(matricula, out validacaoNumero);
                        while (!testeMatricula)
                        {
                            Console.WriteLine("A matricula precisa ser um número\nDigite a matricula: ");
                            matricula = Console.ReadLine() ?? "";
                            matricula = matricula.Trim();
                            testeMatricula = Int32.TryParse(matricula, out validacaoNumero);
                        }
                        foreach (Aluno aluno in alunos)
                        {
                            while (aluno.Matricula == matricula)
                            {
                                Console.WriteLine("Essa matricula já foi cadastrada");
                                Console.WriteLine("Digite a matricula: ");
                                matricula = Console.ReadLine() ?? "";
                                matricula = matricula.Trim();
                            }
                        }
                        while (matricula == null || matricula.Length < 1)
                        {
                            Console.WriteLine("Insira uma matricula válida");
                            Console.WriteLine("Digite a matricula: ");
                            matricula = Console.ReadLine() ?? "";
                            matricula = matricula.Trim();
                        }

                        Console.WriteLine("Digite o nome: ");
                        string nomeAluno = Console.ReadLine() ?? "";
                        nomeAluno = nomeAluno.Trim();
                        while (!Regex.IsMatch(nomeAluno, @"^[\p{L}\p{M}' \.\-]+$"))
                        {
                            Console.WriteLine("Esse nome é invalido");
                            Console.WriteLine("Digite o nome: ");
                            nomeAluno = Console.ReadLine() ?? "";
                            nomeAluno = nomeAluno.Trim();
                        }
                        while (nomeAluno == null || nomeAluno.Length < 1 || nomeAluno.Length > 100)
                        {
                            Console.WriteLine("Digite um nome válido");
                            Console.WriteLine("Digite o nome: ");
                            nomeAluno = Console.ReadLine() ?? "";
                            nomeAluno = nomeAluno.Trim();
                        }
                        Console.WriteLine("Nota 1: ");
                        double nota1 = 0;
                        while (true)
                        {
                            try
                            {
                                nota1 = double.Parse(Console.ReadLine() ?? "");
                                break;
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Insira uma nota válida\nNota 1: ");
                            }
                        }
                        while (nota1 < 0 || nota1 > 10)
                        {
                            Console.WriteLine("Insira uma nota válida");
                            Console.WriteLine("Nota 1: ");
                            nota1 = double.Parse(Console.ReadLine() ?? "");

                        }
                        Console.WriteLine("Nota 2: ");
                        double nota2 = 0;
                        while (true)
                        {
                            try
                            {
                                nota2 = double.Parse(Console.ReadLine() ?? "");
                                break;
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Insira uma nota válida\nNota 2: ");
                            }
                        }
                        while (nota2 < 0 || nota2 > 10)
                        {
                            Console.WriteLine("Insira uma nota válida");
                            Console.WriteLine("Nota 2: ");
                            nota2 = double.Parse(Console.ReadLine() ?? "");

                        }
                        if (tipoDeEnsino)
                        {
                            Console.WriteLine("Série: ");
                            serie = Console.ReadLine() ?? "";
                            bool testeSerie = Int32.TryParse(serie, out validacaoNumero);
                            while (!testeSerie)
                            {
                                Console.WriteLine("Insira uma série valida");
                                Console.WriteLine("Série: ");
                                serie = Console.ReadLine() ?? "";
                            }
                            Console.WriteLine("Nome do responsável: ");
                            responsavel = Console.ReadLine() ?? "";
                            while (!Regex.IsMatch(responsavel, @"^[\p{L}\p{M}' \.\-]+$"))
                            {
                                Console.WriteLine("Esse nome é invalido");
                                Console.WriteLine("Digite o nome: ");
                                responsavel = Console.ReadLine() ?? "";
                                responsavel = responsavel.Trim();
                            }
                            AlunoEnsinoBasico novoAluno = new(nomeAluno, nota1, nota2, matricula, serie, responsavel);
                            alunos.Add(novoAluno);
                        }
                        else if (!tipoDeEnsino)
                        {                      
                            while(!testeDeTurno)
                            {
                                Console.WriteLine("Digite o periodo: [MATUTINO/NOTURNO]");
                                turnoDasAulas = Console.ReadLine() ?? "";
                                turnoDasAulas = turnoDasAulas.ToUpper();
                                if (turnoDasAulas == "MATUTINO")
                                {
                                    Console.WriteLine($"Escolheu {turnoDasAulas}");
                                    testeDeTurno = true;
                                }
                                else if (turnoDasAulas == "NOTURNO")
                                {
                                    Console.WriteLine($"Escolheu {turnoDasAulas}");
                                    testeDeTurno = true;
                                }
                                else
                                {
                                    Console.WriteLine("Digite um valor valido");
                                    testeDeTurno = false;

                                }
                            }
                            testeDeTurno = false;
                            Console.WriteLine("Periodo de curso: Ex.: [1º Periodo/2º Periodo]");
                            periodo = Console.ReadLine() ?? "";
                            bool testePeriodo = Int32.TryParse(periodo, out validacaoNumero);
                            while (!testePeriodo)
                            {
                                Console.WriteLine("Insira uma Periodo valido");
                                Console.WriteLine("Periodo: ");
                                periodo = Console.ReadLine() ?? "";
                            }
                            AlunoEnsinoSuperior novoAluno = new(nomeAluno, nota1, nota2, matricula, turnoDasAulas, periodo);
                            alunos.Add(novoAluno);
                        }

                        var continuar = ObtenhaMenuDeContinuacao().ToUpper();
                        opcaoMenu = SwitchCaseDoMenu(continuar, "1");
                        break;
                    case "2":
                        if (alunos.Count == 0)
                        {
                            Console.WriteLine("Não há nenhum aluno cadastrado");
                            opcaoMenu = ObtenhaOpcaoSelecionada();
                        }
                        else
                        {

                            if (tipoDeEnsino)
                            {
                                string texto = "Alunos Aprovados";
                                ImprimirMenuAprovacao(texto);
                                foreach (Aluno aluno in alunos)
                                {
                                    if (aluno.Aprovado)
                                    {
                                        ImprimirResumoAluno(aluno, tipoDeEnsino);
                                    }
                                }
                                texto = "Alunos Reprovados";
                                ImprimirMenuAprovacao(texto);
                                foreach (Aluno aluno in alunos)
                                {
                                    if (!aluno.Aprovado)
                                    {
                                        ImprimirResumoAluno(aluno, tipoDeEnsino);
                                    }
                                }
                                continuar = ObtenhaMenuDeContinuacao().ToUpper();
                                opcaoMenu = SwitchCaseDoMenu(continuar, "2");
                            }
                            else if (!tipoDeEnsino)
                            {
                                string texto = "Alunos Aprovados";
                                ImprimirMenuAprovacao(texto);
                                foreach (Aluno aluno in alunos)
                                {
                                    if (aluno.Aprovado)
                                    {
                                        ImprimirResumoAluno(aluno, tipoDeEnsino);
                                    }
                                }
                                texto = "Alunos Reprovados";
                                ImprimirMenuAprovacao(texto);
                                foreach (Aluno aluno in alunos)
                                {
                                    if (!aluno.Aprovado)
                                    {
                                        ImprimirResumoAluno(aluno, tipoDeEnsino);
                                    }
                                }
                                continuar = ObtenhaMenuDeContinuacao().ToUpper();
                                opcaoMenu = SwitchCaseDoMenu(continuar, "2");
                            }
                        }
                        break;
                    case "3":
                        if (alunos.Count == 0)
                        {
                            Console.WriteLine("Não há nenhum aluno cadastrado");
                            opcaoMenu = ObtenhaOpcaoSelecionada();
                        }
                        else
                        {
                            Console.WriteLine("Digite a matricula do aluno que deseja buscar: ");
                            string? matriculaAPesquisar = Console.ReadLine() ?? "";


                            foreach (Aluno aluno in BuscaMatricula(matriculaAPesquisar, alunos))
                            {
                                ImprimirResumoAluno(aluno, tipoDeEnsino);
                                Console.WriteLine($"NOTAS\nPrimeria prova: {aluno.PrimeiraProva}\nSegunda prova: {aluno.SegundaProva}");
                            }
                            continuar = ObtenhaMenuDeContinuacao().ToUpper();
                            opcaoMenu = SwitchCaseDoMenu(continuar, "3");
                        }
                        break;
                    case "4":
                        if (alunos.Count == 0)
                        {
                            Console.WriteLine("Não há nenhum aluno cadastrado");
                            opcaoMenu = ObtenhaOpcaoSelecionada();
                        }
                        else
                        {
                            Console.WriteLine("Digite a matricula do aluno que deseja remover: ");
                            string matriculaASerRetirada = Console.ReadLine() ?? "";


                            if (!BuscaMatricula(matriculaASerRetirada, alunos).Any())
                            {
                                Console.WriteLine("O aluno não foi encontrado");
                            }
                            else
                            {
                                alunos.RemoveAll(aluno => aluno.Matricula == matriculaASerRetirada);
                                Console.WriteLine("O aluno foi excluido com sucesso");
                            }
                        }
                        continuar = ObtenhaMenuDeContinuacao().ToUpper();
                        opcaoMenu = SwitchCaseDoMenu(continuar, "4");
                        break;
                    default:
                        opcaoMenu = ObtenhaOpcaoSelecionada();
                        break;
                }
            }
        }
        private static string ObtenhaOpcaoSelecionada()
        {

            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Digite a opcao desejada: ");
            Console.WriteLine("[1] - Adicionar aluno");
            Console.WriteLine("[2] - Consulta dos alunos cadastrados");
            Console.WriteLine("[3] - Buscar aluno");
            Console.WriteLine("[4] - Excluir aluno");
            Console.WriteLine("[X] - Sair");
            Console.WriteLine("--------------------------------------");

            string? opcaoMenu = Console.ReadLine() ?? "";

            return opcaoMenu;
        }
        private static string ObtenhaMenuDeContinuacao()
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
                        $"Serie: {ImprimirAlunoBasico?.Serie} - Responsavel: {ImprimirAlunoBasico?.Responsavel}");
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
