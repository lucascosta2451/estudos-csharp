using System;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Globalization;



public class Calculo
{
    List<decimal> numeros = new List<decimal>();

    List<char> simbolos = new List<char>();

      public override string ToString()
    {
        return $"numero:{string.Join(", ", numeros)} | simbolos: {string.Join(", ", simbolos)}";
    }


    public static decimal Calcularsomasubtracao (List<decimal> nums, List<char> simbs)
    {
        decimal resultado = nums[0];

        for (int i = 0; i < simbs.Count; i++)
        {
            decimal proximo = nums[i + 1];

            switch (simbs[i])
            {
                case '+':
                    resultado += proximo;
                    break;
                case '-':
                    resultado -= proximo;
                    break;
            }
        }

        return resultado;
    }

    public static bool CalcularMultiplicacaoDivisao(List<decimal> nums, List<char> simbs)
    {
        int i = 0;
        while(i < simbs.Count)
        {
            if (simbs[i] == '*' || simbs [i] == '/')
            {
                 decimal antes = nums[i];
                 decimal depois = nums[i + 1];

                 if (simbs[i] == '/' && depois == 0)
                {
                    return false;
                }
                 decimal res = simbs[i] == '*' ? antes * depois : antes / depois;

                nums[i] = res;
                nums.RemoveAt(i + 1);
                simbs.RemoveAt(i);
            }
            else
            {
                i++;
            }
        }   
        return true;                
    }

    public static bool EntradaTexto (string texto, out decimal total)
    {
        total = 0;
        Calculo Calc = new Calculo();
        string numeroAtual = "";
    
        try
        {
            foreach (char c in texto)
            {
                switch (c)
                {
                case char x when char.IsDigit(x) || x == ',' :
                    numeroAtual += c;
                    break;
                        
                case char x when x == '+' || x == '-' || x == '*' || x == '/':
                    if (x == '-' && numeroAtual == "")
                    {
                            numeroAtual += c;
                            break;
                    }
                    Calc.numeros.Add(decimal.Parse(numeroAtual, new CultureInfo("pt-BR")));
                    Calc.simbolos.Add(c);
                    numeroAtual = "";
                    break;
                }  
           }
            Calc.numeros.Add(decimal.Parse(numeroAtual));
        }
        catch (FormatException)
        {
            return false;
        } 
        if (Calc.numeros.Count != Calc.simbolos.Count +1) return false;
        if(!CalcularMultiplicacaoDivisao(Calc.numeros, Calc.simbolos)) return false;
 
        total = Calcularsomasubtracao(Calc.numeros, Calc.simbolos);
        return true; 
        
    }

    public static bool ResolverParenteses(ref string texto)
    {
        texto = texto.Replace('[','(').Replace('{','(')
                     .Replace(']',')').Replace('}',')');

        while (texto.Contains('('))
        {
            int abre = texto.LastIndexOf('(');
            int fecha = texto.IndexOf(')', abre);
            if (fecha == -1) return false;

            string dentro = texto.Substring(abre + 1, fecha - abre - 1);
            if (!EntradaTexto(dentro, out decimal r)) return false;

            texto = texto.Substring(0, abre) + r.ToString(new CultureInfo("pt-BR")) + texto.Substring(fecha + 1);
        }

        return !texto.Contains(')');
    }
}