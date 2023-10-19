using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nose.logica;

public class Procesamiento
{
    public static string ResolverExpresion(string Expresion)
    {
        try
        {
            Test.Validar((Expresion));
            // Encierro la expresión dentro de paréntesis para que al final se tome como un cálculo más a realizar.
            List<string> calculoCerrado = new List<string>();
            calculoCerrado.Add("(");
            calculoCerrado.Add(Expresion);
            calculoCerrado.Add(")");
            Expresion = string.Join("", calculoCerrado);
            var caracteres = Expresion.ToCharArray();

            // WHILE (hasta que no queden parentesis).
            while (caracteres.Contains('('))
            {
                caracteres = ResolverParentesis(caracteres);
            }

            var resultadoCadena = new string(caracteres);
            return resultadoCadena;

        }
        catch (Exception exception)
        {
            return exception.Message;
        }
    }

    public static char[] ResolverParentesis(char[] caracteres)
    {
        // - FOR (encuentra primer parentesis interno).
        // - - FOR (llena el calculo y lo pasa a la funcion).
        // - - - ResolverOperacion y reemplazar operacion por resultado.
        for (int i = 0; i < caracteres.Length; i++)
        {
            if (!caracteres[i].Equals('(')) continue;
            var operacion = new List<char> { caracteres[i] };
            for (int j = i + 1; j < caracteres.Length; j++)
            {
                if (caracteres[j].Equals(')'))
                {
                    operacion.Add(caracteres[j]); // Agrego el ultimo parentesis.

                    var resultado = ResolverOperacion(operacion);

                    // Reemplazar parentesis por resultado.
                    var expresionCadena = new string(caracteres);
                    var operacionCadena = new string(operacion.ToArray());
                    expresionCadena = expresionCadena.Replace(operacionCadena, resultado.ToString());

                    return expresionCadena.ToCharArray();
                }

                if (caracteres[j].Equals('(')) // Si encuentro otro parentesis significa que hay otra operación interna.
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

        // Separo la operación en números y en operadores.
        // Luego los números (hasta el momento char individuales) se utilizan para conformar el número completo.
        for (int i = 0; i < operacion.Count; i++)
        {
            if (char.IsDigit(operacion[i]) || operacion[i].Equals('.'))
            {
                numero.Append(operacion[i]);
            }
            else
            {
                if (operadoresPosibles.Contains(operacion[i]))
                {
                    // Si el operador es un "-", reviso el caracter anterior para saber si se trata de un numero negativo.
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
                    numeros.Add(double.Parse(numero.ToString()));
                    numero.Clear();
                }
                catch (Exception e)
                {
                    throw new Exception("La operacion esta mal redactada");
                }
            }
        }

        // Conformo la nueva operación (en formato cadena) combinando números completos y operadores.
        var aux = new List<string>();
        for (int i = 0; i < numeros.Count + operadores.Count; i++)
        {
            if (i < numeros.Count)
            {
                aux.Add(numeros[i].ToString());
            }

            if (i < operadores.Count)
            {
                aux.Add(operadores[i].ToString());
            }
        }

        mostrarArreglo(aux, "Cuenta simple a Resolver: ");

        // Resuelvo las cuentas simples hasta que la lista original tenga sólo un número.
        // (Misma lógica que resolver todos los paréntesis de la expresión).
        do
        {
            aux = ResolverCuentaSimple(aux);
        } while (aux.Count > 1);
        return double.Parse(aux[0]);
    }

    public static List<string> ResolverCuentaSimple(List<string> aux)
    {
        double resultado;
        try
        {
            for (int i = 0; i < aux.Count; i++)
            {
                // Primero se resuelven las multiplicaciones y divisiones.
                switch (aux[i])
                {
                    case "*":
                        resultado = double.Parse(aux[i - 1]) * double.Parse(aux[i + 1]);
                        aux.RemoveAt(i);
                        aux.RemoveAt(i);
                        aux[i - 1] = resultado.ToString();
                        mostrarArreglo(aux, "Multiplicacion:");
                        break;
                    case "/":
                        if (double.Parse(aux[i + 1]) == 0)
                        {
                            throw new Exception("No se puede dividir entre 0");
                        }
                        resultado = double.Parse(aux[i - 1]) / double.Parse(aux[i + 1]);
                        aux.RemoveAt(i);
                        aux.RemoveAt(i);
                        aux[i - 1] = resultado.ToString();
                        mostrarArreglo(aux, "Division:");
                        break;
                }
            }
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
        }
        

        // Solo quedan por resolver las sumas y restas.
        try
        {
            for (int i = 0; i < aux.Count; i++)
            {
                switch (aux[i])
                {
                    case "+":
                        resultado = double.Parse(aux[i - 1]) + double.Parse(aux[i + 1]);
                        aux.RemoveAt(i);
                        aux.RemoveAt(i);
                        aux[i - 1] = resultado.ToString();
                        mostrarArreglo(aux, "Suma:");
                        break;
                    case "-":
                        resultado = double.Parse(aux[i - 1]) - double.Parse(aux[i + 1]);
                        aux.RemoveAt(i);
                        aux.RemoveAt(i);
                        aux[i - 1] = resultado.ToString();
                        mostrarArreglo(aux, "Resta:");
                        break;
                }
            }
        }
        catch (Exception e)
        {
            throw new Exception("No fue posible resolver la operacion de suma/resta");
        }
        

        return aux;
    }

    public static void mostrarArreglo<T>(List<T> arr, string mensaje)
    {
        Console.WriteLine(mensaje);
        foreach (var _ in arr)
        {
            Console.Write($"[{_}]");
        }

        Console.WriteLine();
    }
}