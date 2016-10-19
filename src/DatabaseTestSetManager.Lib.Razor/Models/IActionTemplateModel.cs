using System;

namespace DatabaseTestSetManager.Lib.Razor.Models
{
    public interface IActionTemplateModel
    {
        string RenderFromNow(DateTimeOffset dateTime);

        string RenderFromNow(TimeSpan timeSpan);
    }
}
