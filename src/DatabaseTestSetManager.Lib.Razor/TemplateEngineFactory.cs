using RazorEngine;
using RazorEngine.Configuration;
using RazorEngine.Templating;
using System;
using System.Collections.Generic;

namespace DatabaseTestSetManager.Lib.Razor
{
    public static class TemplateEngineFactory
    {
        private static readonly IDictionary<Guid, TemplateEngine> _engines = new Dictionary<Guid, TemplateEngine>();
        private static IRazorEngineService _razorService;
        private static TemplateServiceConfiguration _razorConfig;

        public static TemplateEngine ForColumn(Guid columnGuid)
        {
            Initialize();

            TemplateEngine existingEngine;
            if (!_engines.TryGetValue(columnGuid, out existingEngine))
                _engines.Add(columnGuid, existingEngine = new TemplateEngine(_razorService, columnGuid.ToString("n")));

            return existingEngine;
        }

        private static void Initialize()
        {
            if (_razorService != null)
                return;

            _razorConfig = new TemplateServiceConfiguration();
            //_razorConfig.Debug = true;
            _razorConfig.Language = Language.CSharp;
            _razorConfig.EncodedStringFactory = new InvariantRawStringFactory();
            _razorConfig.DisableTempFileLocking = true;
            //_razorConfig.CachingProvider = new DefaultCachingProvider(t => { });
            _razorService = RazorEngineService.Create(_razorConfig);


            //_razorService = IsolatedRazorEngineService.Create(new IsolatedRazorEngineService.DefaultConfigCreator());
        }

        public static void ClearCache()
        {
            if (_razorService != null)
                _razorService.Dispose();
        }
    }
}
