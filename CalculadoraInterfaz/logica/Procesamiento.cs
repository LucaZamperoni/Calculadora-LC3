using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using nose.logica;

public class Procesamiento
{
    public static string ResolverExpresion(string Expresion)
    {
        if (Test.Validar(Expresion))
        {
            List<string> calculoCerrado = new List<string>();
            calculoCerrado.Add("(");
            calculoCerrado.Add(Expresion);
            calculoCerrado.Add(")");
            Expresion = string.Join("", calculoCerrado);
            var caracteres = Expresion.ToCharArray();

            while (caracteres.Contains('('))
            {
                caracteres = ResolverParentesis(caracteres);
            }

            var resultadoCadena = new string(caracteres);
            return resultadoCadena;
        }

        return "Ha ocurrido un error";
    }

    public static char[] ResolverParentesis(char[] caracteres)
    {
        for (int i = 0; i < caracteres.Length; i++)
        {
            if (!caracteres[i].Equals('(')) continue;
            var operacion = new List<char> { caracteres[i] };
            for (int j = i + 1; j < caracteres.Length; j++)
            {
                if (caracteres[j].Equals(')'))
                {
                    operacion.Add(caracteres[j]);
                    var resultado = ResolverOperacion(operacion);
                    var expresionCadena = new string(caracteres);
                    var operacionCadena = new string(operacion.ToArray());
                    expresionCadena = expresionCadena.Replace(operacionCadena, resultado.ToString());
                    return expresionCadena.ToCharArray();
                }

                if (caracteres[j].Equals('('))
                {
                    break;
                }

                operacion.Add(caracteres[j]);
            }
        }

        return caracteres;
    }

    public static double ResolverOperacion(List<char> operacion)
    {
        var operadoresPosibles = new[] { '+', '-', '*', '/' };
        var numeros = new List<double>();
        var operadores = new List<char>();
        var numero = new StringBuilder();

        for (int i = 0; i < operacion.Count; i++)
        {
            if (char.IsDigit(operacion[i]) || operacion[i].Equals('.'))
            {
                // Establece una cultura con punto como separador decimal
                CultureInfo culture = new CultureInfo("en-US");

                if (operacion[i].Equals('.'))
                {
                    numero.Append('.');
                }
                else
                {
                    numero.Append(operacion[i]);
                }
            }
            else
            {
                if (operadoresPosibles.Contains(operacion[i]))
                {
                    if (operacion[i].Equals('-') && (operadoresPosibles.Contains(operacion[i - 1]) ||
                                                     operacion[i - 1].Equals('(')))
                    {
                        numero.Append(operacion[i]);
                        continue;
                    }

                    operadores.Add(operacion[i]);
                }

                try
                {
                    if (numero.Length <= 0) continue;
                    numeros.Add(double.Parse(numero.ToString(), CultureInfo.InvariantCulture)); // Usa CultureInfo.InvariantCulture para evitar problemas de coma/punto
                    numero.Clear();
                }
                catch (Exception e)
                {
                    Console.WriteLine("La operación está mal redactada.");
                    throw;
                }
            }
        }

        var aux = new List<string>();
        for (int i = 0; i < numeros.Count + operadores.Count; i++)
        {
            if (i < numeros.Count)
            {
                aux.Add(numeros[i].ToString(CultureInfo.InvariantCulture)); // Usa CultureInfo.InvariantCulture para asegurarte de que se use punto como separador decimal
            }

            if (i < operadores.Count)
            {
                aux.Add(operadores[i].ToString());
            }
        }

        mostrarArreglo(aux, "Cuenta simple a resolver: ");

        do
        {
            aux = ResolverCuentaSimple(aux);
        } while (aux.Count > 1);
        return double.Parse(aux[0], CultureInfo.InvariantCulture); // Usa CultureInfo.InvariantCulture para asegurarte de que se use punto como separador decimal
    }

    public static List<string> ResolverCuentaSimple(List<string> aux)
    {
        double resultado;
        for (int i = 0; i < aux.Count; i++)
        {
            switch (aux[i])
            {
                case "*":
                    resultado = double.Parse(aux[i - 1], CultureInfo.InvariantCulture) * double.Parse(aux[i + 1], CultureInfo.InvariantCulture);
                    aux.RemoveAt(i);
                    aux.RemoveAt(i);
                    aux[i - 1] = resultado.ToString(CultureInfo.InvariantCulture);
                    mostrarArreglo(aux, "Multiplicación:");
                    break;
                case "/":
                    try
                    {
                        resultado = double.Parse(aux[i - 1], CultureInfo.InvariantCulture) / double.Parse(aux[i + 1], CultureInfo.InvariantCulture);
                        aux.RemoveAt(i);
                        aux.RemoveAt(i);
                        aux[i - 1] = resultado.ToString(CultureInfo.InvariantCulture);
                        mostrarArreglo(aux, "División:");
                    }
                    catch (DivideByZeroException)
                    {
                        Console.WriteLine("Estás tratando de dividir por 0.");
                    }
                    break;
            }
        }

        for (int i = 0; i < aux.Count; i++)
        {
            switch (aux[i])
            {
                case "+":
                    resultado = double.Parse(aux[i - 1], CultureInfo.InvariantCulture) + double.Parse(aux[i + 1], CultureInfo.InvariantCulture);
                    aux.RemoveAt(i);
                    aux.RemoveAt(i);
                    aux[i - 1] = resultado.ToString(CultureInfo.InvariantCulture);
                    mostrarArreglo(aux, "Suma:");
                    break;
                case "-":
                    resultado = double.Parse(aux[i - 1], CultureInfo.InvariantCulture) - double.Parse(aux[i + 1], CultureInfo.InvariantCulture);
                    aux.RemoveAt(i);
                    aux.RemoveAt(i);
                    aux[i - 1] = resultado.ToString(CultureInfo.InvariantCulture);
                    mostrarArreglo(aux, "Resta:");
                    break;
            }
        }

        return aux;
    }

    public static void mostrarArreglo<T>(List<T> arr, string mensaje)
    {
        Console.WriteLine(mensaje);
        foreach (var item in arr)
        {
            Console.Write($"[{item}] ");
        }

        Console.WriteLine();
    }
}
