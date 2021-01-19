using System;

namespace revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0;
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario != "4")
            {
                switch(opcaoUsuario)
                {
                    case "1":       //Função: Adicionar aluno
                        Console.WriteLine("Informe o nome do aluno: ");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota do aluno: ");

                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {

                        aluno.Nota = nota;

                        }

                        else
                        {
                            throw new ArgumentException("Valor incorreto! Por favor, insira um valor decimal.");
                        }

                        alunos[indiceAluno] = aluno;
                        indiceAluno++;                   
                        break;

                    case "2":       //Função: Listar aluno
                        foreach(var a in alunos)
                        {
                            if (!string.IsNullOrEmpty(a.Nome))
                            {
                                Console.WriteLine($"Aluno: {a.Nome} // Nota: {a.Nota}");
                            }
                        }
                        break;

                    case "3":       //Função: Calcular média geral
                        decimal notaTotal = 0;
                        var nmrAlunos = 0;

                        for (int i=0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                nmrAlunos++;
                            }
                        }

                        var mediaGeral = notaTotal / nmrAlunos;
                        Conceito conceitoGeral;

                        if (mediaGeral <= 2)
                        {
                            conceitoGeral = Conceito.E;
                        }
                        else if (mediaGeral <= 4)
                        {
                            conceitoGeral = Conceito.D;
                        }
                        else if (mediaGeral <= 6)
                        {
                            conceitoGeral = Conceito.C;
                        }
                        else if (mediaGeral <= 8)
                        {
                            conceitoGeral = Conceito.B;
                        }
                        else
                        {
                            conceitoGeral = Conceito.A;
                        }

                        Console.WriteLine($"Media Geral: {mediaGeral} // Conceito: {conceitoGeral}");
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                    
                }

                opcaoUsuario = ObterOpcaoUsuario();
            
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Bem-vindo!");
            Console.WriteLine("Informe a opção desejada: ");
            Console.WriteLine("1 - Inserir Novo Aluno.");
            Console.WriteLine("2 - Listar Alunos.");
            Console.WriteLine("3 - Calcular Média Geral.");
            Console.WriteLine("4 - Sair.");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;

        }
    }
}
