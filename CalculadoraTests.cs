using FluentAssertions;
using NUnit.Framework;

namespace DemoTDD
{
    class CalculadoraTests
    {
        private Calculadora Calculadora = new Calculadora();

        [Test]
        public void Deve_somar_dois_numeros()
        {
            var valorRetornado = Calculadora.Calcular(1, 1, "+");
            valorRetornado.Should().Be(2);
        }
    }
}
