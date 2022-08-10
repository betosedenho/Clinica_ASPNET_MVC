using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using CorpuClinica.Site.Negocio.Cadastro;

namespace CorpuClinica.Site.Negocio.Testes
{
    [TestClass]
    public class ConvenioTeste
    {
        [TestMethod]
        public void Nome_QuandoObterNome_DeveRetornarNome()
        {
            //Arrange
            var convenio = CriarConvenio();
            //Act

            //Assert
            convenio.Nome.Should().NotBeNullOrWhiteSpace();
            convenio.Nome.Should().Be("Unimed Paulista");            
        }
        [TestMethod]        
        public void Nome_QuandoNomeNulo_DeveRetornarExcecao()
        {
            //Arrange
            var convenio = CriarConvenio("");
            //Act

            //Assert 
            convenio.Invoking(x=> x.Validar()).ShouldThrow<ArgumentNullException>();
        }
        [TestMethod]
        public void Link_QuandoObterLink_DeveRetornarLink()
        {
            //Arrange
            var convenio = CriarConvenio();
            //Act

            //Assert
            convenio.Link.Should().NotBeNullOrWhiteSpace();
            convenio.Link.Should().Be("http://www.unimed.com.br");            
        }
        [TestMethod]
        public void Link_QuandoLinkVazio_DeveRetornarVazio()
        {
            //Arrange
            var convenio = CriarConvenio(link: "");
            //Act

            //Assert
            convenio.Link.Should().BeNullOrWhiteSpace();
        }
        [TestMethod]
        public void Ativo_QuandoObterConvenioAtivo_DeveRetornarTrue()
        {
            //Arrange
            var convenio = CriarConvenio();
            //Act

            //Assert
            convenio.Ativo.Should().BeTrue();            
        }
        [TestMethod]
        public void Ativo_QuandoObterConvenioNaoAtivo_DeveRetornarFalse()
        {
            //Arrange
            var convenio = CriarConvenio(ativo: false);
            //Act

            //Assert
            convenio.Ativo.Should().BeFalse();
        }
        [TestMethod]
        public void Foto_QuandoObterFoto_DeveRetornarCaminhoFoto()
        {
            //Arrange
            var convenio = CriarConvenio();
            //Act

            //Assert
            convenio.Foto.Path.Should().NotBeNullOrWhiteSpace();
            convenio.Foto.Path.Should().Be("c:\teste\foto.jpg");            
        }
        [TestMethod]
        public void Foto_QuandoFotoVazio_DeveRetornarVazio()
        {
            //Arrange
            var convenio = CriarConvenio();
            convenio.Foto.Path = "";
            //Act

            //Assert
            convenio.Foto.Path.Should().BeNullOrWhiteSpace();            
        }
        [TestMethod]
        public void ToString_QuandoObterToString_DeveRetornarNome()
        {
            //Arrange
            var convenio = CriarConvenio();
            //Act

            //Assert
            convenio.ToString().Should().Be("Unimed Paulista");
        }
        [TestMethod]
        public void Validar_QuandoObjetoForValido_DeveRetornarTrue()
        {
            //Arrange
            var convenio = CriarConvenio();
            //Act

            //Assert
            convenio.Validar().Should().BeTrue();
        }       
        private Convenio CriarConvenio(string nome = "Unimed Paulista", string link="http://www.unimed.com.br", bool ativo=true)
        {
            var convenio = new Convenio(nome, ativo);            
            convenio.Link = link;
            convenio.Foto = new Foto(1, "c:\teste\foto.jpg");

            return convenio;
        }
    }
}
