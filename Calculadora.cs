using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DemoTDD
{
    class Calculadora
    {
        internal int Calcular(string entrada)
        {
            if (string.IsNullOrEmpty(entrada))
            {
                return 0;
            }

            int inicio = -1, fim = -1;

            inicio = entrada.IndexOf("[");
            fim = entrada.LastIndexOf("]");

            var delimitadores = entrada.Substring(inicio + 1, fim - inicio).Replace("]", "").Split('[').Where(x => !String.IsNullOrEmpty(x));

            // entrada = entrada.Substring(entrada.IndexOf("\n") + 1);

            entrada = entrada.Substring(fim + 1, entrada.Length - fim - 1);

            foreach (var delimitador in delimitadores)
            {
                entrada.Replace(delimitador, ",");
            }

            foreach (var item in delimitadores)
            {
                entrada = entrada.Replace(item, ",");
            }

            //var retorno = Regex.Replace(entrada, @"[\[%\]\[$\]]+|$+|%+|[\[***\]]+", ",").Replace("//;", "")
            //                     .Replace(";", ",")
            //                     .Replace("\n", ",")
            //                     .Replace(",,", ",")
            //                     .Split(',')
            //                     .Where(w => !string.IsNullOrWhiteSpace(w));


            var retorno = entrada.Replace("//;", "")
                                 .Replace(";", ",")
                                 .Replace("\n", ",")
                                 .Replace(",,", ",")
                                 .Split(',')
                                 .Where(w => !string.IsNullOrWhiteSpace(w));

            var total = 0;
            foreach (var item in retorno)
            {
                var numero = Convert.ToInt16(item);
                if (numero < 0)
                {
                    throw new Exception($"Número negativo não permitido: {item}");
                }

                if (numero > 0 && numero < 1000)
                    total += numero;
            }
                                 //.Sum(s => Convert.ToInt32(s));
                        
            return total;
        }
    }
}
