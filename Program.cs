using System;

namespace Revisao
{
    class Program
    {
        // MAIN
        static void Main(string[] args)
        {

            // VARIABLES
            string opcao;
            Aluno[] alunos = new Aluno[5]; // Está limitado a somente cinco alunos.

            Console.Clear();
            do
            {
                opcao = printMenu();
                controlOpcao(opcao, alunos);

            } while (opcao != "4");

            Console.WriteLine("App closed!");

        }

        // METHODS
        private static void controlOpcao(string opcao, Aluno[] alunos)
        {
            Console.Clear();
            // CONTROL
            switch (opcao)
            {
                case "1":
                    // Adicionar novo aluno
                    bool isFull = isFulled(alunos);
                    if (isFull == true) { Console.WriteLine("A lista de alunos está cheia!"); break; }

                    Console.WriteLine("--- INSERÇÃO DE ALUNO ---");
                    Console.WriteLine();

                    Aluno aluno = inserirNovoAluno(alunos);
                    Console.Clear();

                    if (aluno != null) Console.WriteLine("Aluno inserido com sucesso!");

                    break;
                case "2":
                    // Listar aluno
                    listarAlunos(alunos);
                    Console.WriteLine();
                    break;
                case "3":
                    // Calcular média geral
                    decimal? mediaF = media(alunos);
                    if (mediaF != null) Console.WriteLine("A média das notas é de: " + mediaF);
                    Console.WriteLine();
                    break;
                case "4":
                    Console.WriteLine("closing app...");
                    Console.WriteLine();
                    break;
                default:
                    Console.WriteLine("Número inválido! Insira um valor válido!");
                    Console.WriteLine();
                    break;
            }
            Console.WriteLine();

        }

        private static string printMenu()
        {
            Console.WriteLine("=== ESCOLINHA ===");
            Console.WriteLine("1 - Inserir novo aluno.");
            Console.WriteLine("2 - Listar alunos.");
            Console.WriteLine("3 - Calcular média geral.");
            Console.WriteLine("4 - Sair da aplicação");
            Console.WriteLine();
            Console.Write("Informe a opção desejada: ");
            string opcao = Console.ReadLine();
            return opcao;
        }

        private static Aluno inserirNovoAluno(Aluno[] alunos)
        {
            Aluno aluno = new Aluno();
            if (aluno == null)
            {
                Console.WriteLine("\nHouve um erro ao instanciar um objeto do tipo 'Aluno'");
                return null;
            }

            Console.Write("Informe o nome do aluno: ");
            try { aluno.setNome(Console.ReadLine()); } catch (Exception) { Console.WriteLine("Houve um erro ao processar este dado!"); aluno = null; }
            Console.Write("Informe a nota do aluno: ");
            try { aluno.setNota(Decimal.Parse(Console.ReadLine())); } catch (Exception) { Console.WriteLine("Houve um erro ao processar este dado!"); aluno = null; }
            if (aluno == null)
            {
                Console.WriteLine("\nAluno não inserido com sucesso! Tente novamente mais tarde!");
                return null;
            }

            for (int i = 0; i < alunos.Length; i++)
            {
                if (alunos[i] == null)
                {
                    alunos[i] = aluno;
                    break;
                }
            }

            return aluno;
        }

        private static bool isFulled(Aluno[] alunos)
        {
            for (int i = 0; i < alunos.Length; i++)
            {
                if (alunos[i] == null)
                {
                    return false;
                }
            }
            return true;
        }

        private static void listarAlunos(Aluno[] alunos)
        {
            bool isEmpty = true;
            foreach (Aluno _aluno in alunos)
            {
                if (_aluno != null)
                {
                    Console.WriteLine($"Nome: {_aluno.getNome()}, Nota: {_aluno.getNota()}");
                    isEmpty = false;
                }
            }
            if(isEmpty == true) Console.WriteLine("A lista de alunos está vazia!");
        }

        private static decimal? media(Aluno[] alunos) 
        {
            decimal? result = 0;
            if (alunos[0] == null || alunos[1] == null)
            {
                Console.WriteLine("Ainda não é possível calcular a média...");
                return null;
            } else {
                int i = 0;
                do
                {
                    result += alunos[i].getNota();
                    i++;
                    if (i == 5) break;
                } while (alunos[i] != null);
                result = result / i;
            }
            return result;
        }

    }
}
