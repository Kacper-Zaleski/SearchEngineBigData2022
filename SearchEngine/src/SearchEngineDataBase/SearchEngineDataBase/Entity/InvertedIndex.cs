using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngineDataBase.Entity
{
    public class InvertedIndex
    {
        public Guid Id { get; set; }
        public List<Index> Indexes { get; set; }
    }
}
