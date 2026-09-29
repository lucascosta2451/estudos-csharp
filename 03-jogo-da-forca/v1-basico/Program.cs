using System;
using System.Linq;

public class Palavra
{
    


    public static void Main()
    
    {
        Console.WriteLine("escreva uma palavra");
        string? palavra = Console.ReadLine();
        
        char? letraprocurada = '?';
        
         
       
        if (palavra != null)
        {
            int quantidade = palavra.Length;
            char[] progresso = new char[quantidade];

            for (int i = 0; i < quantidade; i++)
             {
            progresso[i] = '_';
             }

            Console.WriteLine(progresso);
            int tentativasAtuais = 0;
            int maxTentativas = 5;


            while (progresso.Contains('_') && tentativasAtuais < maxTentativas)
            {
            string? letradigitada = Console.ReadLine();

            if(letradigitada != null)
            {   
                letraprocurada = letradigitada[0];  
            }
        
            bool acertou = false;

            for (int i = 0; i < palavra.Length; i++)
            {
                if (palavra[i] == letraprocurada)
                {
                    progresso[i] = letraprocurada.Value;
                    acertou = true;
                }
                
                
            }
                if (!acertou)
                    {
                        tentativasAtuais++;
                    }

                int tentativasrestantes = maxTentativas - tentativasAtuais;

                if(tentativasrestantes > 0)
                    {
                        Console.WriteLine($"você ainda tem {tentativasrestantes} tentativas(s).\n");
                    }
            

            Console.WriteLine(progresso);

            }
        }    
    }
}