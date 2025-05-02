using System.Data.Common;
using System.Security.Cryptography.X509Certificates;
using Dsw2025Ej8.Domain;

namespace Dsw2025Ej8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
           CuentaBancaria cuentaGerman = new CuentaBancaria("001", 1000, TipoCuenta.CajaDeAhorro, new[] { "German", "Damian" })
            {
                TasaDeInteres = 0.2M,
                LimiteDeDescubierto = 150M
            };
            CuentaBancaria cuentaAgustin = new CuentaBancaria("002", 2000, TipoCuenta.CuentaCorriente, new[] { "Agustin", "javier" })
            {
                TasaDeInteres = 0.4M,
                LimiteDeDescubierto = 200M
            };
            CuentaBancaria cuentaLuis = new CuentaBancaria("003", 1500, TipoCuenta.CajaDeAhorro, new[] { "Luis", "Matias" })
            {
                TasaDeInteres = 0.2M,
                LimiteDeDescubierto = 300M
            };
            CuentaBancaria cuentaAna = new CuentaBancaria("004", 2500, TipoCuenta.CuentaCorriente, new[] { "Ana", "Raul" })
            {
                TasaDeInteres = 0.4M,
                LimiteDeDescubierto = 200M
            };
            /*Metodos*/
            /*cuentaGerman.Depositar(0);
            cuentaGerman.Retirar(450);
            
            cuentaAgustin.Depositar(10);
            cuentaAgustin.Retirar(2211);

            cuentaLuis.Depositar(100);
            cuentaLuis.Retirar(1600);

            cuentaAna.Depositar(400);
            cuentaAna.Retirar(200);*/

            /*anonimo*/
            var cuentas = new List<CuentaBancaria>
            {
                cuentaGerman,
                cuentaAgustin,
                cuentaLuis,
                cuentaAna
            };
          
            foreach (var cuenta in cuentas)
            {
                Console.WriteLine($"Resumen: {new { cuenta.Numero, cuenta.Tipo, cuenta.Saldo }}");
            }
        }

    }
}
