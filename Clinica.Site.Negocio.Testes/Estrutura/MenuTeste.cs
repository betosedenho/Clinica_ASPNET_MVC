using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CorpuClinica.Site.Negocio.Estrutura;
using FluentAssertions;

namespace CorpuClinica.Site.Negocio.Testes.Estrutura
{
    [TestClass]
    public class MenuTeste
    {        
        [TestMethod]
        public void Validar_QuandoObjetoForValido_DeveRetornarTrue()
        {
            //Arrange
            var menu = CriarMenu();
            //Act

            //Assert
            menu.Validar().Should().BeTrue();
        }
        [TestMethod]
        public void Titulo_QuandoTituloForVazio_DeveRetornarExcecao()
        {
            //Arrange
            var menu = CriarMenu(titulo: "");
            //Act

            //Assert
            menu.Invoking(x => x.Validar()).ShouldThrow<ArgumentNullException>();
        }
        [TestMethod]
        public void Dta_Criacao_QuandoDta_CriacaoNaoInformado_DeveRetornarExcecao()
        {
            //Arrange
            var menu = CriarMenu();
            menu.Dta_Criacao = DateTime.MinValue;
            //Act

            //Assert
            menu.Invoking(x => x.Validar()).ShouldThrow<ArgumentNullException>();
        }
        [TestMethod]
        public void Ordem_QuandoOrdemForZero_DeveRetornarExcecao()
        {
            //Arrange
            var menu = CriarMenu(ordem: 0);            
            //Act

            //Assert
            menu.Invoking(x => x.Validar()).ShouldThrow<ArgumentNullException>();
        }
        [TestMethod]
        public void Dta_Desativacao_QuandoInformarDta_Desativacao_DeveRetornarAtivoFalso()
        {
            //Arrange
            var menu = CriarMenu();
            menu.Dta_Desativacao = DateTime.Now;
            //Act

            //Assert
            menu.Ativo.Should().BeFalse();
        }
        [TestMethod]
        public void Dta_Desativacao_QuandoNaoInformarDta_Desativacao_DeveRetornarAtivoTrue()
        {
            //Arrange
            var menu = CriarMenu();
            menu.Dta_Desativacao = null;
            //Act

            //Assert
            menu.Ativo.Should().BeTrue();
        }
        private Menu CriarMenu(string titulo = "Atendimento", int ordem = 1, string cadastro="")
        {
            var menu = new Menu(titulo, ordem, cadastro);            

            return menu;
        }
    }
}
