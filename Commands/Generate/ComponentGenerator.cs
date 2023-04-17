using ReactCLI.Templates;

namespace ReactCLI.Commands.Generate
{
    internal class ComponentGenerator : Generator
    {
        protected override string? PathShouldInclude => "components";

        protected override List<ITemplate> GetTemplates(string[] args)
        {
            var templates = new List<ITemplate>
            {
                new ComponentTemplate(args)
            };

            if (!args.Contains("-nt"))
            {
                templates.Add(new ComponentTestTemplate(args[2]));
            }

            if (args.Contains("-s"))
            {
                templates.Add(new ComponentScssTemplate(args[2]));
            }

            if (args.Contains("-i"))
            {
                templates.Add(new IndexTemplate(args[2]));
            }

            return templates;
        }

        protected override bool IsArgsValid(string[] args, out string errorMessage)
        {
            errorMessage = string.Empty;

            var validOptions = new List<string> { "-p", "-nt", "-s", "-i" };
            var givenOptions = args.Skip(3);

            if (string.IsNullOrWhiteSpace(args[2]))
            {
                errorMessage = "<componentName> is empty";
            }
            else if (!char.IsAsciiLetter(args[2][0]))
            {
                errorMessage = "<componentName> must start with [a-zA-Z]";
            }
            else if (givenOptions.Any(x => !validOptions.Contains(x)))
            {
                var valid = string.Join(" ", validOptions);
                var given = string.Join(" ", givenOptions);
                errorMessage = $"unknown [options...], acceptable: {valid}, given: {given}";
            }

            return errorMessage.Length == 0;
        }
    }
}