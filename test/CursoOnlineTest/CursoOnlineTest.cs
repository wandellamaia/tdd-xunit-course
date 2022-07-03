using ExpectedObjects;
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
                CargaHoraria = 460,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = 1500,
            };
           

            var curso = new Curso(cursoEsperado.Nome,
                                  cursoEsperado.CargaHoraria,
                                  cursoEsperado.PublicoAlvo,
                                  cursoEsperado.Valor);

            Assert.Equal(curso.Nome, cursoEsperado.Nome);
            Assert.Equal(curso.CargaHoraria, cursoEsperado.CargaHoraria);
            Assert.Equal(curso.PublicoAlvo, cursoEsperado.PublicoAlvo);
            Assert.Equal(curso.Valor, cursoEsperado.Valor);

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
            public Curso(string nome, double cargaHoraria, PublicoAlvo publicoAlvo, double valor1)
            {
                Nome = nome;
                CargaHoraria = cargaHoraria;
                PublicoAlvo = publicoAlvo;
                Valor = valor1;

            }
            public string Nome { get; set; }
            public double CargaHoraria { get; set; }
            public PublicoAlvo PublicoAlvo { get; set; }
            public double Valor { get; set; }
        }

    
}
