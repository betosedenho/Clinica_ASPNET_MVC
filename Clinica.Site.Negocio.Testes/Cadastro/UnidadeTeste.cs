using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using CorpuClinica.Site.Negocio.Cadastro;

namespace CorpuClinica.Site.Negocio.Testes
{
    [TestClass]
    public class UnidadeTeste
    {
        [TestMethod]
        public void Nome_QuandoObterUnidade_RetornarNome()
        {
            //Arrange
            var unidade = CriarUnidade();
            //Act

            //Assert
            unidade.Nome.Should().Be("CorpPREV");
        }
        [TestMethod]
        public void Nome_QuandoNomeForNulo_RetornarExcecao()
        {
            //Arrange
            var unidade = CriarUnidade(nome:"");
            //Act

            //Assert
            unidade.Invoking(x=> x.Validar()).ShouldThrow<ArgumentNullException>();
        }
        [TestMethod]
        public void Foto_QuandoObterFoto_RetornarPathFoto()
        {
            //Arrange
            var unidade = CriarUnidade();
            //Act

            //Assert
            unidade.Foto.Path.Should().NotBeNullOrWhiteSpace();
            unidade.Foto.Path.Should().Be("c:/teste/corpprev.png");
        }
        [TestMethod]
        public void Foto_QuandoFotoForNulo_NaoRetornarPathFoto()
        {
            //Arrange
            var unidade = CriarUnidade();
            unidade.Foto.Path = "";
            //Act

            //Assert
            unidade.Foto.Path.Should().BeNullOrWhiteSpace();            
        }
        [TestMethod]
        public void Ativo_QuandoUnidadeAtiva_RetornarTrue()
        {
            //Arrange
            var unidade = CriarUnidade();
            //Act

            //Assert
            unidade.Ativo.Should().BeTrue();            
        }
        [TestMethod]
        public void Ativo_QuandoUnidadeInativa_RetornarFalse()
        {
            //Arrange
            var unidade = CriarUnidade(ativo: false);
            //Act

            //Assert
            unidade.Ativo.Should().BeFalse();
        }
        [TestMethod]
        public void Validar_QuandoObjetoValido_RetornarTrue()
        {
            //Arrange
            var unidade = CriarUnidade();
            //Act

            //Assert
            unidade.Validar().Should().BeTrue();
        }
        [TestMethod]
        public void ToString_QuandoChamarToString_RetornarNome()
        {
            //Arrange
            var unidade = CriarUnidade();
            //Act

            //Assert
            unidade.ToString().Should().Be("CorpPREV");
        }
        private Unidade CriarUnidade(string nome="CorpPREV", bool ativo=true)
        {
            var unidade = new Unidade(1, nome, new Foto(1, "c:/teste/corpprev.png"), ativo, new Endereco(1) { TipoEndereco = TipoEndereco.Casa, Rua = "Av. Vicente João Bernardi", Numero= "92", Complemento= "", Bairro = "Jardim Primavera", Cidade = "Matão", Estado = "SP", Cep = "15997-041", Pais = "Br" });

            return unidade;
        }
    }
}
