using System.Text;

namespace ReactCLI.Templates
{
    internal class HookTemplate : ITemplate
    {
        private readonly string _hookName;

        public string FileName => $"{_hookName}.ts";

        public HookTemplate(string[] args)
        {
            _hookName = args[2];
        }

        public string Build()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"const {_hookName} = () => {{");
            sb.AppendLine();
            sb.AppendLine("};");
            sb.AppendLine();
            sb.AppendLine($"export default {_hookName};");

            return sb.ToString();
        }
    }
}