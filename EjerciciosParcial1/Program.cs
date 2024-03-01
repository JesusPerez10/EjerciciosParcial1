using System;

class Program
{
    // Función para realizar la operación matemática según el operador ingresado
    static double RealizarOperacion(double numero1, double numero2, char operador)
    {
        switch (operador)
        {
            case '+':
                return numero1 + numero2;
            case '-':
                return numero1 - numero2;
            case '*':
                return numero1 * numero2;
            case '/':
                if (numero2 != 0)
                {
                    return numero1 / numero2;
                }
                else
                {
                    throw new DivideByZeroException("No se puede dividir por cero.");
                }
            default:
                throw new InvalidOperationException("Operador no válido.");
        }
    }

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Menú Principal:");
            Console.WriteLine("1. Calcular factorial");
            Console.WriteLine("2. Calcular raíz cuadrada");
            Console.WriteLine("3. Realizar operación matemática");
            Console.WriteLine("4. Imprimir tabla de multiplicar");
            Console.WriteLine("5. Adivinar número secreto");
            Console.WriteLine("6. Salir del programa");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1": // Calcular factorial
                    Console.Write("Ingrese un número entero positivo: ");
                    int numeroFactorial;
                    if (!int.TryParse(Console.ReadLine(), out numeroFactorial) || numeroFactorial < 0)
                    {
                        Console.WriteLine("Error: Debe ingresar un número entero positivo.");
                        break;
                    }
                    long factorial = 1;
                    for (int i = 2; i <= numeroFactorial; i++)
                    {
                        factorial *= i;
                    }
                    Console.WriteLine($"El factorial de {numeroFactorial} es: {factorial}");
                    break;

                case "2": // Calcular raíz cuadrada
                    Console.Write("Ingrese un número: ");
                    double numeroRaiz;
                    if (!double.TryParse(Console.ReadLine(), out numeroRaiz) || numeroRaiz < 0)
                    {
                        Console.WriteLine("Error: Debe ingresar un número válido.");
                        break;
                    }
                    double raizCuadrada = Math.Sqrt(numeroRaiz);
                    Console.WriteLine($"La raíz cuadrada de {numeroRaiz} es: {raizCuadrada}");
                    break;

                case "3": // Realizar operación matemática
                    try
                    {
                        Console.Write("Ingrese el primer número: ");
                        double numero1;
                        if (!double.TryParse(Console.ReadLine(), out numero1))
                        {
                            Console.WriteLine("Error: Debe ingresar un número válido.");
                            break;
                        }

                        Console.Write("Ingrese el segundo número: ");
                        double numero2;
                        if (!double.TryParse(Console.ReadLine(), out numero2))
                        {
                            Console.WriteLine("Error: Debe ingresar un número válido.");
                            break;
                        }

                        Console.Write("Ingrese el operador (+, -, *, /): ");
                        char operador = char.Parse(Console.ReadLine());

                        double resultado = RealizarOperacion(numero1, numero2, operador);
                        Console.WriteLine($"El resultado de la operación es: {resultado}");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Error: Ingrese números válidos.");
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("Error: Número fuera de rango.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                    break;

                case "4": // Imprimir tabla de multiplicar
                    Console.Write("Ingrese un número para mostrar su tabla de multiplicar del 1 al 10: ");
                    int numeroTabla;
                    if (!int.TryParse(Console.ReadLine(), out numeroTabla))
                    {
                        Console.WriteLine("Error: Debe ingresar un número entero válido.");
                        break;
                    }
                    for (int i = 1; i <= 10; i++)
                    {
                        Console.WriteLine($"{numeroTabla} x {i} = {numeroTabla * i}");
                    }
                    break;

                case "5": // Adivinar número secreto
                    Random random = new Random();
                    int numeroSecreto = random.Next(1, 101);
                    int intentos = 0;
                    while (true)
                    {
                        Console.Write("Introduzca un número entre 1 y 100: ");
                        int numeroUsuario;
                        if (!int.TryParse(Console.ReadLine(), out numeroUsuario))
                        {
                            Console.WriteLine("Error: Debe ingresar un número válido.");
                            continue;
                        }
                        intentos++;
                        if (numeroUsuario < 1 || numeroUsuario > 100)
                        {
                            Console.WriteLine("El número debe estar entre 1 y 100.");
                            continue;
                        }
                        if (numeroUsuario == numeroSecreto)
                        {
                            Console.WriteLine($"¡Felicidades! ¡Ha adivinado el número secreto ({numeroSecreto}) en {intentos} intentos!");
                            break;
                        }
                        else if (numeroUsuario < numeroSecreto)
                        {
                            Console.WriteLine("El número secreto es mayor.");
                        }
                        else
                        {
                            Console.WriteLine("El número secreto es menor.");
                        }
                    }
                    break;

                case "6": // Salir del programa
                    Console.WriteLine("Saliendo del programa...");
                    return;

                default: // Opción no válida
                    Console.WriteLine("Opción no válida. Por favor, seleccione una opción del menú.");
                    break;
            }

            Console.WriteLine(); 
        }
    }
}