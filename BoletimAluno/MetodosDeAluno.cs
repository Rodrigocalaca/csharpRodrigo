﻿using RelatorioAlunos;

namespace boletimAluno
{
    public static class MetodosDeAluno
    {
        public static string ObtenhaOpcaoMenuPrincipal()
        {
            Console.WriteLine("---------------MENU---------------"); ;
            Console.WriteLine("[1] - Adicionar aluno");
            Console.WriteLine("[2] - Consulta geral da turma");
            Console.WriteLine("[3] - Buscar aluno");
            Console.WriteLine("[4] - Excluir aluno");
            Console.WriteLine("[5] - Comparar valores");
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

                return validarResposta;
            }
        }
        public static string ObtenhaMenuComparacao()
        {
            Console.WriteLine("------------------------");
            Console.WriteLine("O que deseja comparar?: ");
            Console.WriteLine("[1] - NOTA");
            Console.WriteLine("[2] - SERIE");
            Console.WriteLine("[3] - PERIODO");
            Console.WriteLine("[X] - Voltar ao menu");
            Console.WriteLine("------------------------");
            string comparacao = Console.ReadLine()?.Trim() ?? string.Empty;

            return comparacao;
        }
        public static string SwitchCaseDoMenuContinuacao(string opcaoDigitada, string opcaoDoMenu)
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
                    ObtenhaMenuDeContinuacao();
                    Console.WriteLine("Insira uma opcao valida");
                    break;
            }
            return "0";
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
            else if (tipoDeEnsino == "2")
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
        public static void ImprimaComparacao<T>(T dado1, T dado2, string nome1, string nome2) where T : IComparable<T>
        {
            var maior = MetodosDeAluno.Comparar(dado1, dado2);
            Console.Write($"O aluno mais avançado entre {nome1} e {nome2} é: ");
            if (maior.Equals(dado1))
            {
                Console.WriteLine(nome1);
            }
            else
            {
                Console.WriteLine(nome2);
            }
        }
        public static bool AchaMatricula(string matricula, List<Aluno> alunos)
        {
            if (alunos.Exists(aluno => aluno.Matricula == matricula)) { return true; }
            else { return false; }
        }
        public static string ValidaMatricula(string matricula, List<Aluno> alunos)
        {
            int validacaoNumeroInteiro;

            while (!Int32.TryParse(matricula, out validacaoNumeroInteiro))
            {
                Console.WriteLine("A matricula precisa ser um número");
                matricula = MetodosDeAluno.PegaMatricula();
            }
            while (matricula.Length < 1)
            {
                Console.WriteLine("Insira uma matricula válida");
                matricula = MetodosDeAluno.PegaMatricula();
            }
            return matricula;
        }
        public static string ConfereAlunos()
        {
            Console.WriteLine("Não há alunos suficientes cadastrados");
            string opcaoMenu = MetodosDeAluno.ObtenhaOpcaoMenuPrincipal();

            return opcaoMenu;
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
        public static string CasoContinuar(string texto)
        {
            string continuar = MetodosDeAluno.ObtenhaMenuDeContinuacao().ToUpper();
            string opcaoMenu = MetodosDeAluno.SwitchCaseDoMenuContinuacao(continuar, texto);

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
        public static T Comparar<T>(T dado1, T dado2) where T : IComparable<T>
        {
            if (dado1.CompareTo(dado2) > 0)
            {
                return dado1;
            }
            return dado2;
        }
        public static void FazAComparacao(string matricula1, string matricula2, string tipoDeEnsino, List<Aluno> alunos)
        {
            string? dado1 = "";
            string? dado2 = "";
            string? nome1 = "";
            string? nome2 = "";
            foreach (Aluno aluno in alunos.Where(aluno => aluno.Matricula == matricula1))
            {
                if (tipoDeEnsino == "1")
                {
                    AlunoEnsinoBasico pegarAlunoBasico1 = (AlunoEnsinoBasico)aluno;
                    dado1 = pegarAlunoBasico1.Serie;
                    nome1 = pegarAlunoBasico1.Nome;
                }
                else
                {
                    AlunoEnsinoSuperior pegarAlunoSuperior1 = (AlunoEnsinoSuperior)aluno;
                    dado1 = pegarAlunoSuperior1.Periodo;
                    nome1 = pegarAlunoSuperior1.Nome;
                }
            }
            foreach (Aluno aluno in alunos.Where(aluno => aluno.Matricula == matricula2))
            {
                if (tipoDeEnsino == "1")
                {
                    AlunoEnsinoBasico pegarAlunoBasico2 = (AlunoEnsinoBasico)aluno;
                    dado2 = pegarAlunoBasico2.Serie;
                    nome2 = pegarAlunoBasico2.Nome;
                }
                else
                {
                    AlunoEnsinoSuperior pegarAlunoSuperior2 = (AlunoEnsinoSuperior)aluno;
                    dado2 = pegarAlunoSuperior2.Periodo;
                    nome2 = pegarAlunoSuperior2.Nome;
                }
            }
            if (dado1 == dado2)
            {
                Console.WriteLine("Valores iguais");
            }
            else
            {
                ImprimaComparacao(dado1, dado2, nome1, nome2);
            }
        }
        public static void FacaOperacaoDeComparacao(List<Aluno> alunos, string opcaoDoMenuDeEnsino, string opcaoMenu, string matriculaAPesquisar1, string matriculaAPesquisar2)
        {
            if (!MetodosDeAluno.AchaMatricula(matriculaAPesquisar1, alunos))
            {
                Console.WriteLine("O aluno não foi encontrado");
            }
            if (!MetodosDeAluno.AchaMatricula(matriculaAPesquisar2, alunos))
            {
                Console.WriteLine("O aluno não foi encontrado");
            }
            else
            {
                MetodosDeAluno.FazAComparacao(matriculaAPesquisar1, matriculaAPesquisar2, opcaoDoMenuDeEnsino, alunos);
            }
        }
    }
}