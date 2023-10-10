using System;

namespace nose.logica
{
    public class Test
    {
        public static bool Validar(string expresion)
        {
            if (expresion.Contains("("))
            {
                return Validaciones.EsValida(expresion) && Test1(expresion);
            }
            else
            {
                return Validaciones.EsValida(expresion);
            }
        }

        public static bool Test1(string expresion)
        {
            char[] operadores = { '+', '-', '*', '/' };
            bool operadorEncontrado = false;
        
            for (int i = 0; i < expresion.Length; i++)
            {
                char caracter = expresion[i];
            
                if (caracter == '(')
                {
                    // Verificar si hay un operador antes del paréntesis que abre
                    if (i > 0 && Array.Exists(operadores, op => op == expresion[i - 1]))
                    {
                        operadorEncontrado = true;
                        break;
                    }
                }
            }
        
            return operadorEncontrado;
        }
    }
}