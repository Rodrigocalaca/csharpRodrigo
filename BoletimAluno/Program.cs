using boletimAluno;
using System.Text.RegularExpressions;

namespace RelatorioAlunos
{
    class Program
    {
        static void Main()
        {
            List<Aluno> alunos = new();
            int validacaoNumeroInteiro;

            Console.WriteLine("---------------------------");
            Console.WriteLine("[1] - Aluno Ensino Básico\n[2] - Aluno Ensino Superior");
            Console.WriteLine("---------------------------");
            string opcaoDoMenuDeEnsino = Console.ReadLine() ?? "";
            while (opcaoDoMenuDeEnsino != "1" || opcaoDoMenuDeEnsino != "2")
            {
                if (opcaoDoMenuDeEnsino == "1" || opcaoDoMenuDeEnsino == "2")
                {                  
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

            var opcaoMenu = MetodosDeAluno.ObtenhaOpcaoSelecionada().ToUpper();

            while (opcaoMenu.ToUpper() != "X")
            {
                switch (opcaoMenu)
                {
                    case "1":
                        Console.WriteLine("Digite a matricula: ");
                        string matricula = Console.ReadLine()?.Trim() ?? string.Empty;
                        while (!Int32.TryParse(matricula, out validacaoNumeroInteiro))
                        {
                            Console.WriteLine("A matricula precisa ser um número\nDigite a matricula: ");
                            matricula = Console.ReadLine()?.Trim() ?? string.Empty;
                        }
                        foreach (Aluno aluno in alunos)
                        {
                            while (aluno.Matricula == matricula)
                            {
                                Console.WriteLine("Essa matricula já foi cadastrada");
                                Console.WriteLine("Digite a matricula: ");
                                matricula = Console.ReadLine()?.Trim() ?? string.Empty;                               
                            }
                        }
                        while (matricula.Length < 1)
                        {
                            Console.WriteLine("Insira uma matricula válida");
                            Console.WriteLine("Digite a matricula: ");
                            matricula = Console.ReadLine()?.Trim() ?? string.Empty;
                        }

                        Console.WriteLine("Digite o nome: ");
                        string nomeAluno = Console.ReadLine()?.Trim() ?? "";
                        while (!Regex.IsMatch(nomeAluno, @"^[\p{L}\p{M}' \.\-]+$"))
                        {
                            Console.WriteLine("Esse nome é invalido");
                            Console.WriteLine("Digite o nome: ");
                            nomeAluno = Console.ReadLine()?.Trim() ?? "";
                        }
                        while (nomeAluno.Length < 1 || nomeAluno.Length > 100)
                        {
                            Console.WriteLine("Digite um nome válido");
                            Console.WriteLine("Digite o nome: ");
                            nomeAluno = Console.ReadLine()?.Trim() ?? "";
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
                            nota2 = double.Parse(Console.ReadLine()?.Trim() ?? "");

                        }
                        if (opcaoDoMenuDeEnsino == "1")
                        {
                            string? serie = "";
                            string? responsavel = "";
                            Console.WriteLine("Série: ");
                            serie = Console.ReadLine()?.Trim() ?? "";
                            while (!Int32.TryParse(serie, out validacaoNumeroInteiro))
                            {
                                Console.WriteLine("Insira uma série valida");
                                Console.WriteLine("Série: ");
                                serie = Console.ReadLine()?.Trim() ?? "";
                            }
                            int resultado = int.Parse(serie);
                            while (resultado >= 9 || resultado <= 1)
                            {
                                Console.WriteLine("Insira uma série valida");
                                Console.WriteLine("Série: ");
                                serie = Console.ReadLine()?.Trim() ?? "";
                                resultado = int.Parse(serie);
                            }
                            Console.WriteLine("Nome do responsável: ");
                            responsavel = Console.ReadLine() ?? "";
                            while (!Regex.IsMatch(responsavel, @"^[\p{L}\p{M}' \.\-]+$"))
                            {
                                Console.WriteLine("Esse nome é invalido");
                                Console.WriteLine("Digite o nome: ");
                                responsavel = Console.ReadLine()?.Trim() ?? "";
                                responsavel = responsavel.Trim();
                            }
                            AlunoEnsinoBasico novoAluno = new(nomeAluno, nota1, nota2, matricula, serie, responsavel);
                            alunos.Add(novoAluno);
                        }
                        else if (opcaoDoMenuDeEnsino == "2")
                        {
                            string? turnoDasAulas = "";
                            string? periodo = "";
                            while (true)
                            {
                                Console.WriteLine("Digite o periodo: [MATUTINO/NOTURNO]");
                                turnoDasAulas = Console.ReadLine()?.ToUpper() ?? "";
                                if (turnoDasAulas == "MATUTINO")
                                {
                                    Console.WriteLine($"Escolheu {turnoDasAulas}");
                                    break;
                                }
                                else if (turnoDasAulas == "NOTURNO")
                                {
                                    Console.WriteLine($"Escolheu {turnoDasAulas}");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Digite um valor valido");
                                }
                            }
                            Console.WriteLine("Periodo de curso: Ex.: [1º Periodo/2º Periodo]");
                            periodo = Console.ReadLine()?.Trim() ?? "";
                            while (!Int32.TryParse(periodo, out validacaoNumeroInteiro))
                            {
                                Console.WriteLine("Insira uma Periodo valido");
                                Console.WriteLine("Periodo: ");
                                periodo = Console.ReadLine() ?? "";
                            }
                            AlunoEnsinoSuperior novoAluno = new(nomeAluno, nota1, nota2, matricula, turnoDasAulas, periodo);
                            alunos.Add(novoAluno);
                        }

                        var continuar = MetodosDeAluno.ObtenhaMenuDeContinuacao().ToUpper();
                        opcaoMenu = MetodosDeAluno.SwitchCaseDoMenu(continuar, "1");
                        break;
                    case "2":
                        if (alunos.Count == 0)
                        {
                            Console.WriteLine("Não há nenhum aluno cadastrado");
                            opcaoMenu = MetodosDeAluno.ObtenhaOpcaoSelecionada();
                        }
                        else
                        {

                            if (opcaoDoMenuDeEnsino == "1")
                            {
                                MetodosDeAluno.ImprimaConsultaGeralDaTurma(alunos, opcaoDoMenuDeEnsino);
                                continuar = MetodosDeAluno.ObtenhaMenuDeContinuacao().ToUpper();
                                opcaoMenu = MetodosDeAluno.SwitchCaseDoMenu(continuar, "2");
                            }
                            else if (opcaoDoMenuDeEnsino == "2")
                            {
                                MetodosDeAluno.ImprimaConsultaGeralDaTurma(alunos, opcaoDoMenuDeEnsino);
                                continuar = MetodosDeAluno.ObtenhaMenuDeContinuacao().ToUpper();
                                opcaoMenu = MetodosDeAluno.SwitchCaseDoMenu(continuar, "2");
                            }
                        }
                        break;
                    case "3":
                        if (alunos.Count == 0)
                        {
                            Console.WriteLine("Não há nenhum aluno cadastrado");
                            opcaoMenu = MetodosDeAluno.ObtenhaOpcaoSelecionada();
                        }
                        else
                        {
                            Console.WriteLine("Digite a matricula do aluno que deseja buscar: ");
                            string? matriculaAPesquisar = Console.ReadLine() ?? "";
                            


                            foreach (Aluno aluno in MetodosDeAluno.BuscaMatricula(matriculaAPesquisar, alunos))
                            {
                                MetodosDeAluno.ImprimirResumoAluno(aluno, opcaoDoMenuDeEnsino);
                                Console.WriteLine($"NOTAS\nPrimeria prova: {aluno.PrimeiraProva}\nSegunda prova: {aluno.SegundaProva}");
                            }
                            continuar = MetodosDeAluno.ObtenhaMenuDeContinuacao().ToUpper();
                            opcaoMenu = MetodosDeAluno.SwitchCaseDoMenu(continuar, "3");
                        }
                        break;
                    case "4":
                        if (alunos.Count == 0)
                        {
                            Console.WriteLine("Não há nenhum aluno cadastrado");
                            opcaoMenu = MetodosDeAluno.ObtenhaOpcaoSelecionada();
                        }
                        else
                        {
                            Console.WriteLine("Digite a matricula do aluno que deseja remover: ");
                            string matriculaASerRetirada = Console.ReadLine() ?? "";


                            if (!MetodosDeAluno.BuscaMatricula(matriculaASerRetirada, alunos).Any())
                            {
                                Console.WriteLine("O aluno não foi encontrado");
                            }
                            else
                            {
                                alunos.RemoveAll(aluno => aluno.Matricula == matriculaASerRetirada);
                                Console.WriteLine("O aluno foi excluido com sucesso");
                            }
                        }
                        continuar = MetodosDeAluno.ObtenhaMenuDeContinuacao().ToUpper();
                        opcaoMenu = MetodosDeAluno.SwitchCaseDoMenu(continuar, "4");
                        break;
                    default:
                        opcaoMenu = MetodosDeAluno.ObtenhaOpcaoSelecionada();
                        break;
                }
            }
            if(opcaoMenu.ToUpper() == "X")
            {
                Console.WriteLine("Finalizando a aplicacao");
            }
        }       
    }
}

/// refatorar o codigo, usando melhor o DONT REPET YOURSELF
/// usar mais linq's, upcast e downcast
/// estudar sobre boxing e unboxing
