namespace ReactCLI.Templates
{
    internal class ComponentScssTemplate : ITemplate
    {
        private readonly string _componentName;

        public string FileName => $"{_componentName}.scss";

        public ComponentScssTemplate(string componentName)
        {
            _componentName = componentName;
        }

        public string Build() => string.Empty;
    }
}