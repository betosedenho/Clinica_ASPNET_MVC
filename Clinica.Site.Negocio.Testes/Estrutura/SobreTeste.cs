using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CorpuClinica.Site.Negocio.Estrutura;
using FluentAssertions;
using CorpuClinica.Site.Negocio.Cadastro;

namespace CorpuClinica.Site.Negocio.Testes.Estrutura
{
    [TestClass]
    public class SobreTeste
    {
        [TestMethod]
        public void Validar_QuandoObjetoForValido_DeveRetornarTrue()
        {
            //Arrange
            var sobre = CriarSobre();
            //Act

            //Assert
            sobre.Validar().Should().BeTrue();
        }
        [TestMethod]
        public void Logo_QuandoLogoVazio_DeveRetornarVazio()
        {
            //Arrange
            var sobre = CriarSobre();
            sobre.Logo.Path = "";
            //Act

            //Assert
            sobre.Logo.Path.Should().BeNullOrWhiteSpace();
        }
        [TestMethod]
        public void Missao_QuandoMissaoVazio_DeveRetornarVazio()
        {
            //Arrange
            var sobre = CriarSobre();
            sobre.Missao = "";
            //Act

            //Assert
            sobre.Missao.Should().BeNullOrWhiteSpace();
        }
        [TestMethod]
        public void Visao_QuandoVisaoVazio_DeveRetornarVazio()
        {
            //Arrange
            var sobre = CriarSobre();
            sobre.Visao = "";
            //Act

            //Assert
            sobre.Visao.Should().BeNullOrWhiteSpace();
        }
        [TestMethod]
        public void Valores_QuandoValoresVazio_DeveRetornarVazio()
        {
            //Arrange
            var sobre = CriarSobre();
            sobre.Valores = "";
            //Act

            //Assert
            sobre.Valores.Should().BeNullOrWhiteSpace();
        }
        [TestMethod]
        public void Titulo_QuandoTituloNulo_DeveRetornarExcecao()
        {
            //Arrange
            var sobre = CriarSobre(titulo: "");            
            //Act

            //Assert 
            sobre.Invoking(x => x.Validar()).ShouldThrow<ArgumentNullException>();
        }
        [TestMethod]
        public void Cabecalho_QuandoCabecalhoNulo_DeveRetornarExcecao()
        {
            //Arrange
            var sobre = CriarSobre(cabecalho: "");            
            //Act

            //Assert 
            sobre.Invoking(x => x.Validar()).ShouldThrow<ArgumentNullException>();
        }
        [TestMethod]
        public void Rodape_QuandoRodapeNulo_DeveRetornarExcecao()
        {
            //Arrange
            var sobre = CriarSobre(rodape: "");            
            //Act

            //Assert 
            sobre.Invoking(x => x.Validar()).ShouldThrow<ArgumentNullException>();
        }
        [TestMethod]
        public void Titulo_QuandoObterTitulo_DeveRetornarTitulo()
        {
            //Arrange
            var sobre = CriarSobre();
            //Act

            //Assert
            sobre.Titulo.Should().NotBeNullOrWhiteSpace();
            sobre.Titulo.Should().Be("Córpu Clínica");
        }
        [TestMethod]
        public void Cabecalho_QuandoObterCabecalho_DeveRetornarCabecalho()
        {
            //Arrange
            var sobre = CriarSobre();
            //Act

            //Assert
            sobre.Cabecalho.Should().NotBeNullOrWhiteSpace();
            sobre.Cabecalho.Should().Be("Córpu Clínica de Doenças Cardio Pulmonares");
        }
        [TestMethod]
        public void Rodape_QuandoObterRodape_DeveRetornarRodape()
        {
            //Arrange
            var sobre = CriarSobre();
            //Act

            //Assert
            sobre.Rodape.Should().NotBeNullOrWhiteSpace();
            sobre.Rodape.Should().Be("Copyright© Córpu Clínica de Doenças Cardio Pulmonares - 1981 a 2017 - Todos os direitos reservados");
        }
        [TestMethod]
        public void Missao_QuandoObterMissao_DeveRetornarMissao()
        {
            //Arrange
            var sobre = CriarSobre(missao: "Teste da Missão");            
            //Act

            //Assert
            sobre.Missao.Should().NotBeNullOrWhiteSpace();
            sobre.Missao.Should().Be("Teste da Missão");
        }
        [TestMethod]
        public void Visao_QuandoObterVisao_DeveRetornarVisao()
        {
            //Arrange
            var sobre = CriarSobre(visao: "Teste da Visão");            
            //Act

            //Assert
            sobre.Visao.Should().NotBeNullOrWhiteSpace();
            sobre.Visao.Should().Be("Teste da Visão");
        }
        [TestMethod]
        public void Valores_QuandoObterValores_DeveRetornarValores()
        {
            //Arrange
            var sobre = CriarSobre(valores: "Teste da Valores");            
            //Act

            //Assert
            sobre.Valores.Should().NotBeNullOrWhiteSpace();
            sobre.Valores.Should().Be("Teste da Valores");
        }
        [TestMethod]
        public void ToString_QuandoObterToString_DeveRetornarTitulo()
        {
            //Arrange
            var sobre = CriarSobre();
            //Act

            //Assert
            sobre.ToString().Should().Be("Córpu Clínica");
        }
        private Sobre CriarSobre(string titulo="Córpu Clínica", string cabecalho= "Córpu Clínica de Doenças Cardio Pulmonares", string rodape= "Copyright© Córpu Clínica de Doenças Cardio Pulmonares - 1981 a 2017 - Todos os direitos reservados", string missao="", string visao="", string valores="")
        {
            var sobre = new Sobre(titulo, cabecalho, rodape, missao, visao, valores);
            sobre.Logo = new Foto(1, "c:/teste/logo.jpg");

            return sobre;
        }
    }
}
