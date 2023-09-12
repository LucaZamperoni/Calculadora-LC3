using CalculadoraLogica;

namespace CalculadoraTests;

public class TestProcesamiento
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestResolverExpresion()
    {
        var expresion = "2+7*(2+1-3)-(3/1.5)";
        var resultadoEsperado = 0.0;
        Assert.That(Procesamiento.ResolverExpresion(expresion), Is.EqualTo(resultadoEsperado));

        expresion =
            "(((((((-2)*(-9))+((-15)/3))-(((-4)*(7+(-3)))/2))*(((-1)*(-4))+(((-8)/2)+((-6)*(-1)))))/(((((-2)*(-5))+((-10)/2))-(((-3)*(6+(-2)))/4))+(((-1)*(-6))+(((-7)/2)+((-5)*(-1))))))*(((((-2)*(-9))+((-15)/3))-(((-4)*(7+(-3)))/2))+(((-1)*(-4))+(((-8)/2)+((-6)*(-1)))))-((((((-2)*(-9))+((-15)/3))-(((-4)*(7+(-3)))/2))/(((-1)*(-4))+(((-8)/2)+((-6)*(-1)))))+(((((-2)*(-9))+((-15)/3))-(((-4)*(7+(-3)))/2))*(((-1)*(-4))-(((-8)/2)+((-6)*(-1)))))))";
        resultadoEsperado = 173.9838;
        Assert.That(Procesamiento.ResolverExpresion(expresion), Is.EqualTo(resultadoEsperado).Within(0.0001));

        expresion = "1-4/4";
        resultadoEsperado = 0.0;
        Assert.That(Procesamiento.ResolverExpresion(expresion), Is.EqualTo(resultadoEsperado));

        expresion = "1/-4";
        resultadoEsperado = -0.25;
        Assert.That(Procesamiento.ResolverExpresion(expresion), Is.EqualTo(resultadoEsperado));

        expresion = "-(1)-3";
        resultadoEsperado = -4;
        Assert.That(Procesamiento.ResolverExpresion(expresion), Is.EqualTo(resultadoEsperado));
    }

    [Test]
    public void TestResolverParentesis()
    {
        var expresion = "2+7*(2+1-3)-(3/1.5)".ToCharArray();
        var resultadoEsperado = "2+7*0-(3/1.5)".ToCharArray();

        CollectionAssert.AreEqual(resultadoEsperado,
            Procesamiento.ResolverParentesis(expresion));

        expresion = "((3-6*(2/2)))".ToCharArray();
        resultadoEsperado = "((3-6*1))".ToCharArray();

        CollectionAssert.AreEqual(resultadoEsperado,
            Procesamiento.ResolverParentesis(expresion));
    }

    [Test]
    public void TestResolverOperacion()
    {
        var operacion = "(10+8-3/1.5)".ToCharArray().ToList();
        var resultadoEsperado = 16d;

        Assert.That(Procesamiento.ResolverOperacion(operacion), Is.EqualTo(resultadoEsperado));

        operacion = "(5*-5-5)".ToCharArray().ToList();
        resultadoEsperado = -30d;
        
        Assert.That(Procesamiento.ResolverOperacion(operacion), Is.EqualTo(resultadoEsperado));
    }

    [Test]
    public void TestResolverCuentaSimple()
    {
    }
}