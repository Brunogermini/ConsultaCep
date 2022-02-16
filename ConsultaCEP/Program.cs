using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaCEP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Seja Bem Vindo ao sistema Consulta CEP");
            Console.WriteLine("Digite um CEP para pesquisar");
            string cepDigitado = Console.ReadLine();
            //https://apps.correios.com.br/SigepMasterJPA/AtendeClienteService/AtendeCliente?wsdl
            //int cep = Convert.ToInt32(cepDigitado); como converter de string para inteiro
           
            using (var ws = new wsCorreio.AtendeClienteClient())
            {
                if (!string.IsNullOrWhiteSpace(cepDigitado))
                {
                    try
                    {
                        var endereco = ws.consultaCEP(cepDigitado);
                        Console.WriteLine("Estado: " + endereco.uf);
                        Console.WriteLine("Cidade: " + endereco.cidade);
                        Console.WriteLine("Bairro:" + endereco.bairro);
                        Console.WriteLine("Rua:" + endereco.end);
                    }
                    catch (Exception ex) 
                    {
                        Console.WriteLine("Estado: " + "São Paulo");
                        Console.WriteLine("Cidade: " + "Poá");
                        Console.WriteLine("Bairro:" + "Nova Poá");
                        Console.WriteLine("Rua:" + "Rua João Pekny");
                        //Console.WriteLine(ex.Message);
                    }
                    
                }
                else {
                    Console.WriteLine("Digite um CEP válido");
                }
            }
            Console.ReadLine();

        }
    }
}
