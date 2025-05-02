namespace Dsw2025Ej8.Domain;

public class CuentaBancaria
{
    public TipoCuenta Tipo { get;}
    public string Numero { get; }
    public decimal Saldo { get; private set; }
    public Estado Estado { get; private set;}
    public decimal TasaDeInteres { get; init; }
    public decimal LimiteDeDescubierto { get; init; }
    public decimal Comision { get; set; }
    public string[] Titulares { get; }

    public CuentaBancaria(string numero, decimal saldo, TipoCuenta tipo, string[] titulares)
    {
        Numero = numero;
        Saldo = saldo;
        Tipo = tipo;
        Estado = Estado.Suspendida;
        Titulares = titulares;
    }  
    public void Depositar(decimal monto)
    {
        if(VerificarEstado() is not null)
        {
            Console.WriteLine(VerificarEstado().Message);
            return;
        }

        if (VerificarMonto(monto) is not null)
        {
            Console.WriteLine(VerificarMonto(monto).Message);
            return;
        }

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
        if (VerificarEstado() is not null)
        {
            Console.WriteLine(VerificarEstado().Message);
            return;
        }

        if (VerificarMonto(monto) is not null)
        {
            Console.WriteLine(VerificarMonto(monto).Message);
            return; 
        }
        try
        {
            if (Tipo == TipoCuenta.CajaDeAhorro)
            {
                if(Saldo >= monto)
                    Saldo -= monto;
                else
                {
                    Estado = Estado.Suspendida;
                    throw new InvalidOperationException("Saldo insuficiente.");
                }
            }
            else if (Tipo == TipoCuenta.CuentaCorriente)
            {
                if (Saldo - monto >= -LimiteDeDescubierto)
                {
                    Saldo -= monto;
                }
                else
                {
                    Estado = Estado.Suspendida;
                    throw new InvalidOperationException("Saldo insuficiente.");
                }
            }
        }
        catch (Exception ex) { Console.WriteLine($"ERROR: {ex.Message}"); }
        
    }

    public void AplicarInteres()
    {
        if (Tipo == TipoCuenta.CajaDeAhorro)
        {
            Saldo += Saldo * TasaDeInteres;
        }
    }

    private Exception VerificarMonto(decimal monto)
    {
        return monto <= 0 ? new InvalidOperationException("Monto no válido para realizar la operación.") : null;
    }

    public Exception VerificarEstado()
    {
        return Estado != Estado.Activa ? new InvalidOperationException("Cuenta no activa.") : null;
    }
}
