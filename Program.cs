using System.Data.Common;
using System.Security.Cryptography.X509Certificates;
using Dsw2025Ej8.Domain;

namespace Dsw2025Ej8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CuentaBancaria cb = new CuentaBancaria("124", 124, TipoCuenta.CajaDeAhorro, ["german","javier"]);
            cb.TasaDeInteres = 0.2M;
            cb.LimiteDeDescubierto = 0.10M;
            Console.WriteLine($"Cuenta Bancaria: {cb.Numero} , {cb.Saldo} , {cb.Tipo} , {cb.Titulares[0]}, {cb.TasaDeInteres}, {cb.LimiteDeDescubierto}");

        }
        
    }
}
