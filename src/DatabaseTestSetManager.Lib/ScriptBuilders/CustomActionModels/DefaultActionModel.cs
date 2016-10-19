using DatabaseTestSetManager.Lib.Razor.Models;
using System;

namespace DatabaseTestSetManager.Lib.ScriptBuilders.CustomActionModels
{
    public class DefaultActionModel : IActionTemplateModel
    {
        public string RenderFromNow(TimeSpan timeSpan)
        {
            return (DateTimeOffset.UtcNow + timeSpan).ToString("o");
        }

        public string RenderFromNow(DateTimeOffset dateTime)
        {
            var now = DateTimeOffset.Now.ToOffset(dateTime.Offset);
            var diff = dateTime - now;
            return (now + diff).ToString("o");
        }
    }
}
