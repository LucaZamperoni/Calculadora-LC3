
using System.Collections.Generic;
using System.Linq;

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

        return parentesis.Count == 0;
    }

    public static bool CaracteresPosibles(char[] caracteres)
    {
        char[] caracteresValidos =
            { '+', '-', '*', '/', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '(', ')', '.' };
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
                return false;
            }

            if (!EsOperadorInicial(caracteres, c))
            {
                if (EsOperadorFinal(caracteres, c) || !operandosValidos.Contains(caracteres[i - 1]) ||
                    !operandosValidos.Contains(caracteres[i + 1]))
                {
                    return false;
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
        return caracteres.Length == 0;
    }

    public static bool EsValida(string expresion)
    {
        char[] arreglo = expresion.ToCharArray();
        return Parentesis(arreglo) && Operadores(arreglo) &&
               CaracteresPosibles(arreglo) && !ExpresionVacia(arreglo);
    }
}