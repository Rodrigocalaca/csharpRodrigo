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

            string opcaoDoMenuDeEnsino = MetodosDeAluno.ImprimaMenuOpcaoDeEnsino();
            while (opcaoDoMenuDeEnsino != "1" || opcaoDoMenuDeEnsino != "2")
            {
                if (opcaoDoMenuDeEnsino == "1" || opcaoDoMenuDeEnsino == "2")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Insira uma opcao Valida");
                    opcaoDoMenuDeEnsino = MetodosDeAluno.ImprimaMenuOpcaoDeEnsino();
                }
            }

            string opcaoMenu = MetodosDeAluno.ObtenhaOpcaoSelecionada().ToUpper();

            while (opcaoMenu.ToUpper() != "X")
            {
                switch (opcaoMenu)
                {
                    case "1":

                        string matricula = MetodosDeAluno.PegaMatricula();
                        while (!Int32.TryParse(matricula, out validacaoNumeroInteiro))
                        {
                            Console.Write("A matricula precisa ser um número");
                            matricula = MetodosDeAluno.PegaMatricula();
                        }
                        foreach (Aluno aluno in alunos)
                        {
                            while (aluno.Matricula == matricula)
                            {
                                Console.WriteLine("Essa matricula já foi cadastrada");
                                matricula = MetodosDeAluno.PegaMatricula();
                            }
                        }
                        while (matricula.Length < 1)
                        {
                            Console.WriteLine("Insira uma matricula válida");
                            matricula = MetodosDeAluno.PegaMatricula();
                        }

                        string nomeAluno = MetodosDeAluno.PegaNome();
                        while (!Regex.IsMatch(nomeAluno, @"^[\p{L}\p{M}' \.\-]+$") || nomeAluno.Length < 1 || nomeAluno.Length > 100)
                        {
                            Console.WriteLine("Esse nome é invalido");
                            nomeAluno = MetodosDeAluno.PegaNome();
                        }                  
                        Console.Write("Nota 1: ");
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
                                Console.Write("Insira uma nota válida\nNota 1: ");
                            }
                        }
                        while (nota1 < 0 || nota1 > 10)
                        {
                            Console.WriteLine("Insira uma nota válida");
                            Console.Write("Nota 1: ");
                            nota1 = double.Parse(Console.ReadLine() ?? "");

                        }
                        Console.Write("Nota 2: ");
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
                                Console.Write("Insira uma nota válida\nNota 2: ");
                            }
                        }
                        while (nota2 < 0 || nota2 > 10)
                        {
                            Console.WriteLine("Insira uma nota válida");
                            Console.Write("Nota 2: ");
                            nota2 = double.Parse(Console.ReadLine()?.Trim() ?? "");

                        }
                        if (opcaoDoMenuDeEnsino == "1")
                        {
                            string serie = MetodosDeAluno.PegaSerie();
                            while (!Int32.TryParse(serie, out validacaoNumeroInteiro))
                            {
                                Console.WriteLine("Insira uma série valida");
                                serie = MetodosDeAluno.PegaSerie();
                            }
                            int resultado = int.Parse(serie);
                            while (resultado >= 9 || resultado <= 1)
                            {
                                Console.WriteLine("Insira uma série valida");
                                serie = MetodosDeAluno.PegaSerie(); ;
                                resultado = int.Parse(serie);
                            }
                            string responsavel = MetodosDeAluno.PegaResponsavel();
                            while (!Regex.IsMatch(responsavel, @"^[\p{L}\p{M}' \.\-]+$") || responsavel.Length < 1 || responsavel.Length > 100)
                            {
                                Console.WriteLine("Esse nome é invalido");
                                responsavel = MetodosDeAluno.PegaResponsavel();
                            }
                            AlunoEnsinoBasico novoAluno = new(nomeAluno, nota1, nota2, matricula, serie, responsavel);
                            alunos.Add(novoAluno);
                        }
                        else if (opcaoDoMenuDeEnsino == "2")
                        {
                            string? turnoDasAulas = "";
                            while (true)
                            {
                                Console.Write("Digite o periodo: [MATUTINO/NOTURNO]");
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
                            string periodo = MetodosDeAluno.PegaPeriodo();
                            while (!Int32.TryParse(periodo, out validacaoNumeroInteiro))
                            {
                                Console.WriteLine("Insira uma Periodo valido");
                                periodo = MetodosDeAluno.PegaPeriodo();
                            }
                            AlunoEnsinoSuperior novoAluno = new(nomeAluno, nota1, nota2, matricula, turnoDasAulas, periodo);
                            alunos.Add(novoAluno);
                        }

                        opcaoMenu = MetodosDeAluno.CasoContinuar(opcaoMenu);
                        break;
                    case "2":
                        if (alunos.Count == 0)
                        {
                            opcaoMenu = MetodosDeAluno.ConfereAlunos();
                        }
                        else
                        {

                            if (opcaoDoMenuDeEnsino == "1")
                            {
                                MetodosDeAluno.ImprimaConsultaGeralDaTurma(alunos, opcaoDoMenuDeEnsino);
                                opcaoMenu = MetodosDeAluno.CasoContinuar(opcaoMenu);
                            }
                            else if (opcaoDoMenuDeEnsino == "2")
                            {
                                MetodosDeAluno.ImprimaConsultaGeralDaTurma(alunos, opcaoDoMenuDeEnsino);
                                opcaoMenu = MetodosDeAluno.CasoContinuar(opcaoMenu);
                            }
                        }
                        break;
                    case "3":
                        if (alunos.Count == 0)
                        {
                            opcaoMenu = MetodosDeAluno.ConfereAlunos();
                        }
                        else
                        {
                            Console.Write("Digite a matricula do aluno que deseja buscar: ");
                            string? matriculaAPesquisar = Console.ReadLine() ?? "";
                            if (!MetodosDeAluno.AchaMatricula(matriculaAPesquisar, alunos))
                            {
                                Console.WriteLine("O aluno não foi encontrado");
                            }
                            else
                            {                               
                                foreach (Aluno aluno in alunos.Where(aluno => aluno.Matricula == matriculaAPesquisar))
                                {
                                    MetodosDeAluno.ImprimirResumoAluno(aluno, opcaoDoMenuDeEnsino);
                                }
                            }
                            opcaoMenu = MetodosDeAluno.CasoContinuar(opcaoMenu);
                        }
                        break;
                    case "4":
                        if (alunos.Count == 0)
                        {
                            opcaoMenu = MetodosDeAluno.ConfereAlunos();
                        }
                        else
                        {
                            Console.Write("Digite a matricula do aluno que deseja remover: ");
                            string matriculaASerRetirada = Console.ReadLine()?.Trim() ?? String.Empty;


                            if (!MetodosDeAluno.AchaMatricula(matriculaASerRetirada, alunos))
                            {
                                Console.WriteLine("O aluno não foi encontrado");
                            }
                            else
                            {
                                alunos.RemoveAll(aluno => aluno.Matricula == matriculaASerRetirada);
                                Console.WriteLine("O aluno foi excluido com sucesso");
                            }
                        }
                        opcaoMenu = MetodosDeAluno.CasoContinuar(opcaoMenu);
                        break;
                    default:
                        opcaoMenu = MetodosDeAluno.ObtenhaOpcaoSelecionada();
                        break;
                }
            }
            if (opcaoMenu.ToUpper() == "X")
            {
                Console.WriteLine("Finalizando a aplicacao");
            }
        }        
    }
}

/// refatorar o codigo, usando melhor o DONT REPET YOURSELF
/// usar mais linq's, upcast e downcast
/// estudar sobre boxing e unboxing


/// Coisas a refatorar:
/// if(alunos.Count == 0)... No começo de cada switch case - OK
/// "digite o nome, digite a matricula" - OK
/// menu de opcao de ensino - OK
/// arrumar a questão do trycatch nas notas 