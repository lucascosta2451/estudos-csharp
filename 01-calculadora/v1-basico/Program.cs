using System;
using System.Reflection.Metadata;

namespace Calculadora
{
  
public class Calculadora
{
    public int Soma(int n1, int n2)
        {

        int soma = n1 + n2;

        return soma;   

        }

    public int Subtração(int n1, int n2)
        {
            int subtração = n1 - n2;

            return subtração;
        }

    public int Multiplicação(int n1, int n2)
        {
            int multiplicação = n1 * n2;

            return multiplicação;
        }

    public int Divisão(int n1, int n2)
        {
            int divisão = n1 / n2;

            return divisão;
        }

    public static void Main()
        {

            Calculadora calculadora = new Calculadora();

            int n1 = 0;
            bool continuar1 = true;
            while (continuar1)
            {
                 Console.WriteLine("digite aqui o 1° número: ");
            string ?entrada1 = Console.ReadLine();

            if(int.TryParse(entrada1, out n1))
            {
                Console.WriteLine("válido");
                continuar1 = false;
            }
            else
            {
                Console.WriteLine("invalido");
            }
            }
            int n2 = 0;
            bool continuar2 = true;

            while (continuar2)
            {
              Console.WriteLine("digite aqui o 2° número: ");
            string ?entrada2 = Console.ReadLine();


                if(int.TryParse(entrada2, out n2))
            {
                Console.WriteLine("válido");
                continuar2 = false;
            }
            else
            {
                Console.WriteLine("invalido");
            }  

            }
          

            int resultado1 = calculadora.Soma(n1, n2);
            int resultado2 = calculadora.Subtração(n1, n2);
            int resultado3 = calculadora.Multiplicação(n1, n2);
            int resultado4 = calculadora.Divisão(n1, n2);

            Console.WriteLine($"soma: {resultado1}");
            Console.WriteLine($"subtração: {resultado2}");
            Console.WriteLine($"multiplicação: {resultado3}");
            Console.WriteLine($"divisão: {resultado4}");


        }
   

}
  
}
