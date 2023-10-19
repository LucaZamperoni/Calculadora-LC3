using System;

namespace Calculadora.logica
{
    public class Test
    {
        public static void Validar(string expresion)
        {
            if (expresion.Contains("("))
            {
                try
                {
                    if (Validaciones.EsValida(expresion) && Test1(expresion))
                    {
                        return;
                    }
                }
                catch (Exception exception)
                {
                    throw new Exception(exception.Message);
                }
                
                
            }
            else
            {
                try
                {
                    if (Validaciones.EsValida((expresion)))
                    {
                        return;
                    }
                }
                catch (Exception exception)
                {
                    throw new Exception(exception.Message);
                }
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