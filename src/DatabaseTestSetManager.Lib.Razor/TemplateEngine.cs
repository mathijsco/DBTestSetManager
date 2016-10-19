using Microsoft.CSharp.RuntimeBinder;
using RazorEngine.Templating;
using System;
using System.Diagnostics;

namespace DatabaseTestSetManager.Lib.Razor
{
    public class TemplateEngine
    {
        private readonly IRazorEngineService _razorService;
        private readonly string _templateKey;
        private bool _isCompiled;
        private int _compiledTemplateHashCode;

        internal TemplateEngine(IRazorEngineService razorEngineService, string templateKey)
        {
            if (razorEngineService == null) throw new ArgumentNullException("razorEngineService");
            if (templateKey == null) throw new ArgumentNullException("templateKey");

            _razorService = razorEngineService;
            _templateKey = templateKey;
        }

        private string CurrentTemplateKey
        {
            get
            {
                return _templateKey + "_" + (uint)_compiledTemplateHashCode;
            }
        }

        public bool TryCompile(string template)
        {
            var templateHashCode = template.GetHashCode();

            if (_isCompiled)
            {
                // Template is already compiled
                if (templateHashCode == _compiledTemplateHashCode)
                    return true;
            }

            _isCompiled = false;
            try
            {
                _compiledTemplateHashCode = templateHashCode;
                _razorService.Compile(new LoadedTemplateSource(template), this.CurrentTemplateKey);

                _isCompiled = true;
                return true;
            }
            catch (TemplateCompilationException ex)
            {
                Trace.TraceError("Cannot compile the template. {0}", ex.Message);
                return false;
            }
        }

        //var result = engine.Execute("Hallo @Model.Naam van Gool", new { Naam = "Mathijs" });
        public bool TryExecute(object model, out string result)
        {
            if (!_isCompiled)
                throw new InvalidOperationException("The template is not compiled yet. Please compile before execution.");

            try
            {
                result = _razorService.Run(this.CurrentTemplateKey, model: model);
                return true;
            }
            catch (RuntimeBinderException ex)
            {
                Trace.TraceError("Cannot execute the template. {0}", ex.Message);
                result = null;
                return false;
            }
        }
    }
}
