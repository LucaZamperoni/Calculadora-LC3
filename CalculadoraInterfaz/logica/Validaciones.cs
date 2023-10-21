
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public abstract class Validaciones
{
    public static bool Parentesis(char[] caracteres)
    {
        List<char> soloParentesis = caracteres.Where(c => c.Equals('(') || c.Equals(')')).ToList();
        List<char> parentesis = new List<char>();
        foreach (var p in soloParentesis)
        {
            if (p == '(')
            {
                parentesis.Add('(');
            }
            else if (p == ')')
            {
                if (parentesis.Count > 0 && parentesis[parentesis.Count - 1] == '(')
                {
                    parentesis.RemoveAt(parentesis.Count - 1);
                }
                else
                {
                    parentesis.Add('_');
                }
            }
        }

        if (parentesis.Count != 0)
        {
            throw new Exception("Los parentesis estan mal cerrados");
        }

        return parentesis.Count == 0;
    }

    public static bool CaracteresPosibles(char[] caracteres)
    {
        char[] caracteresValidos =
            { '+', '-', '*', '/', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '(', ')', '.' };
        if (!caracteres.All(c => caracteresValidos.Contains(c)))
        {
            throw new Exception("Hay caracteres dentro de la operacion que son invalidos");
        }
        return caracteres.All(c => caracteresValidos.Contains(c));
    }

    public static bool Operadores(char[] caracteres)
    {
        char[] operadoresValidos = { '+', '-', '*', '/' };
        char[] operandosValidos = { '(', ')', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '-' };
        for (var i = 0; i < caracteres.Length; i++)
        {
            var c = caracteres[i];
            if (!operadoresValidos.Contains(c)) continue;
            if (EsOperadorInicial(caracteres, c) && (c.Equals('*') || c.Equals('/')))
            {
                throw new Exception("El operador inicial de la cuenta es invalido");
            }
            
            if (!EsOperadorInicial(caracteres, c))
            {
                if (EsOperadorFinal(caracteres, c) || !operandosValidos.Contains(caracteres[i - 1]) ||
                    !operandosValidos.Contains(caracteres[i + 1]))
                {
                    throw new Exception("Los operadores estan posicionados de manera incorrecta");
                }else if (c.Equals('*') || c.Equals('/'))
                {
                    if ((caracteres[i - 1] == '(') || caracteres[i + 1] == ')')
                    {
                        throw new Exception("Los operadores están posicionados de manera incorrecta");
                    }
                }

            }
        }

        return true;
    }

    public static bool EsOperadorInicial(char[] caracteres, char operador)
    {
        return caracteres[0].Equals(operador) && caracteres.Length > 1;
    }

    public static bool EsOperadorFinal(char[] caracteres, char operador)
    {
        return caracteres[caracteres.Length - 1].Equals(operador);
    }

    public static bool ExpresionVacia(char[] caracteres)
    {
        if (caracteres.Length == 0)
        {
            throw new Exception("La operacion esta vacia");
        }
        return caracteres.Length == 0;
    }

    public static bool EsValida(string expresion)
    {
        char[] arreglo = expresion.ToCharArray();
        return Parentesis(arreglo) && Operadores(arreglo) &&
               CaracteresPosibles(arreglo) && !ExpresionVacia(arreglo);
    }
}