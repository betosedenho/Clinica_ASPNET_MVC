using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using CorpuClinica.Site.Negocio.Cadastro;

namespace CorpuClinica.Site.Negocio.Testes
{
    [TestClass]
    public class MedicoTeste
    {
        [TestMethod]
        public void NomeCompleto_QuandoObterNomeCompleto_DeveRetornarNomeSobrenome()
        {
            //Arrange
            var medico = CriarMedico();
            //Act

            //Arrange
            medico.NomeCompleto.Should().Be("Adriano Fleury de Farias Soares");
        }
        [TestMethod]
        public void NomeCompleto_QuandoNomeVazio_DeveRetornarSobrenome()
        {
            //Arrange
            var medico = CriarMedico(nome: "");
            //Act

            //Arrange
            medico.NomeCompleto.Should().Be("Soares");
        }
        [TestMethod]
        public void NomeCompleto_QuandoSobrenomeVazio_DeveRetornarNome()
        {
            //Arrange
            var medico = CriarMedico(sobrenome: "");
            //Act

            //Arrange
            medico.NomeCompleto.Should().Be("Adriano Fleury de Farias");
        }
        [TestMethod]
        public void Foto_QuandoObterFoto_DeveRetornarPathFoto()
        {
            //Arrange
            var medico = CriarMedico();
            //Act

            //Arrange
            medico.Foto.Path.Should().NotBeNullOrWhiteSpace();
            medico.Foto.Path.Should().Be("c:/teste/AdrianoSoares.jpg");
        }
        [TestMethod]
        public void Foto_QuandoNãoInformarFoto_NaoDeveRetornarPathFoto()
        {
            //Arrange
            var medico = CriarMedico();
            medico.Foto.Path = "";
            //Act

            //Arrange
            medico.Foto.Path.Should().BeNullOrWhiteSpace();            
        }
        [TestMethod]
        public void Ativo_QuandoMedicoAtivo_DeveRetornarTrue()
        {
            //Arrange
            var medico = CriarMedico();
            //Act

            //Arrange
            medico.Ativo.Should().BeTrue();            
        }
        [TestMethod]
        public void Ativo_QuandoMedicoInativo_DeveRetornarFalse()
        {
            //Arrange
            var medico = CriarMedico(ativo: false);
            //Act

            //Arrange
            medico.Ativo.Should().BeFalse();
        }
        [TestMethod]
        public void Validar_QuandoForValido_DeveRetornarTrue()
        {
            //Arrange
            var medico = CriarMedico();
            //Act

            //Arrange
            medico.Validar().Should().BeTrue();
        }
        private Medico CriarMedico(string nome= "Adriano Fleury de Farias", string sobrenome= "Soares", bool ativo = true)
        {
            var medico = new Medico(1, nome, sobrenome, new Foto(1, "c:/teste/AdrianoSoares.jpg"), ativo);

            return medico;
        }
    }
}
