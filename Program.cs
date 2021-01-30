using System;

namespace revisao
{
    class Program
    {
        private static string Menu()
        {
            Console.WriteLine("Informe a opção desejada: ");
            Console.WriteLine("1 - Inserir Novo Aluno:");
            Console.WriteLine("2 - Listar Alunos");
            Console.WriteLine("3 - Consultar Média Geral");
            Console.WriteLine("X - Sair\n");
            return Console.ReadLine();
        }
        static void Main(string[] args)
        {
            
            string opcaoUsuario;
            int indiceAluno = 0;
            aluno[] alunos = new aluno[5];
            opcaoUsuario = Menu();
            while(opcaoUsuario.ToUpper() != "X" && indiceAluno <= 5){
                switch(opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do aluno: ");
                        aluno alun = new aluno();
                        alun.Name = Console.ReadLine();
                        Console.WriteLine("Informe a nota do aluno:");
                        if(decimal.TryParse(Console.ReadLine(),out decimal nota))
                            alun.Nota = nota;
                        else
                            throw new ArgumentException("Valor da nota deve ser decimal!");
                        alunos[indiceAluno] = alun;
                        indiceAluno++;
                        break;
                    case "2":
                        for(int i = 0; i < indiceAluno; i++)
                            Console.WriteLine($"Aluno: {alunos[i].Name}\nNota: {alunos[i].Nota}\n");
                        break;
                    case "3":
                        decimal soma = 0;
                        Conceito conceito;
                        for(var i = 0; i < indiceAluno; i++)
                        {
                            soma = soma + alunos[i].Nota;

                        }
                        soma /= (indiceAluno + 1);
                        if(soma >= 9)
                            conceito =  Conceito.A;
                        else if(soma >=7)
                            conceito = Conceito.B;
                        else if(soma >= 5)
                            conceito = Conceito.C;
                        else if(soma >= 3)
                            conceito = Conceito.D;
                        else
                            conceito = Conceito.E;


                        Console.WriteLine($"Média Geral: {soma}\nConceito Geral: {conceito}");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = Menu();
                Console.WriteLine();
            }
        }
    }
}
