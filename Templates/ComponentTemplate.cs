using System.Text;

namespace ReactCLI.Templates
{
    internal class ComponentTemplate : ITemplate
    {
        private readonly string _componentName;
        private readonly string[] _args;

        public string FileName => $"{_componentName}.tsx";

        public ComponentTemplate(string[] args)
        {
            _componentName = args[2];
            _args = args;
        }

        public string Build()
        {
            var sb = new StringBuilder();

            sb.AppendLine("import React from 'react';");
            if (_args.Contains("-s"))
            {
                sb.AppendLine($"import './{_componentName}.scss;'");
            }
            sb.AppendLine();
            if (_args.Contains("-p"))
            {
                sb.AppendLine($"interface {_componentName}Props {{");
                sb.AppendLine("    ");
                sb.AppendLine("}");
                sb.AppendLine();
                sb.AppendLine($"const {_componentName} = ({{}}: {_componentName}Props) => {{");
            }
            else
            {
                sb.AppendLine($"const {_componentName} = () => {{");
            }
            sb.AppendLine($"    return <div data-testid=\"{_componentName}\"></div>");
            sb.AppendLine("};");
            sb.AppendLine();
            sb.AppendLine($"export default {_componentName};");

            return sb.ToString();
        }
    }
}