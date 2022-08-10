using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CorpuClinica.Site.Negocio.Estrutura;
using FluentAssertions;

namespace CorpuClinica.Site.Negocio.Testes.Estrutura
{
    [TestClass]
    public class MetaTeste
    {
        [TestMethod]
        public void Validar_QuandoObjetoForValido_DeveRetornarTrue()
        {
            //Arrange
            var meta = CriarMeta();
            //Act

            //Assert
            meta.Validar().Should().BeTrue();
        }
        [TestMethod]
        public void Name_QuandoNameNulo_DeveRetornarExcecao()
        {
            //Arrange
            var meta = CriarMeta(name: "");
            //Act

            //Assert 
            meta.Invoking(x => x.Validar()).ShouldThrow<ArgumentNullException>();
        }
        [TestMethod]
        public void Content_QuandoContentNulo_DeveRetornarExcecao()
        {
            //Arrange
            var meta = CriarMeta(content: "");
            //Act

            //Assert 
            meta.Invoking(x => x.Validar()).ShouldThrow<ArgumentNullException>();
        }
        public void ToString_QuandoObterToString_DeveRetornarNameEContent()
        {
            //Arrange
            var meta = CriarMeta();
            //Act
            const string quote = "\"";
            string teste = "name=" + quote + "description" + quote + " content=" + quote + "CÓRPU CLÍNICA DE DOENÇAS CARDIO PULMONARES" + quote;

            //Assert
            meta.ToString().Should().Be(teste);
        }
        public void ToString_QuandoObterToStringEPropriedadeVazio_DeveRetornarExcecao()
        {
            //Arrange
            var meta = CriarMeta(name:"", content: "");

            //Act            

            //Assert
            meta.Invoking(x => x.ToString()).ShouldThrow<ArgumentNullException>();
        }
        public void ToString_QuandoObterToStringENameVazio_DeveRetornarExcecao()
        {
            //Arrange
            var meta = CriarMeta(name: "");

            //Act            

            //Assert
            meta.Invoking(x => x.ToString()).ShouldThrow<ArgumentNullException>();
        }
        public void ToString_QuandoObterToStringEContentVazio_DeveRetornarExcecao()
        {
            //Arrange
            var meta = CriarMeta(content: "");

            //Act            

            //Assert
            meta.Invoking(x => x.ToString()).ShouldThrow<ArgumentNullException>();
        }
        [TestMethod]
        public void Name_QuandoObterName_DeveRetornarName()
        {
            //Arrange
            var meta = CriarMeta();
            //Act

            //Assert
            meta.Name.Should().NotBeNullOrWhiteSpace();
            meta.Name.Should().Be("description");
        }
        [TestMethod]
        public void Content_QuandoObterContent_DeveRetornarContent()
        {
            //Arrange
            var meta = CriarMeta();
            //Act

            //Assert
            meta.Content.Should().NotBeNullOrWhiteSpace();
            meta.Content.Should().Be("CÓRPU CLÍNICA DE DOENÇAS CARDIO PULMONARES");
        }
        private Meta CriarMeta(string name = "description", string content = "CÓRPU CLÍNICA DE DOENÇAS CARDIO PULMONARES")
        {
            var meta = new Meta(name, content);            

            return meta;
        }
    }
}
