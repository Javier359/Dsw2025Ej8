namespace Dsw2025Ej8.Domain;

public class CuentaBancaria
{
    public TipoCuenta Tipo { get;}
    public string Numero { get; }
    public decimal Saldo { get; private set; }
    public Estado Estado { get; private set;}
    public decimal TasaDeInteres { get; set; }
    public decimal LimiteDeDescubierto { get; set; }
    public decimal Comision { get; set; }
    public string[] Titulares { get; }

    public CuentaBancaria(string numero, decimal saldo, TipoCuenta tipo, string[] titulares)
    {
        Numero = numero;
        Saldo = saldo;
        Tipo = tipo;
        Estado = Estado.Activa;
        Titulares = titulares;
    }  
    public void Depositar(decimal monto)
    {
        if (Tipo == TipoCuenta.CajaDeAhorro)
        {
            Saldo += monto;
        }
        else if (Tipo == TipoCuenta.CuentaCorriente)
        {
            monto -= monto * Comision;
            Saldo += monto;
        }
    }

    public void Retirar(decimal monto)
    {
        if (Tipo == TipoCuenta.CajaDeAhorro)
        {
            Saldo -= monto;
        }
        else if (Tipo == TipoCuenta.CuentaCorriente)
        {
            if (Saldo - monto >= -LimiteDeDescubierto)
            {
                Saldo -= monto;
            }
            if (Saldo < 0)
            {
                Estado = Estado.Suspendida;
            }
        }
    }

    public void AplicarInteres()
    {
        if (Tipo == TipoCuenta.CajaDeAhorro)
        {
            Saldo += Saldo * TasaDeInteres;
        }
    }
}
