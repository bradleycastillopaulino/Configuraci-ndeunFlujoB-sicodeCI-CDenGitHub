Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.Title = "Maquina de Cafe - TDD";

var maquina = new MaquinaCafe();
bool ejecutando = true;

MostrarBienvenida();

while (ejecutando)
{
    Console.WriteLine();
    MostrarMenu(maquina.Saldo);
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("  >>> ");
    Console.ResetColor();

    string opcion = Console.ReadLine() ?? "";

    switch (opcion)
    {
        case "1":
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("  Ingrese el monto a insertar: ");
            Console.ResetColor();
            if (int.TryParse(Console.ReadLine(), out int monto) && monto > 0)
            {
                maquina.InsertarMoneda(monto);
                MostrarExito($"Se insertaron {monto} monedas. Saldo actual: {maquina.Saldo}");
            }
            else
            {
                MostrarError("Monto invalido. Ingrese un numero positivo.");
            }
            break;

        case "2":
            MostrarInfo($"Saldo actual: {maquina.Saldo}");
            break;

        case "3":
            MostrarMenuBebidas(maquina);
            break;

        case "4":
        case "5":
        case "6":
            string bebida = opcion switch
            {
                "4" => "Cafe",
                "5" => "Te",
                "6" => "Agua",
                _ => ""
            };
            if (maquina.SeleccionarBebida(bebida))
                MostrarExito($"Bebida '{bebida}' dispensada. Saldo restante: {maquina.Saldo}");
            else
                MostrarError($"No se pudo dispensar '{bebida}'. Verifique saldo o stock.");
            break;

        case "7":
            int cambio = maquina.ObtenerCambio();
            MostrarExito($"Cambio devuelto: {cambio}");
            break;

        case "8":
            maquina.DevolverMonedas();
            MostrarExito("Monedas devueltas. Saldo: 0");
            break;

        case "9":
            ejecutando = false;
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("  ╔═══════════════════════════════════════════╗");
            Console.WriteLine("  ║   Gracias por usar la Maquina de Cafe!   ║");
            Console.WriteLine("  ║            Hasta luego! :)               ║");
            Console.WriteLine("  ╚═══════════════════════════════════════════╝");
            Console.ResetColor();
            break;

        default:
            MostrarError("Opcion no valida. Intente de nuevo.");
            break;
    }
}

void MostrarBienvenida()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine();
    Console.WriteLine("  ╔═══════════════════════════════════════════╗");
    Console.WriteLine("  ║                                           ║");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("  ║         MAQUINA DE CAFE - TDD             ║");
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("  ║                                           ║");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("  ║   Hecho por:                              ║");
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("  ║     Bradley Castillo & Luis Duran         ║");
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("  ║                                           ║");
    Console.WriteLine("  ╚═══════════════════════════════════════════╝");
    Console.ResetColor();
}

void MostrarMenu(int saldo)
{
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("  ╔═══════════════════════════════════════════╗");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("  ║           MAQUINA DE CAFE                 ║");
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("  ╠═══════════════════════════════════════════╣");

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"  ║   Saldo: {saldo,-33}║");

    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("  ╠═══════════════════════════════════════════╣");

    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("  ║   1. Insertar monedas                     ║");
    Console.WriteLine("  ║   2. Mostrar saldo                        ║");
    Console.WriteLine("  ║   3. Mostrar menu de bebidas               ║");

    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("  ╠───────────────────────────────────────────╣");

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("  ║   4. Seleccionar Cafe          (100)      ║");
    Console.WriteLine("  ║   5. Seleccionar Te            ( 75)      ║");
    Console.WriteLine("  ║   6. Seleccionar Agua          ( 50)      ║");

    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("  ╠───────────────────────────────────────────╣");

    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("  ║   7. Obtener cambio                       ║");
    Console.WriteLine("  ║   8. Devolver monedas                     ║");

    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("  ║   9. Salir                                ║");

    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("  ╠═══════════════════════════════════════════╣");
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine("  ║   Bradley Castillo & Luis Duran           ║");
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("  ╚═══════════════════════════════════════════╝");

    Console.ResetColor();
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("  Seleccione una opcion: ");
    Console.ResetColor();
}

void MostrarMenuBebidas(MaquinaCafe maq)
{
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.WriteLine("  ┌───────────────────────────────────────────┐");
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("  │          MENU DE BEBIDAS                  │");
    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.WriteLine("  ├──────────┬──────────┬─────────────────────┤");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("  │ Bebida   │ Precio   │ Stock               │");
    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.WriteLine("  ├──────────┼──────────┼─────────────────────┤");

    foreach (var item in maq.ObtenerMenu())
    {
        var b = item.Value;
        Console.ForegroundColor = b.Stock > 0 ? ConsoleColor.Green : ConsoleColor.Red;
        Console.WriteLine($"  │ {b.Nombre,-9}│ {b.Precio,-9}│ {b.Stock,-20}│");
    }

    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.WriteLine("  └──────────┴──────────┴─────────────────────┘");
    Console.ResetColor();
}

void MostrarExito(string mensaje)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"  [OK] {mensaje}");
    Console.ResetColor();
}

void MostrarError(string mensaje)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"  [X] {mensaje}");
    Console.ResetColor();
}

void MostrarInfo(string mensaje)
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine($"  [i] {mensaje}");
    Console.ResetColor();
}
