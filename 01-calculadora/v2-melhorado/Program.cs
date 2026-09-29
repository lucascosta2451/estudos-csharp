using System;
using System.Reflection.Metadata;

namespace Calculadora
{
  
public class Calculadora 
{
    public decimal Soma(decimal n1, decimal n2)
        {

        decimal soma = n1 + n2;

        return soma;   

        }

    public decimal Subtração(decimal n1, decimal n2)
        {
            decimal subtração = n1 - n2;

            return subtração;
        }

    public decimal Multiplicação(decimal n1, decimal n2)
        {
            decimal multiplicação = n1 * n2;

            return multiplicação;
        }

    public decimal Divisão(decimal n1, decimal n2)
        {
        if(n2 == 0)
            {
                Console.WriteLine("não pode 0");
                return 0;  

            }
        else
        {
            decimal divisao = n1 / n2;

            return divisao; 
        }
        }

 

    public static void Main()
        {

            Calculadora calculadora = new Calculadora();

            decimal n1 = 0;
            bool continuar1 = true;
            while (continuar1)
            {
                 Console.WriteLine("digite aqui o 1° número: ");
            string ?entrada1 = Console.ReadLine();

            if(decimal.TryParse(entrada1, out n1))
            {
                Console.WriteLine("válido");
                continuar1 = false;
            }
            else
            {
                Console.WriteLine("invalido");
            }
            }

            decimal n2 = 0;
            bool continuar2 = true;

            while (continuar2)
            {
              Console.WriteLine("digite aqui o 2° número: ");
            string ?entrada2 = Console.ReadLine();


                if(decimal.TryParse(entrada2, out n2))
            {
                Console.WriteLine("válido");
                continuar2 = false;
            }
            else
            {
                Console.WriteLine("invalido");
            }  

            }

            Console.WriteLine(" deseja :");
            Console.WriteLine(" somar? digite 1");
            Console.WriteLine(" subtrair digite 2");
            Console.WriteLine(" multiplicar? digite 3");
            Console.WriteLine(" dividir? digite 4");
            string ?opcao= Console.ReadLine();
            
            if(int.TryParse(opcao, out int opcaon))
            {
              switch (opcaon)
            {
                case 1:
                    decimal resultado1 = calculadora.Soma(n1, n2);
                    Console.WriteLine($"soma: {resultado1}");
                    break;

                case 2:
                    decimal resultado2 = calculadora.Subtração(n1, n2);
                    Console.WriteLine($"subtração: {resultado2}");
                    break;

                case 3:
                    decimal resultado3 = calculadora.Multiplicação(n1, n2);
                    Console.WriteLine($"multiplicação: {resultado3}");
                    break;

                case 4:
                    decimal resultado4 = calculadora.Divisão(n1, n2);
                    Console.WriteLine($"divisão: {resultado4}");
                    break;
            }
            }
            else
            {
                Console.WriteLine("opção Invalida");
            }

            

        }
   

}
  
}
