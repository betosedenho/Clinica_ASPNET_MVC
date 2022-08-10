using System.Collections.Generic;

namespace Clinica.Site.Comum
{
    public class ServicoLog
    {
        public static void EscreverArquivo(List<ILog> itensModificados)
        {
            foreach (var item in itensModificados)
            {
                //implementar a lógica do log
            }
        }
    }
}
