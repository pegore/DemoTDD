using FluentAssertions;
using NUnit.Framework;
using System;

namespace DemoTDD
{
    class CalculadoraTests
    {
        private Calculadora Calculadora = new Calculadora();

        [Test]
        [TestCase("0",0)]
        [TestCase("1",1)]
        public void Deve_receber_string_retornar_valor_inteiro(string entrada, int resultado)
        {
            var valorRetornado = Calculadora.Calcular(entrada);
            valorRetornado.Should().Be(resultado);
        }

        /*[Test]
        [TestCase("1,2", 12)]
        [TestCase("1", 1)]
        public void ConcatenarValores(string entrada, int resultado)
        {
            var valorRetornado = Calculadora.Calcular(entrada);
            valorRetornado.Should().Be(resultado);
        }*/

        [Test]
        [TestCase("1,2", 3)]
        public void SomarValores(string entrada, int resultado)
        {
            var valorRetornado = Calculadora.Calcular(entrada);
            valorRetornado.Should().Be(resultado);
        }

        [Test]
        [TestCase("", 0)]
        public void RetornarZero(string entrada, int resultado)
        {
            var valorRetornado = Calculadora.Calcular(entrada);
            valorRetornado.Should().Be(resultado);
        }

        [Test]
        [TestCase("1,2,2,3,4,1", 13)]
        public void QuantidadeDeNumerosIndeterminada(string entrada, int resultado)
        {
            var valorRetornado = Calculadora.Calcular(entrada);
            valorRetornado.Should().Be(resultado);
        }

        [Test]
        [TestCase("1\n2,3", 6)]
        public void TratarQuebraLinha(string entrada, int resultado)
        {
            var valorRetornado = Calculadora.Calcular(entrada);
            valorRetornado.Should().Be(resultado);
        }


        [Test]
        [TestCase("//;\n1;2;3;4", 10)]
        public void TratarDelimitador(string entrada, int resultado)
        {
            var valorRetornado = Calculadora.Calcular(entrada);
            valorRetornado.Should().Be(resultado);
        }

        [Test]
        [TestCase("1,2,-3,4", -3)]
        public void TratarNumeroNegativo(string entrada, int resultado)
        {
            try
            {
                var valorRetornado = Calculadora.Calcular(entrada);
                valorRetornado.Should().NotBe(resultado);
                

            }
            catch (Exception e)
            {
                e.Message.Should().Be("Número negativo não permitido: " + resultado);
            }
        }


        [Test]
        [TestCase("1, 2, 1001, 4", 7)]
        [TestCase("1001, 1002" , 0)]
        public void IgnorarMil(string entrada, int resultado)
        {
            var valorRetornado = Calculadora.Calcular(entrada);
            valorRetornado.Should().Be(resultado);
        }

        [Test]
        [TestCase("//[***]\n4***1***2", 7)]
        public void TratarDelimitadorCustomizado(string entrada, int resultado)
        {
            var valorRetornado = Calculadora.Calcular(entrada);
            valorRetornado.Should().Be(resultado);
        }

        [Test]
        [TestCase("//[%][$]\n8$2%0", 10)]
        public void TratarMultiDelimitadores(string entrada, int resultado)
        {
            var valorRetornado = Calculadora.Calcular(entrada);
            valorRetornado.Should().Be(resultado);
        }

        [Test]
        [TestCase("//[%%][$$$]\n6$$$2%%7", 15)]
        public void TratarMultiDelimitadoresMaior(string entrada, int resultado)
        {
            var valorRetornado = Calculadora.Calcular(entrada);
            valorRetornado.Should().Be(resultado);
        }
    }
}
