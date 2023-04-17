namespace ReactCLI.Templates
{
    internal class IndexTemplate : ITemplate
    {
        private readonly string _name;

        public string FileName => "index.ts";

        public IndexTemplate(string name)
        {
            _name = name;
        }

        public string Build() => $"export {{ default }} from './{_name}';{Environment.NewLine}";
    }
}