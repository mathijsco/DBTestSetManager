using DatabaseTestSetManager.Lib.Properties;
using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseTestSetManager.Lib.DataHandlers.DefaultDataProviders
{
    public class CSharpDataProvider : IDefaultDataProvider
    {
        private bool _isStatement;
        private string _codeBlock;
        private IDefaultDataProvider _instance;

        public string CodeBlock
        {
            get { return _codeBlock; }
            set
            {
                if (_codeBlock == value)
                    return;

                _codeBlock = value;
                _instance = null;
            }
        }

        public bool IsStatement
        {
            get { return _isStatement; }
            set
            {
                if (_isStatement == value)
                    return;

                _isStatement = value;
                _instance = null;
            }
        }

        public string Generate()
        {
            return GenerateAsync().Result;
        }

        public async Task<string> GenerateAsync()
        {
            if (_instance == null)
            {
                try
                {
                    await GenerateNewAssembly();
                }
                catch (AggregateException ex)
                {
                    Trace.TraceError(ex.InnerException.Message);
                    return "SYNTAX ERROR";
                }
            }

            try
            {
                return await Task.Factory.StartNew(() => _instance.Generate());
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message);
                return "RUNTIME ERROR";
            }
        }

        private async Task GenerateNewAssembly()
        {
            await Task.Factory.StartNew(() =>
            {
                var csc = new CSharpCodeProvider(new Dictionary<string, string>() { { "CompilerVersion", "v4.0" } });
                var parameters = new CompilerParameters(new[] { "mscorlib.dll", "System.Core.dll", this.GetType().Assembly.Location })
                {
                    GenerateInMemory = true,
                    TreatWarningsAsErrors = false,
                    GenerateExecutable = false,
                    CompilerOptions = "/optimize"
                };

                var rawCode = Resources.CSharpCodePlaceholder;
                var newCode = this.CodeBlock;
                if (this.IsStatement)
                    newCode = "return Convert.ToString((" + newCode + "), CultureInfo.InvariantCulture);";

                CompilerResults results = csc.CompileAssemblyFromSource(parameters, rawCode.Replace("{{CODE}}", newCode));
                if (results.Errors.HasErrors)
                {
                    var exceptionList = new List<Exception>();
                    foreach (CompilerError error in results.Errors)
                        exceptionList.Add(new InvalidProgramException(error.ErrorText));
                    throw new AggregateException(exceptionList);
                }

                var assembly = results.CompiledAssembly;
                var type = assembly.GetTypes().First();
                _instance = (IDefaultDataProvider)Activator.CreateInstance(type);
            });
        }
    }
}
