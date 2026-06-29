# MaquinaCafeTDD

Proyecto de practica academica que implementa una Maquina de Cafe virtual utilizando la metodologia TDD (Test-Driven Development) con C# y NUnit.

## Que es TDD?

TDD (Test-Driven Development) es una metodologia de desarrollo de software que sigue un ciclo de tres pasos:

### RED

Se escribe un test que describe el comportamiento esperado. Como el codigo aun no existe, el test falla (rojo).

### GREEN

Se escribe el codigo minimo necesario para que el test pase (verde). No se busca la solucion perfecta, solo que el test sea exitoso.

### REFACTOR

Una vez que el test pasa, se mejora el codigo eliminando duplicacion, mejorando nombres y simplificando la logica, sin cambiar el comportamiento. Los tests deben seguir pasando despues del refactor.

Este ciclo se repite para cada nuevo requisito o funcionalidad.

## Tecnologias usadas

- C#
- .NET 9
- NUnit

## Estructura del proyecto

```
MaquinaCafeTDD
├── MaquinaCafe
│   ├── MaquinaCafe.cs      # Clase principal y record Bebida
│   ├── Program.cs           # Programa de consola interactivo
│   └── MaquinaCafe.csproj
├── MaquinaCafe.Tests
│   ├── MaquinaCafeTests.cs  # 8 casos de prueba
│   └── MaquinaCafe.Tests.csproj
├── README.md
└── MaquinaCafeTDD.sln
```

## Como ejecutar el proyecto

```bash
dotnet restore
dotnet run --project MaquinaCafe
```

## Como ejecutar las pruebas

```bash
dotnet test
```

## Resultado esperado

Todos los 8 casos de prueba deben pasar:

| Test | Descripcion |
|------|-------------|
| TC-01 | InsertarMoneda debe aumentar el saldo |
| TC-02 | SeleccionarBebida con saldo suficiente retorna true |
| TC-03 | SeleccionarBebida con saldo insuficiente retorna false |
| TC-04 | ObtenerCambio devuelve el saldo restante |
| TC-05 | SeleccionarBebida inexistente lanza ArgumentException |
| TC-06 | ObtenerMenu retorna tres bebidas con sus precios |
| TC-07 | DevolverMonedas deja el saldo en cero |
| TC-08 | SeleccionarBebida sin stock retorna false |
