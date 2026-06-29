public record Bebida(string Nombre, int Precio, int Stock);

public class MaquinaCafe
{
    public int Saldo { get; private set; }
    private Dictionary<string, Bebida> _menu;

    public MaquinaCafe()
    {
        _menu = new Dictionary<string, Bebida>
        {
            { "Cafe", new Bebida("Cafe", 100, 10) },
            { "Te", new Bebida("Te", 75, 10) },
            { "Agua", new Bebida("Agua", 50, 10) }
        };
    }

    public void InsertarMoneda(int monto)
    {
        Saldo += monto;
    }

    public bool SeleccionarBebida(string bebida)
    {
        if (!_menu.ContainsKey(bebida))
            throw new ArgumentException($"La bebida '{bebida}' no existe en el menu.");

        var item = _menu[bebida];

        if (item.Stock <= 0 || Saldo < item.Precio)
            return false;

        Saldo -= item.Precio;
        _menu[bebida] = item with { Stock = item.Stock - 1 };
        return true;
    }

    public int ObtenerCambio()
    {
        int cambio = Saldo;
        Saldo = 0;
        return cambio;
    }

    public void DevolverMonedas()
    {
        Saldo = 0;
    }

    public Dictionary<string, Bebida> ObtenerMenu()
    {
        return new Dictionary<string, Bebida>(_menu);
    }
}
