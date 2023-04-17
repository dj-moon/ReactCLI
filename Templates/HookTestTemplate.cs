using System.Text;

namespace ReactCLI.Templates
{
    internal class HookTestTemplate : ITemplate
    {
        private readonly string _hookName;

        public string FileName => $"{_hookName}.test.ts";

        public HookTestTemplate(string hookName)
        {
            _hookName = hookName;
        }

        public string Build()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"import {{ renderHook }} from '@testing-library/react';");
            sb.AppendLine($"import {_hookName} from './{_hookName}';");
            sb.AppendLine();
            sb.AppendLine($"describe('{_hookName}', () => {{");
            sb.AppendLine($"    it('works', () => {{");
            sb.AppendLine($"        renderHook(() => {_hookName}());");
            sb.AppendLine($"    }});");
            sb.AppendLine("});");

            return sb.ToString();
        }
    }
}
