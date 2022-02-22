namespace RelatorioAlunos
{
    class Program
    {
        static void Main()
        {
            List<Aluno> alunos = new();
            var opcao = ObtenhaOpcaoSelecionada();
            bool estaFinalizando = true;



            while (estaFinalizando)
            {
                switch (opcao)
                {
                    case "1":
                        Console.WriteLine("Digite a matricula: ");
                        string? matricula = Console.ReadLine();
                        foreach(Aluno aluno in alunos)
                        {
                            if(matricula == aluno.Matricula)
                            {
                                Console.WriteLine("Essa matricula já foi inserida. Tente novamente");
                                Console.WriteLine("Digite a matricula: ");
                                matricula = Console.ReadLine();

                            }
                            else
                            {
                                matricula = matricula.Trim();
                            }
                        }
                        Console.WriteLine("Digite o nome: ");
                        string? nomeAluno = Console.ReadLine();
                        Console.WriteLine("Nota 1: ");
                        string? s = Console.ReadLine();
                        double primeiraProva = double.Parse(s);
                        Console.WriteLine("Nota 2: ");
                        string? s1 = Console.ReadLine();
                        double segundaProva = double.Parse(s1);

                        Aluno novo = new(nomeAluno, primeiraProva, segundaProva, matricula);
                        alunos.Add(novo);

                        var continuar = obterValidacaoResposta().ToUpper();
                        switch (continuar)
                        {
                            case "1":
                                opcao = "1";
                                break;
                            case "2":
                                opcao = ObtenhaOpcaoSelecionada();
                                break;
                            case "X":
                                opcao = "X";
                                break;
                        }
                        break;
                    case "2":
                        if (alunos.Count == 0)
                        {
                            Console.WriteLine("Não há nenhum aluno cadastrado");
                            opcao = ObtenhaOpcaoSelecionada();
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Alunos aprovados");
                            Console.WriteLine("================================================");
                            Console.WriteLine();

                            foreach (Aluno a in alunos)
                            {
                                if (a.Aprovado)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine($"Matricula: {a.Matricula} - Aluno: {a.Nome} - Media: {a.Media}");
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
                                    Console.WriteLine();
                                    Console.WriteLine($"Matricula: {a.Matricula} - Aluno: {a.Nome} - Media: {a.Media}");
                                    Console.WriteLine();
                                }
                            }
                            continuar = obterValidacaoResposta().ToUpper();
                            switch (continuar)
                            {
                                case "1":
                                    opcao = "2";
                                    break;
                                case "2":
                                    opcao = ObtenhaOpcaoSelecionada();
                                    break;
                                case "X":
                                    opcao = "X";
                                    break;
                            }
                        }
                        break;
                    case "3":
                        if (alunos.Count == 0)
                        {
                            Console.WriteLine("Não há nenhum aluno cadastrado");
                            opcao = ObtenhaOpcaoSelecionada();
                        }
                        else
                        {
                            Console.WriteLine("Digite a matricula do aluno que deseja buscar: ");
                            string? v = Console.ReadLine();
                            string matriculaAPesquisar = v;
                            // bool matriculaFoiLocalizada = alunos.Find(a => a.m)
                            foreach (Aluno aluno in alunos)
                            {
                                if (aluno.Matricula == matriculaAPesquisar)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine($"Matricula: {aluno.Matricula} - Aluno: {aluno.Nome} - Media: {aluno.Media}");
                                    Console.WriteLine();
                                    Console.WriteLine($"As notas são:\nP1: {aluno.PrimeiraProva}\nP2: {aluno.SegundaProva}");
                                }
                                else
                                {
                                    Console.WriteLine("Aluno não encontrado");
                                }
                            }
                            continuar = obterValidacaoResposta().ToUpper();
                            switch (continuar)
                            {
                                case "1":
                                    opcao = "3";
                                    break;
                                case "2":
                                    opcao = ObtenhaOpcaoSelecionada();
                                    break;
                                case "X":
                                    opcao = "X";
                                    break;
                            }
                        }

                        break;
                    case "4":
                        if (alunos.Count == 0)
                        {
                            Console.WriteLine("Não há nenhum aluno cadastrado");
                            opcao = ObtenhaOpcaoSelecionada();
                        }
                        else
                        {
                            Console.WriteLine("Digite a matricula do aluno que deseja remover: ");
                            string? v = Console.ReadLine();
                            string tirarAluno = v;
                            foreach (Aluno aluno in alunos.ToArray())
                            {                               
                                if (aluno.Matricula == tirarAluno)
                                {
                                    alunos.RemoveAll(aluno => aluno.Matricula.Equals(tirarAluno));
                                    Console.WriteLine();
                                    Console.WriteLine("Alunos aprovados");
                                    Console.WriteLine("================================================");
                                    Console.WriteLine();

                                    foreach (Aluno a in alunos)
                                    {
                                        if (a.Aprovado)
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine($"Matricula: {aluno.Matricula} - Aluno: {aluno.Nome} - Media: {aluno.Media}");
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
                                            Console.WriteLine();
                                            Console.WriteLine($"Matricula: {aluno.Matricula} - Aluno: {aluno.Nome} - Media: {aluno.Media}");
                                            Console.WriteLine();
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Aluno não encontrado");
                                }
                                continuar = obterValidacaoResposta().ToUpper();
                                switch (continuar)
                                {
                                    case "1":
                                        opcao = "4";
                                        break;
                                    case "2":
                                        opcao = ObtenhaOpcaoSelecionada();
                                        break;
                                    case "X":
                                        opcao = "X";
                                        break;
                                }
                            }
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

                string opcaoMenu = Console.ReadLine().ToUpper();

                if (opcaoMenu == "1" || opcaoMenu == "2" || opcaoMenu == "3" || opcaoMenu == "4" || opcaoMenu.ToUpper() == "X")
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

                string? testeValidarResposta = Console.ReadLine();
                string validarResposta = testeValidarResposta.ToUpper();

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
///  - pq caralhos tenho que colocar um "?" antes dos console.readline
///  - colocar mais linq's pra fazer as coisas
///  



