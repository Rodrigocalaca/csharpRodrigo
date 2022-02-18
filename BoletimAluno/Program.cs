using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelatorioAlunos
{
    class program
    {
        static void Main(string[] args)
        {
            List<Aluno> alunos = new List<Aluno>();
            string continuar = "SIM";
            string opcao = ObterOpcaoMenu();


            while (true)
            {
                if (continuar.ToUpper() != "SIM" && continuar.ToUpper() != "NAO")
                {
                    Console.WriteLine("Insira uma respost valida: ");
                    Console.WriteLine("Deseja inserir outro aluno? [SIM/NAO]");
                    continuar = Console.ReadLine();

                }
                else if (continuar.ToUpper() == "SIM" || continuar.ToUpper() == "NAO")
                {

                    if (opcao == "1")
                    {
                        Console.WriteLine("Digite o nome: ");
                        string nome = Console.ReadLine();
                        Console.WriteLine("Nota 1: ");
                        double p1 = Double.Parse(Console.ReadLine());
                        Console.WriteLine("Nota 2: ");
                        double p2 = Double.Parse(Console.ReadLine());

                        Aluno novo = new Aluno(nome, p1, p2);
                        alunos.Add(novo);

                        Console.WriteLine("Deseja inserir outro aluno? [SIM/NAO]");
                        continuar = Console.ReadLine();
                        if (continuar.ToUpper() == "NAO")
                        {
                            opcao = ObterOpcaoMenu();

                        }
                        else if (continuar.ToUpper() == "SIM")
                        {
                            continue;
                        }

                    }
                    else if(opcao == "2")
                    {

                        Console.WriteLine();
                        Console.WriteLine("Alunos aprovados");
                        Console.WriteLine("================================================");
                        Console.WriteLine();

                        foreach (Aluno a in alunos)
                        {
                            if (a.Aprovado)
                            {
                                Console.WriteLine("Aluno: {0} - Media: {1}", a.Nome, a.Media);
                                Console.WriteLine();
                            }
                        }

                        Console.WriteLine();
                        Console.WriteLine("Alunos Reprovados");
                        Console.WriteLine("================================================");
                        Console.WriteLine();
                        foreach (Aluno a in alunos)
                        {
                            if (!a.Aprovado)
                            {
                                Console.WriteLine("Aluno: {0} - Media: {1}", a.Nome, a.Media);
                                Console.WriteLine();
                            }
                        }
                        Console.WriteLine("Deseja realizar outra operação? [SIM/NAO]");
                        continuar = Console.ReadLine();

                        if (continuar.ToUpper() == "SIM")
                        {
                            opcao = ObterOpcaoMenu();
                        }
                        else if (continuar.ToUpper() == "NAO")
                        {
                            Console.WriteLine("Finalizando o processo...");
                            break;
                        }
                    }
                    else if(opcao == "3")
                    {
                        Console.WriteLine("Insira o nome do aluno que deseja excluir: ");
                        string tirarAluno = Console.ReadLine();

                        foreach(Aluno a in alunos)
                        {
                            if(a.Nome == tirarAluno)
                            {
                                alunos.Remove(a);

                            }
                            else
                            {
                                Console.WriteLine("Aluno não encontrado");
                            }
                            Console.WriteLine("Deseja excluir mais um? [SIM/NAO]");
                            string teste = Console.ReadLine();
                            if (teste.ToUpper() != "SIM" && teste.ToUpper() != "NAO")
                            {
                                Console.WriteLine("Insira uma respost valida: ");
                                Console.WriteLine("Deseja excluir mais um? [SIM/NAO]");
                                teste = Console.ReadLine();

                            }
                            else if(teste.ToUpper() == "SIM")
                            {
                                Console.WriteLine("Insira o nome do aluno que deseja excluir: ");
                                tirarAluno = Console.ReadLine();
                            }
                            else if(teste.ToUpper() == "NAO")
                            {
                                opcao = ObterOpcaoMenu();
                            }
                        }

                    }
                    else if(opcao.ToUpper() == "X")
                    {
                        Console.WriteLine("Finalizando o processo...");
                        break;   
                    }
                }
            }
        }
        private static string ObterOpcaoMenu()
        {
            while (true)
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine("Digite a opcao desejada: ");
                Console.WriteLine("[1] - Adicionar aluno");
                Console.WriteLine("[2] - Consulta geral da turma");
                Console.WriteLine("[3] - Excluir aluno");
                Console.WriteLine("[X] - Sair");
                Console.WriteLine("----------------------------------");

                string opcaoMenu = Console.ReadLine();

                if (opcaoMenu == "1" || opcaoMenu == "2" || opcaoMenu == "3" || opcaoMenu.ToUpper() == "X")
                {
                    return opcaoMenu;
                    break;
                }
                else
                {
                    Console.WriteLine("Insira uma opcao valida");
                }
            }
        }
    }
}