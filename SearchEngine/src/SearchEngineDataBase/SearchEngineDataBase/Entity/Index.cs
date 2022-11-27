using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngineDataBase.Entity
{
    public class Index
    {
        public Guid Id { get; set; }
        public List<string> Authors { get; set; }
        public string Title { get;set; }
        public string Language { get; set; }
        public string Invocation { get; set; }
        public DateTime RealeseDate { get; set; }
        public string Href { get; set; }
        public string PageIndex { get; set; }
    }
}
