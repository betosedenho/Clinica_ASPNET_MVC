using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpuClinica.Site.Comum
{
    public class Paginacao
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public Gender StudentGender { get; set; }
    }

    public enum Gender
    {
        teste0,
        teste1

    }
}
