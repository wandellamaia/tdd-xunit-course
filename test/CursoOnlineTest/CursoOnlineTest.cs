using ExpectedObjects;
using System;
using Xunit;

namespace CursoOnlineTest
{
    public class CursoTest
    {
        [Fact]
        public void DeveCriarCurso()
        {
            var cursoEsperado = new
            {
                Nome = "Ciência da Computação",
                CargaHoraria = (double)460,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = (double)1500,
            };
           

            var curso = new Curso(cursoEsperado.Nome,
                                  cursoEsperado.CargaHoraria,
                                  cursoEsperado.PublicoAlvo,
                                  cursoEsperado.Valor);

            cursoEsperado.ToExpectedObject().ShouldMatch(curso);

        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void NaoDeveTerCargaHorariaMenorQue1(double cargaHorariaInvalida)
        {
            var cursoEsperado = new
            {
                Nome = "Ciência da Computação",
                CargaHoraria = (double)80,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = (double)1500,
            };


            var curso = new Curso(cursoEsperado.Nome,
                                  cursoEsperado.CargaHoraria,
                                  cursoEsperado.PublicoAlvo,
                                  cursoEsperado.Valor);

          
            string message = Assert.Throws<ArgumentException>(() => new Curso(cursoEsperado.Nome,
                                  cargaHorariaInvalida,
                                  cursoEsperado.PublicoAlvo,
                                  cursoEsperado.Valor)).Message;

            Assert.Equal("Carga horária inválida", message);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void CursoNaoDeveTerNomeVazio(string nomeInvalido)
        {
            var cursoEsperado = new
            {
                Nome = "Ciência da Computação",
                CargaHoraria = 460,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = 1500,
            };

            string message = Assert.Throws<ArgumentException>(() => new Curso(nomeInvalido,
                                  cursoEsperado.CargaHoraria,
                                  cursoEsperado.PublicoAlvo,
                                  cursoEsperado.Valor)).Message;

            Assert.Equal("Nome inválido", message);
        }
    }
    public enum PublicoAlvo
    {
        Estudante,
        Universitário,
        Empregado,
        Empreendendor
    }
    public class Curso
        {
            public Curso(string nome, double cargaHoraria, PublicoAlvo publicoAlvo, double valor)
            {
                if (string.IsNullOrEmpty(nome))
                    throw new ArgumentException("Nome inválido");
                if (cargaHoraria < 1)
                    throw new ArgumentException("Carga horária inválida");
                if (valor < 1)
                    throw new ArgumentException("Valor inválida");

                Nome = nome;
                CargaHoraria = cargaHoraria;
                PublicoAlvo = publicoAlvo;
                Valor = valor;

            }
            public string Nome { get; set; }
            public double CargaHoraria { get; set; }
            public PublicoAlvo PublicoAlvo { get; set; }
            public double Valor { get; set; }
        }
}
