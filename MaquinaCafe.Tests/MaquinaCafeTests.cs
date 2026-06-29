using NUnit.Framework;

[TestFixture]
public class MaquinaCafeTests
{
    private MaquinaCafe maquina;

    [SetUp]
    public void Setup()
    {
        maquina = new MaquinaCafe();
    }

    [Test]
    public void TC01_InsertarMoneda_DebeAumentarSaldo()
    {
        maquina.InsertarMoneda(25);

        Assert.That(maquina.Saldo, Is.EqualTo(25));
    }

    [Test]
    public void TC02_SeleccionarBebida_ConSaldoSuficiente_DebeRetornarTrue()
    {
        maquina.InsertarMoneda(100);

        bool resultado = maquina.SeleccionarBebida("Cafe");

        Assert.That(resultado, Is.True);
    }

    [Test]
    public void TC03_SeleccionarBebida_ConSaldoInsuficiente_DebeRetornarFalse()
    {
        maquina.InsertarMoneda(50);

        bool resultado = maquina.SeleccionarBebida("Cafe");

        Assert.That(resultado, Is.False);
    }

    [Test]
    public void TC04_ObtenerCambio_DebeDevolverSaldoRestante()
    {
        maquina.InsertarMoneda(150);
        maquina.SeleccionarBebida("Cafe");

        int cambio = maquina.ObtenerCambio();

        Assert.That(cambio, Is.EqualTo(50));
    }

    [Test]
    public void TC05_SeleccionarBebida_Inexistente_DebeLanzarArgumentException()
    {
        Assert.Throws<ArgumentException>(() => maquina.SeleccionarBebida("Jugo"));
    }

    [Test]
    public void TC06_ObtenerMenu_DebeRetornarTresBebidas()
    {
        var menu = maquina.ObtenerMenu();

        Assert.That(menu.Count, Is.EqualTo(3));
        Assert.That(menu["Cafe"].Precio, Is.EqualTo(100));
        Assert.That(menu["Te"].Precio, Is.EqualTo(75));
        Assert.That(menu["Agua"].Precio, Is.EqualTo(50));
    }

    [Test]
    public void TC07_DevolverMonedas_DebeDejarSaldoEnCero()
    {
        maquina.InsertarMoneda(100);

        maquina.DevolverMonedas();

        Assert.That(maquina.Saldo, Is.EqualTo(0));
    }

    [Test]
    public void TC08_SeleccionarBebida_SinStock_DebeRetornarFalse()
    {
        maquina.InsertarMoneda(1100);
        for (int i = 0; i < 10; i++)
            maquina.SeleccionarBebida("Cafe");

        bool resultado = maquina.SeleccionarBebida("Cafe");

        Assert.That(resultado, Is.False);
    }
}
