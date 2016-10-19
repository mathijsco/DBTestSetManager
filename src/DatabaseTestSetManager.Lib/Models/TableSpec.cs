using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTestSetManager.Lib.Models
{
    public class TableSpec
    {
        public Guid Guid { get; set; }

        public string Name { get; set; }

        public bool NoExport { get; set; }
    }
}
