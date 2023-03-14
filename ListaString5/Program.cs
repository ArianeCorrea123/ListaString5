using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lista5
{
    internal class Program
    {
        static int Menu()
        {
            Console.Clear();
            int resp;
            Console.WriteLine("Entre com o número de acordo com o exercício.\n");
            Console.WriteLine("Exercicio: 01");
            Console.WriteLine("Exercicio: 02");
            Console.WriteLine("Exercicio: 03");
            Console.WriteLine("Exercicio: 0 - Sair");
            resp = int.Parse(Console.ReadLine());
            return resp;
        }
        static void Ex1()
        {
            int hora = DateTime.Now.Hour;
            var saudacoes = new string[] { "Boa madrugada", "Bom dia", "Boa tarde", "Boa noite" };
            var br = new CultureInfo("pt-BR");
            var nome = Environment.MachineName;
            var nomeCompleto = Dns.GetHostEntry(nome).HostName;

            Console.WriteLine($"{saudacoes[hora / 6]} {Environment.UserName}!");
            Console.WriteLine("Você esta usando a máquina " + nomeCompleto);
            Console.WriteLine("Hoje é " + DateTime.Now.ToString("D", br));
            Console.ReadLine();

        }

        static void Ex2()
        {
            string input = "3.2649195;9300419;8240871%2791073;3917173;9851056#9925124,4763040.0965918;" +
               "93\r\n09297%1010589;5634190,7310819#0258142,0929306.0592849#2628868;1392209;" +
               "49417\r\n11%6802169%3655235.1180040#6889981;4529558,3395538;3095206.8162707,5306168\r\n" +
               "%3277453.0758859,8014857.6402319%2329297.7429486#4680437%5500518#7865391\r\n" +
               "#2873377#8086382#5447877%5426116,5085634%7224325#5798439,1178516%431207\r\n" +
               "2.0796522.9304179;0434651%6509028#4787438#8491024%3015385,5290222%529492\r\n" +
               "7%5561596.0460024%1321386,1368206;3408249,6508625.7336954%8002371;7576263\r\n" +
               "%3747889#7408701%0201462#4900590;9622169#0048623%4969522%4528884#49907\r\n" +
               "86.3003232;6365305%3586311.5647329%3264194;2114295,3171009;9876958,4020305,\r\n" +
               "1632979%0031475.2552181%2602640.5303671.8059160%4988532.4693670%9150725,3\r\n" +
               "340225,6376627.0780785;0990199.4341820.0463039%3299347,7393254%4523854#660\r\n" +
               "3120%9368998#5944279,9085068#8137433,3239866,6379195#7431356.5898614.58104\r\n" +
               "97.3487996#5400022#6149677,8533754%6088682%2032031.6332587,7284531#923933\r\n" +
               "1%8866454,3964222#3314980#8428029.2546101;7316677%0460178;8789264;9316756.\r\n" +
               "1965642;7585590,7383219;9062609,8482023,5717895;2684729;0466794%5370084,0484\r\n" +
               "922;4599156,5815576%3414149.1343440#16129";
            string pattern = @"\D+"; // Expressão regular para selecionar apenas dígitos
            string digitsOnly = Regex.Replace(input, pattern, "");

            int maxLength = digitsOnly.Length - 5;
            int maxProduct = 0;
            string maxSubstring = "";

            for (int i = 0; i <= maxLength; i++)
            {
                string substring = digitsOnly.Substring(i, 5);
                int product = 1;

                foreach (char c in substring)
                {
                    product *= int.Parse(c.ToString());
                }

                if (product > maxProduct)
                {
                    maxProduct = product;
                    maxSubstring = substring;
                }
            }

            Console.WriteLine("A string com o maior produto é: " + maxSubstring);
            Console.WriteLine("O produto é: " + maxProduct);
            Console.ReadLine();

        }

        static void Ex3()
        {
            string input = "3.2649195;9300419;8240871%2791073;3917173;9851056#9925124,4763040.0965918;" +
                "93\r\n09297%1010589;5634190,7310819#0258142,0929306.0592849#2628868;1392209;" +
                "49417\r\n11%6802169%3655235.1180040#6889981;4529558,3395538;3095206.8162707,5306168\r\n" +
                "%3277453.0758859,8014857.6402319%2329297.7429486#4680437%5500518#7865391\r\n" +
                "#2873377#8086382#5447877%5426116,5085634%7224325#5798439,1178516%431207\r\n" +
                "2.0796522.9304179;0434651%6509028#4787438#8491024%3015385,5290222%529492\r\n" +
                "7%5561596.0460024%1321386,1368206;3408249,6508625.7336954%8002371;7576263\r\n" +
                "%3747889#7408701%0201462#4900590;9622169#0048623%4969522%4528884#49907\r\n" +
                "86.3003232;6365305%3586311.5647329%3264194;2114295,3171009;9876958,4020305,\r\n" +
                "1632979%0031475.2552181%2602640.5303671.8059160%4988532.4693670%9150725,3\r\n" +
                "340225,6376627.0780785;0990199.4341820.0463039%3299347,7393254%4523854#660\r\n" +
                "3120%9368998#5944279,9085068#8137433,3239866,6379195#7431356.5898614.58104\r\n" +
                "97.3487996#5400022#6149677,8533754%6088682%2032031.6332587,7284531#923933\r\n" +
                "1%8866454,3964222#3314980#8428029.2546101;7316677%0460178;8789264;9316756.\r\n" +
                "1965642;7585590,7383219;9062609,8482023,5717895;2684729;0466794%5370084,0484\r\n" +
                "922;4599156,5815576%3414149.1343440#16129";
            string digits = new String(input.Where(Char.IsDigit).ToArray()); // Extrai apenas os dígitos da string
            int maxProduct = 0;
            string maxProductDigits = "";
            Console.WriteLine("Substrings terminadas em '11' e soma de seus dígitos:");

            for (int i = 0; i <= digits.Length - 5; i++)
            {
                string subDigits = digits.Substring(i, 5);
                if (subDigits.EndsWith("11"))
                {
                    int product = subDigits.Select(c => c - '0').Aggregate((a, b) => a * b); // Calcula o produto dos dígitos
                    if (product > maxProduct)
                    {
                        maxProduct = product;
                        maxProductDigits = subDigits;
                    }
                    int sum = subDigits.Select(c => c - '0').Sum(); // Calcula a soma dos dígitos
                    Console.WriteLine(subDigits + " -> " + sum);
                }
            }

            Console.WriteLine("Os 5 números consecutivos que retornam o maior produto são: " + maxProductDigits);
            Console.ReadLine();
        }


        static void Main(string[] args)
        {
            int resp;
            do
            {
                resp = Menu();
                switch (resp)
                {
                    case 0:
                        Console.WriteLine("Até a próxima.\n");
                        Console.ReadKey();
                        break;
                    case 1:
                        Console.Clear();
                        Ex1();
                        break;
                    case 2:
                        Console.Clear();
                        Ex2();
                        break;
                    case 3:
                        Console.Clear();
                        Ex3();
                        break;

                }
            }
            while (resp != 0);
        }
    }

}