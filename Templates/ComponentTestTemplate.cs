using System.Text;

namespace ReactCLI.Templates
{
    internal class ComponentTestTemplate : ITemplate
    {
        private readonly string _componentName;

        public string FileName => $"{_componentName}.test.tsx";

        public ComponentTestTemplate(string componentName)
        {
            _componentName = componentName;
        }

        public string Build()
        {
            var sb = new StringBuilder();

            sb.AppendLine("import React from 'react';");
            sb.AppendLine("import { screen, render } from '@testing-library/react';");
            sb.AppendLine($"import {_componentName} from './{_componentName}';");
            sb.AppendLine();
            sb.AppendLine($"describe('{_componentName}', () => {{");
            sb.AppendLine("    it('renders', () => {");
            sb.AppendLine($"        render(<{_componentName} />);");
            sb.AppendLine($"        expect(screen.getByTestId('{_componentName}')).toBeInTheDocument();");
            sb.AppendLine("    });");
            sb.AppendLine("});");

            return sb.ToString();
        }
    }
}