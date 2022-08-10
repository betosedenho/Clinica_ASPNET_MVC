using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using CorpuClinica.Site.Negocio.Cadastro;

namespace CorpuClinica.Site.Negocio.Testes
{
    [TestClass]
    public class EspecialidadeTeste
    {
        [TestMethod]
        public void Nome_QuandoObterNome_DeveRetornarNome()
        {
            //Arrange
            var especialidade = CriarEspecialidade();
            //Act

            //Assert
            especialidade.Nome.Should().NotBeNullOrWhiteSpace();
            especialidade.Nome.Should().Be("Cardiologia");
        }
        [TestMethod]
        public void Nome_QuandoNomeNulo_DeveRetornarExcecao()
        {
            //Arrange
            var especialidade = CriarEspecialidade(nome: "");
            //Act

            //Assert
            especialidade.Invoking(x => x.Validar()).ShouldThrow<ArgumentNullException>();                      
        }
        [TestMethod]
        public void Descricao_QuandoObterDescricao_DeveRetornarDescricao()
        {
            //Arrange
            var especialidade = CriarEspecialidade();
            //Act

            //Assert
            especialidade.Descricao.Should().NotBeNullOrWhiteSpace();
            especialidade.Descricao.Should().Be("Especialidade sobre assuntos do coração");
        }
        [TestMethod]
        public void Descricao_QuandoDescricaoForNulo_DeveRetornarVazio()
        {
            //Arrange
            var especialidade = CriarEspecialidade(descricao: "");
            //Act

            //Assert
            especialidade.Descricao.Should().BeNullOrWhiteSpace();           
        }
        [TestMethod]
        public void Foto_QuandoObterFoto_DeveRetornarPathFoto()
        {
            //Arrange
            var especialidade = CriarEspecialidade();
            //Act

            //Assert
            especialidade.Foto.Path.Should().NotBeNullOrWhiteSpace();
            especialidade.Foto.Path.Should().Be("c:/teste/Coracao.jpg");
        }
        [TestMethod]
        public void Foto_QuandoFotoForNulo_DeveRetornarPathFotoVazio()
        {
            //Arrange
            var especialidade = CriarEspecialidade();
            especialidade.Foto.Path = "";
            //Act

            //Assert
            especialidade.Foto.Path.Should().BeNullOrWhiteSpace();           
        }
        [TestMethod]
        public void Ativo_QuandoEspecialidadeAtiva_DeveRetornarTrue()
        {
            //Arrange
            var especialidade = CriarEspecialidade();
            //Act

            //Assert
            especialidade.Ativo.Should().BeTrue();
        }
        [TestMethod]
        public void Ativo_QuandoEspecialidadeNaoAtiva_DeveRetornarFalse()
        {
            //Arrange
            var especialidade = CriarEspecialidade(ativo: false);
            //Act

            //Assert
            especialidade.Ativo.Should().BeFalse();
        }
        [TestMethod]
        public void Validar_QuandoObjetoForValido_DeveRetornarTrue()
        {
            //Arrange
            var especialidade = CriarEspecialidade();
            //Act

            //Assert
            especialidade.Validar().Should().BeTrue();
        }
        [TestMethod]
        public void ToString_QuandoObterToString_DeveRetornarNome()
        {
            //Arrange
            var especialidade = CriarEspecialidade();
            //Act

            //Assert
            especialidade.ToString().Should().Be("Cardiologia");
        }
        private Especialidade CriarEspecialidade(string nome="Cardiologia", string descricao="Especialidade sobre assuntos do coração", bool ativo = true)
        {
            var especialidade = new Especialidade(1, nome, descricao, new Foto(1, "c:/teste/Coracao.jpg"), ativo);

            return especialidade;
        }
    }
}
