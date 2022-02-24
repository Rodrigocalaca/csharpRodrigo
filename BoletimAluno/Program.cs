using System.Text.RegularExpressions;

namespace RelatorioAlunos
{
    class Program
    {
        static void Main()
        {
            List<Aluno> alunos = new();
            var opcaoMenu = ObtenhaOpcaoSelecionada().ToUpper();
            bool estaFinalizando = true;
            int validacaoNumero;



            while (estaFinalizando)
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
                        while (true) {
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


                        Aluno novoAluno = new(nomeAluno, nota1, nota2, matricula);
                        alunos.Add(novoAluno);


                        var continuar = ObtenhaMenuDeContinuacao().ToUpper();
                        switch (continuar)
                        {
                            case "1":
                                opcaoMenu = "1";
                                break;
                            case "2":
                                opcaoMenu = ObtenhaOpcaoSelecionada();
                                break;
                            case "X":
                                opcaoMenu = "X";
                                break;
                        }
                        break;
                    case "2":
                        if (alunos.Count == 0)
                        {
                            Console.WriteLine("Não há nenhum aluno cadastrado");
                            opcaoMenu = ObtenhaOpcaoSelecionada();
                        }
                        else
                        {
                            string texto = "Alunos Aprovados";
                            ImprimirMenuAprovacao(texto);
                            foreach (Aluno aluno in alunos)
                            {
                                if (aluno.Aprovado)
                                {
                                    ImprimirResumoAluno(aluno);
                                }
                            }
                            texto = "Alunos Reprovados";
                            ImprimirMenuAprovacao(texto);
                            foreach (Aluno aluno in alunos)
                            {
                                if (!aluno.Aprovado)
                                {
                                    ImprimirResumoAluno(aluno);
                                }
                            }
                            continuar = ObtenhaMenuDeContinuacao().ToUpper();
                            switch (continuar)
                            {
                                case "1":
                                    opcaoMenu = "2";
                                    break;
                                case "2":
                                    opcaoMenu = ObtenhaOpcaoSelecionada();
                                    break;
                                case "X":
                                    opcaoMenu = "X";
                                    break;
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
                            string? matriculaAPesquisar = Console.ReadLine();
                            IEnumerable<Aluno> alunoBuscado =
                                from alunoASerBuscado in alunos
                                where alunoASerBuscado.Matricula == matriculaAPesquisar
                                select alunoASerBuscado;

                            foreach (Aluno aluno in alunoBuscado)
                            {
                                ImprimirResumoAluno(aluno);
                                Console.WriteLine($"NOTAS\nPrimeria prova: {aluno.PrimeiraProva}\nSegunda prova: {aluno.SegundaProva}");
                            }



                            continuar = ObtenhaMenuDeContinuacao().ToUpper();
                            switch (continuar)
                            {
                                case "1":
                                    opcaoMenu = "3";
                                    break;
                                case "2":
                                    opcaoMenu = ObtenhaOpcaoSelecionada();
                                    break;
                                case "X":
                                    opcaoMenu = "X";
                                    break;
                            }
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
                            IEnumerable<Aluno> alunoBuscado =
                                from alunoASerBuscado in alunos
                                where alunoASerBuscado.Matricula == matriculaASerRetirada
                                select alunoASerBuscado;

                            if (!alunoBuscado.Any())
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
                        switch (continuar)
                        {
                            case "1":
                                opcaoMenu = "2";
                                break;
                            case "2":
                                opcaoMenu = ObtenhaOpcaoSelecionada();
                                break;
                            case "X":
                                opcaoMenu = "X";
                                break;
                        }
                        break;
                    case "X":
                        Console.WriteLine("Finalizando o processo...");
                        estaFinalizando = false;
                        break;

                }
            }
        }
        private static string ObtenhaOpcaoSelecionada()
        {
            while (true)
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine("Digite a opcao desejada: ");
                Console.WriteLine("[1] - Adicionar aluno");
                Console.WriteLine("[2] - Consulta geral da turma");
                Console.WriteLine("[3] - Buscar aluno");
                Console.WriteLine("[4] - Excluir aluno");
                Console.WriteLine("[X] - Sair");
                Console.WriteLine("----------------------------------");

                string? opcaoMenu = Console.ReadLine();

                if (opcaoMenu != null)
                {
                    if (opcaoMenu == "1" || opcaoMenu == "2" || opcaoMenu == "3" || opcaoMenu == "4" || opcaoMenu == "X" || opcaoMenu == "x")
                    {
                        return opcaoMenu;
                    }
                }
                else
                {
                    Console.WriteLine("Insira uma opcao valida\n");
                }
            }
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
        public static void ImprimirResumoAluno(Aluno aluno)
        {
            Console.WriteLine();
            Console.WriteLine($"Matricula: {aluno.Matricula} - Aluno: {aluno.Nome} - Media: {aluno.Media}");
            Console.WriteLine();
        }
        public static void ImprimirMenuAprovacao(string texto)
        {
            Console.WriteLine();
            Console.WriteLine($"{texto}");
            Console.WriteLine("================================================");
            Console.WriteLine();
        }
    }
}



/// Requisitos do projeto:
/// 1- Conversão de dados OK
/// 2- Upcast
/// 3- Downcast
/// 4- Generics OK
/// 5- linq OK