using CalculadoraLogica;

namespace CalculadoraTests;

public class TestValidaciones
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestValidacionesParentesis()
    {
        string expresion;

        expresion = "()(())"; // True
        Assert.IsTrue(Validaciones.Parentesis(expresion.ToCharArray()));

        expresion = ""; // True
        Assert.IsTrue(Validaciones.Parentesis(expresion.ToCharArray()));

        expresion = "(9-3)*0+(5/2)+7*0"; // True
        Assert.IsTrue(Validaciones.Parentesis(expresion.ToCharArray()));

        expresion =
            "(((((((-2)(-9))+((-15)/3))-(((-4)(7+(-3)))/2))(((-1)(-4))+(((-8)/2)+((-6)(-1)))))/(((((-2)(-5))+((-10)/2))-(((-3)(6+(-2)))/4))+(((-1)(-6))+(((-7)/2)+((-5)(-1))))))(((((-2)(-9))+((-15)/3))-(((-4)(7+(-3)))/2))+(((-1)(-4))+(((-8)/2)+((-6)(-1)))))-((((((-2)(-9))+((-15)/3))-(((-4)(7+(-3)))/2))/(((-1)(-4))+(((-8)/2)+((-6)(-1)))))+(((((-2)(-9))+((-15) / 3))-(((-4)(7+(-3)))/2))(((-1)(-4))-(((-8)/2)+((-6)*(-1)))))))"; // True
        Assert.IsTrue(Validaciones.Parentesis(expresion.ToCharArray()));

        expresion =
            "((((((-2)(-9))+((-15)/3))-(((-4)(7+(-3)))/2))(((-1)(-4))+(((-8)/2)+((-6)(-1)))))/(((((-2)(-5))+((-10)/2))-(((-3)(6+(-2)))/4))+(((-1)(-6))+(((-7)/2)+((-5)*(-1))))))"; // True
        Assert.IsTrue(Validaciones.Parentesis(expresion.ToCharArray()));

        expresion = "()(())(("; // False
        Assert.IsFalse(Validaciones.Parentesis(expresion.ToCharArray()));

        expresion = "()(())())"; // False
        Assert.IsFalse(Validaciones.Parentesis(expresion.ToCharArray()));

        expresion = ")"; // False
        Assert.IsFalse(Validaciones.Parentesis(expresion.ToCharArray()));

        expresion = "("; // False
        Assert.IsFalse(Validaciones.Parentesis(expresion.ToCharArray()));
    }

    [Test]
    public void TestValidacionesCaracteresPosibles()
    {
        string expresion;

        expresion = "+-*/0123456789()"; // True
        Assert.IsTrue(Validaciones.CaracteresPosibles(expresion.ToCharArray()));

        expresion = "(33+90.9()+-*)42/"; // True
        Assert.IsTrue(Validaciones.CaracteresPosibles(expresion.ToCharArray()));

        expresion = "(33+90.9()))42/[]"; // False
        Assert.IsFalse(Validaciones.CaracteresPosibles(expresion.ToCharArray()));

        expresion = "(33+90,9()))42/"; // False
        Assert.IsFalse(Validaciones.CaracteresPosibles(expresion.ToCharArray()));

        expresion = "{33+90,9()))42/}"; // False
        Assert.IsFalse(Validaciones.CaracteresPosibles(expresion.ToCharArray()));
    }

    [Test]
    public void TestValidacionesOperadores()
    {
        string expresion;

        expresion = "2+5"; // True
        Assert.IsTrue(Validaciones.Operadores(expresion.ToCharArray()));

        expresion = "(33+90)-42/5"; // True
        Assert.IsTrue(Validaciones.Operadores(expresion.ToCharArray()));

        expresion = "-4"; // True
        Assert.IsTrue(Validaciones.Operadores(expresion.ToCharArray()));

        expresion = "+4"; // True
        Assert.IsTrue(Validaciones.Operadores(expresion.ToCharArray()));

        expresion = "4--5"; // True
        Assert.IsTrue(Validaciones.Operadores(expresion.ToCharArray()));

        expresion = "*4"; // False
        Assert.IsFalse(Validaciones.Operadores(expresion.ToCharArray()));

        expresion = "33+90.-42"; // False
        Assert.IsFalse(Validaciones.Operadores(expresion.ToCharArray()));

        expresion = "(33+90)/"; // False
        Assert.IsFalse(Validaciones.Operadores(expresion.ToCharArray()));

        expresion = "/"; // False
        Assert.IsFalse(Validaciones.Operadores(expresion.ToCharArray()));

        expresion = "-"; // False
        Assert.IsFalse(Validaciones.Operadores(expresion.ToCharArray()));
    }

    [Test]
    public void TestValidacionesEsInicial()
    {
        string expresion;

        expresion = "+5"; // True
        Assert.IsTrue(Validaciones.EsOperadorInicial(expresion.ToCharArray(), '+'));

        expresion = "-5"; // True
        Assert.IsTrue(Validaciones.EsOperadorInicial(expresion.ToCharArray(), '-'));

        expresion = "*5"; // True
        Assert.IsTrue(Validaciones.EsOperadorInicial(expresion.ToCharArray(), '*'));

        expresion = "/5"; // True
        Assert.IsTrue(Validaciones.EsOperadorInicial(expresion.ToCharArray(), '/'));

        expresion = "5"; // False
        Assert.IsFalse(Validaciones.EsOperadorInicial(expresion.ToCharArray(), '/'));

        expresion = "5-"; // False
        Assert.IsFalse(Validaciones.EsOperadorInicial(expresion.ToCharArray(), '/'));
    }

    [Test]
    public void TestValidacionesEsFinal()
    {
        string expresion;

        expresion = "5+"; // True
        Assert.IsTrue(Validaciones.EsOperadorFinal(expresion.ToCharArray(), '+'));

        expresion = "5-"; // True
        Assert.IsTrue(Validaciones.EsOperadorFinal(expresion.ToCharArray(), '-'));

        expresion = "*"; // True
        Assert.IsTrue(Validaciones.EsOperadorFinal(expresion.ToCharArray(), '*'));

        expresion = "5/"; // True
        Assert.IsTrue(Validaciones.EsOperadorFinal(expresion.ToCharArray(), '/'));

        expresion = "5"; // False
        Assert.IsFalse(Validaciones.EsOperadorFinal(expresion.ToCharArray(), '/'));

        expresion = "-5"; // False
        Assert.IsFalse(Validaciones.EsOperadorFinal(expresion.ToCharArray(), '/'));
    }

    [Test]
    public void TestValidacionesExpresionVacia()
    {
        string expresion;

        expresion = ""; // True
        Assert.IsTrue(Validaciones.ExpresionVacia(expresion.ToCharArray()));

        expresion = "5"; // False
        Assert.IsFalse(Validaciones.ExpresionVacia(expresion.ToCharArray()));
    }

    [Test]
    public void TestEsValida()
    {
        string expresion;

        expresion = "((8--7))"; // True
        Assert.IsTrue(Validaciones.EsValida(expresion));

        expresion =
            "(((((((-2)(-9))+((-15)/3))-(((-4)(7+(-3)))/2))(((-1)(-4))+(((-8)/2)+((-6)(-1)))))/(((((-2)(-5))+((-10)/2))-(((-3)(6+(-2)))/4))+(((-1)(-6))+(((-7)/2)+((-5)(-1))))))(((((-2)(-9))+((-15)/3))-(((-4)(7+(-3)))/2))+(((-1)(-4))+(((-8)/2)+((-6)(-1)))))-((((((-2)(-9))+((-15)/3))-(((-4)(7+(-3)))/2))/(((-1)(-4))+(((-8)/2)+((-6)(-1)))))+(((((-2)(-9))+((-15)/3))-(((-4)(7+(-3)))/2))(((-1)(-4))-(((-8)/2)+((-6)*(-1)))))))";
        Assert.IsTrue(Validaciones.EsValida(expresion));

        expresion =
            "((((((-2)(-9))+((-15)/3))-(((-4)(7+(-3)))/2))(((-1)(-4))+(((-8)/2)+((-6)(-1)))))/(((((-2)(-5))+((-10)/2))-(((-3)(6+(-2)))/4))+(((-1)(-6))+(((-7)/2)+((-5)*(-1))))))"; // True
        Assert.IsTrue(Validaciones.EsValida(expresion));

        expresion = ""; // False
        Assert.IsFalse(Validaciones.EsValida(expresion));

        expresion = "("; // False
        Assert.IsFalse(Validaciones.EsValida(expresion));

        expresion = "((8--7)"; // False
        Assert.IsFalse(Validaciones.EsValida(expresion));
    }
    
    
}