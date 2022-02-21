using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RelatorioAlunos
{
    class program
    {
        static void Main(string[] args)
        {
            List<Aluno> alunos = new List<Aluno>();
            string continuar = "SIM";
            string teste = "SIM";
            string opcao = ObterOpcaoMenu();
            


            while (true)
            {               
                if (continuar.ToUpper() == "SIM" || continuar.ToUpper() == "NAO")
                {

                    if (opcao == "1")
                    {
                        Console.WriteLine("Digite a matricula: ");
                        
                        int matricula = int.Parse(Console.ReadLine());
                        Console.WriteLine("Digite o nome: ");
                        string nome = Console.ReadLine();
                        Console.WriteLine("Nota 1: ");
                        double p1 = Double.Parse(Console.ReadLine());
                        Console.WriteLine("Nota 2: ");
                        double p2 = Double.Parse(Console.ReadLine());

                        Aluno novo = new Aluno(nome, p1, p2, matricula);
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
                        if (continuar.ToUpper() != "SIM" && continuar.ToUpper() != "NAO")
                        {
                            Console.WriteLine("Insira uma respost valida: ");
                            Console.WriteLine("Deseja inserir outro aluno? [SIM/NAO]");
                            continuar = Console.ReadLine();

                        }

                    }
                    else if (opcao == "2")
                    {

                        Console.WriteLine();
                        Console.WriteLine("Alunos aprovados");
                        Console.WriteLine("================================================");
                        Console.WriteLine();

                        foreach (Aluno a in alunos)
                        {
                            if (a.Aprovado)
                            {
                                Console.WriteLine("Matricula: {0} - Aluno: {1} - Media: {2}", a.Matricula, a.Nome, a.Media);
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
                                Console.WriteLine("Matricula: {0} - Aluno: {1} - Media: {2}", a.Matricula, a.Nome, a.Media);
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
                    if (opcao == "3")
                    {                        
                        
                        if (teste.ToUpper() == "SIM" || teste.ToUpper() == "NAO")
                        {
                            
                            if (teste.ToUpper() == "SIM")
                            {
                                
                                Console.WriteLine("Digite o nome do aluno que deseja remover: ");
                                string tirarAluno = Console.ReadLine();
                                foreach (Aluno aluno in alunos.ToArray())
                                {
                                    if (aluno.Nome != tirarAluno)
                                    {
                                        Console.WriteLine("Aluno não encontrado");
                                    }
                                    else if (aluno.Nome == tirarAluno)
                                    {
                                        alunos.RemoveAll(aluno => aluno.Nome.Equals(tirarAluno));
                                        Console.WriteLine();
                                        Console.WriteLine("Alunos aprovados");
                                        Console.WriteLine("================================================");
                                        Console.WriteLine();

                                        foreach (Aluno a in alunos)
                                        {
                                            if (a.Aprovado)
                                            {
                                                Console.WriteLine("Matricula: {0} - Aluno: {1} - Media: {2}", a.Matricula, a.Nome, a.Media);
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
                                                Console.WriteLine("Matricula: {0} - Aluno: {1} - Media: {2}", a.Matricula, a.Nome, a.Media);
                                                Console.WriteLine();
                                            }
                                        }
                                    }
                                    
                                }
                                Console.WriteLine("Deseja excluir mais um aluno? [SIM/NAO]");
                                teste = Console.ReadLine();
                                if (teste.ToUpper() == "NAO")
                                {
                                    opcao = ObterOpcaoMenu();
                                }
                            }                                                        
                        }
                        else
                        {
                            Console.WriteLine("Insira uma opcao valida");
                            Console.WriteLine("Deseja excluir mais um aluno? [SIM/NAO]");
                            teste = Console.ReadLine();
                            if (teste.ToUpper() == "NAO")
                            {
                                opcao = ObterOpcaoMenu();
                            }
                        }
                    }
                    else if (opcao.ToUpper() == "X")
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
                }
                else
                {
                    Console.WriteLine("Insira uma opcao valida");
                }
            }
        }
    }
}


/// to do list
///  - validação das entradas na opção 1
///  - invalidar a escolha da opção 3 quando não foi cadastrado nenhum aluno
///  - perguntar sobre o BDD 
///  - estudar a possibilidade de fazer uma função que reduz o número de testes feitos dentro do código



