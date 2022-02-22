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
            string continuar = "1";
            string opcao = ObterOpcaoMenu();
            


            while (true)
            {               
                if (continuar == "1" || continuar == "2")
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

                        continuar = obterValidacaoResposta();
                        if (continuar == "1")
                        {
                            opcao = "1";
                        }
                        else if (continuar == "2")
                        {
                            opcao = ObterOpcaoMenu();
                        }
                        else if(continuar.ToUpper() == "X")
                        {
                            break;
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
                        continuar = obterValidacaoResposta();
                        if (continuar == "1")
                        {
                            opcao = "2";
                        }
                        else if (continuar == "2")
                        {
                            opcao = ObterOpcaoMenu();
                        }
                        else if (continuar.ToUpper() == "X")
                        {
                            Console.WriteLine("Finalizando o processo...");
                            break;
                        }
                    }
                    else if (opcao == "3")
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
                        continuar = obterValidacaoResposta();
                        if (continuar == "1")
                        {
                            opcao = "3";
                        }
                        else if (continuar == "2")
                        {
                            opcao = ObterOpcaoMenu();
                        }
                        else if (continuar.ToUpper() == "X")
                        {
                            Console.WriteLine("Finalizando o processo...");
                            break;
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
        private static string obterValidacaoResposta()
        {
            while (true)
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine("Digite a opcao desejada");
                Console.WriteLine("[1] - Continuar o processo");
                Console.WriteLine("[2] - Ir para o menu");
                Console.WriteLine("[X] - Sair do programa");
                Console.WriteLine("----------------------------------");

                string validarResposta = Console.ReadLine();

                if (validarResposta == "1" || validarResposta == "2" || validarResposta.ToUpper() == "X")
                {
                    return validarResposta;
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



