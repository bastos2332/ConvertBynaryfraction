using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversorFracaoBanaria
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1(BINARIO -> DECIMAL) - 2(DECIMAL -> FRAÇÃO)");
            string escolha = Console.ReadLine();

            if (escolha == "1")
            {
                Console.WriteLine(ConverterBinarioParaDecimal());

            }
            else
            {
                Console.WriteLine("Digite o número decimal:");
                Console.WriteLine(ConverterDecimalParaBinario(Convert.ToDouble(Console.ReadLine())));
            }

            Console.ReadKey();
        }

        private static string ConverterBinarioParaDecimal()
        {
            Console.WriteLine("Digite a parte inteira:");
            string parteInteira = Console.ReadLine();
            Console.WriteLine("Digite a parte fracionária:");
            string parteFracionaria = Console.ReadLine();

            string BinarioInteiroInvertido = InverterString(parteInteira);
            string BinarioFracionarioInvertido = InverterString(parteFracionaria);


            int resultadoDecimalParteInteira = 0;
            double resultadoDecimalParteFracionaria = 0;
            double resultadoFracionarioFinal = 0;

            for (int i = 0; i < BinarioInteiroInvertido.Length; i++)
            {
                resultadoDecimalParteInteira += Convert.ToInt32(BinarioInteiroInvertido.Substring(i, 1)) * (int)Math.Pow(2, i);
            }

            for (int i = 0; i < BinarioFracionarioInvertido.Length; i++)
            {
                resultadoDecimalParteFracionaria += Convert.ToInt32(BinarioFracionarioInvertido.Substring(i, 1)) * (1 / (double)Math.Pow(2, (i + 1)));
            }
            resultadoFracionarioFinal = resultadoDecimalParteInteira + resultadoDecimalParteFracionaria;
            return $"Base Decimal = {resultadoFracionarioFinal}";

        }

        private static string ConverterDecimalParaBinario(double numeroDecimal)
        {
           
            string valor = "";
            int dividendo = Convert.ToInt32(Math.Floor(numeroDecimal));
            if (dividendo == 0 || dividendo == 1)
            {
                //return Convert.ToString(dividendo);
            }
            else
            {
                while (dividendo > 0)
                {
                    valor += Convert.ToString(dividendo % 2);
                    dividendo = dividendo / 2;
                }
                //return InverterString(valor);
            }


            numeroDecimal = numeroDecimal - (int)numeroDecimal;
            var binario = "";
            while (numeroDecimal != 0.0)
            {
                numeroDecimal *= 2;
                int resto = (int)numeroDecimal;
                numeroDecimal -= resto;
                binario += resto;
            }

            return $"Binario = {InverterString(valor)}, {binario}";
        }

        public static string InverterString(string str)
        {
            int tamanho = str.Length;
            char[] caracteres = new char[tamanho];
            for (int i = 0; i < tamanho; i++)
            {
                caracteres[i] = str[tamanho - 1 - i];
            }
            return new string(caracteres);
        }
    }
}
