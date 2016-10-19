using System.Collections.Generic;

namespace DatabaseTestSetManager.Lib.Models
{
    public class ContentRow : List<object>
    {
        public ContentRow()
        {

        }

        public ContentRow(int expectedColumns)
            : base(expectedColumns)
        {

        }
    }
}
