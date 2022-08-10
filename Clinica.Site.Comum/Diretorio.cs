using System.IO;

namespace Clinica.Site.Comum
{
    public static class Diretorio
    {
        public static void Criar(string caminho)
        {
            if (!Directory.Exists(caminho))
            {
                Directory.CreateDirectory(caminho);
            }
        }
    }
}
