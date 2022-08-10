using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using CorpuClinica.Site.Negocio.Cadastro;

namespace CorpuClinica.Site.Negocio.Testes
{
    [TestClass]
    public class ExameTeste
    {
        [TestMethod]
        public void Nome_QuandoObterNome_DeveRetornarNome()
        {
            //Arrange
            var exame = CriarExame();
            //Act

            //Assert
            exame.Nome.Should().NotBeNullOrWhiteSpace();
            exame.Nome.Should().Be("Doppler Carótidas Vertebrais");
        }
        [TestMethod]
        public void Nome_QuandoNomeForNulo_DeveRetornarExcecao()
        {
            //Arrange
            var exame = CriarExame(nome:"");
            //Act

            //Assert
            exame.Invoking(x => x.Validar()).ShouldThrow<ArgumentNullException>();
        }
        [TestMethod]
        public void Descricao_QuandoObterDescricao_DeveRetornarDescricao()
        {
            //Arrange
            var exame = CriarExame();
            //Act

            //Assert
            exame.Descricao.Should().NotBeNullOrWhiteSpace();
            exame.Descricao.Should().Be("Exame de diagnóstico da circulação carotídea / vertebral.");
        }
        [TestMethod]
        public void Descricao_QuandoDescricaoForNulo_DeveRetornarVazio()
        {
            //Arrange
            var exame = CriarExame(descricao:"");
            //Act

            //Assert
            exame.Descricao.Should().BeNullOrWhiteSpace();            
        }
        [TestMethod]
        public void Orientacao_QuandoObterOrientacao_DeveRetornarOrientacao()
        {
            //Arrange
            var exame = CriarExame();
            //Act

            //Assert
            exame.Orientacao.Should().NotBeNullOrWhiteSpace();
            exame.Orientacao.Should().Be("O exame não precisa de orientações de preparo; Trazer exames anteriores, se existentes.");
        }
        [TestMethod]
        public void Orientacao_QuandoOrientacaoForNulo_DeveRetornarVazio()
        {
            //Arrange
            var exame = CriarExame(orientacao:"");
            //Act

            //Assert
            exame.Orientacao.Should().BeNullOrWhiteSpace();            
        }
        [TestMethod]
        public void Foto_QuandoObterFoto_DeveRetornarPathFoto()
        {
            //Arrange
            var exame = CriarExame();
            //Act

            //Assert
            exame.Foto.Path.Should().NotBeNullOrWhiteSpace();
            exame.Foto.Path.Should().Be("c:/teste/Doppler.png");
        }
        [TestMethod]
        public void Foto_QuandoFotoForNulo_DeveRetornarVazioPathFoto()
        {
            //Arrange
            var exame = CriarExame();
            exame.Foto.Path = "";
            //Act

            //Assert
            exame.Foto.Path.Should().BeNullOrWhiteSpace();            
        }
        [TestMethod]
        public void Ativo_QuandoExameAtivo_DeveRetornarTrue()
        {
            //Arrange
            var exame = CriarExame();
            //Act

            //Assert
            exame.Ativo.Should().BeTrue();
        }
        [TestMethod]
        public void Ativo_QuandoExameInativo_DeveRetornarFalse()
        {
            //Arrange
            var exame = CriarExame(ativo:false);
            //Act

            //Assert
            exame.Ativo.Should().BeFalse();
        }
        [TestMethod]
        public void Validar_QuandoObjetoValido_DeveRetornarTrue()
        {
            //Arrange
            var exame = CriarExame();
            //Act

            //Assert
            exame.Validar().Should().BeTrue();
        }
        [TestMethod]
        public void ToString_QuandoChamarToString_DeveRetornarNome()
        {
            //Arrange
            var exame = CriarExame();
            //Act

            //Assert
            exame.ToString().Should().Be("Doppler Carótidas Vertebrais");
        }
        private Exame CriarExame(string nome= "Doppler Carótidas Vertebrais", string descricao= "Exame de diagnóstico da circulação carotídea / vertebral.", string orientacao= "O exame não precisa de orientações de preparo; Trazer exames anteriores, se existentes.", bool ativo = true)
        {
            var exame = new Exame(1, nome, descricao, orientacao, new Foto(1, "c:/teste/Doppler.png"), ativo);

            return exame;
        }
    }
}
