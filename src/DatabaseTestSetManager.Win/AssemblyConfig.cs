using DatabaseTestSetManager.Win.IO;
using System.Collections.Generic;
using System.Drawing;

namespace DatabaseTestSetManager.Win
{
    internal class AssemblyConfig : AssemblyConfigRepository<AssemblyConfig>
    {
        public IDictionary<string, Rectangle> WindowMetrics { get; set; } = new Dictionary<string, Rectangle>();
    }
}
