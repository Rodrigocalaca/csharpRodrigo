namespace RelatorioAlunos
{
    class Program
    {
        static void Main()
        {
            List<Aluno> alunos = new();
            var opcaoMenu = ObtenhaOpcaoSelecionada().ToUpper();
            bool estaFinalizando = true;



            while (estaFinalizando)
            {
                switch (opcaoMenu)
                {
                    case "1":
                        Console.WriteLine("Digite a matricula: ");
                        string matricula = Console.ReadLine() ?? "";
                        foreach (Aluno aluno in alunos)
                        {
                            while (aluno.Matricula == matricula)
                            {
                                Console.WriteLine("Essa matricula já foi cadastrada");
                                Console.WriteLine("Digite a matricula: ");
                                matricula = Console.ReadLine() ?? "";
                            }
                        }
                        while (matricula == null || matricula.Length < 1)
                        {
                            Console.WriteLine("Insira uma matricula válida");
                            Console.WriteLine("Digite a matricula: ");
                            matricula = Console.ReadLine() ?? "";
                        }
                        Console.WriteLine("Digite o nome: ");
                        string nomeAluno = Console.ReadLine() ?? "";
                        while (nomeAluno == null || nomeAluno.Length < 1)
                        {
                            Console.WriteLine("Digite um nome válido");
                            Console.WriteLine("Digite o nome: ");
                            nomeAluno = Console.ReadLine() ?? "";

                        }
                        Console.WriteLine("Nota 1: ");
                        double nota1 = 0;
                        while(true){
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
                            Console.WriteLine();
                            Console.WriteLine("Alunos aprovados");
                            Console.WriteLine("================================================");
                            Console.WriteLine();

                            foreach (Aluno aluno in alunos)
                            {
                                if (aluno.Aprovado)
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
                            foreach (Aluno aluno in alunos)
                            {
                                if (!aluno.Aprovado)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine($"Matricula: {aluno.Matricula} - Aluno: {aluno.Nome} - Media: {aluno.Media}");
                                    Console.WriteLine();
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
                            IEnumerable<Aluno> alunoPesquisado =
                                from alunosPesquisados in alunos
                                where alunosPesquisados.Matricula == matriculaAPesquisar
                                select alunosPesquisados;

                            foreach(Aluno aluno in alunoPesquisado)
                            {
                                Console.WriteLine();
                                Console.WriteLine($"Matricula: {aluno.Matricula} - Aluno: {aluno.Nome} - Media: {aluno.Media}");
                                Console.WriteLine();
                                Console.WriteLine($"As notas são:\nP1: {aluno.PrimeiraProva}\nP2: {aluno.SegundaProva}");
                            }
                            if (alunoPesquisado.Count() == 0)
                            {
                                Console.WriteLine("Não foi possível localizar esse aluno. Tente novamente");
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
                            foreach (Aluno aluno in alunos.ToArray())
                            {
                                if (aluno.Matricula != matriculaASerRetirada)
                                {
                                    Console.WriteLine("Aluno não encontrado");
                                }
                                else if (aluno.Matricula == matriculaASerRetirada)
                                {
                                    alunos.RemoveAll(aluno => aluno.Matricula.Equals(matriculaASerRetirada));
                                    Console.WriteLine("Aluno excluido com sucesso");
                                }

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
                    Console.WriteLine("Insira uma opcao valida");
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
                    Console.WriteLine("Insira uma opcao valida");
                }
            }
        }
    }
}



