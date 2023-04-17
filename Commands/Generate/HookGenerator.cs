using ReactCLI.Templates;

namespace ReactCLI.Commands.Generate
{
    internal class HookGenerator : Generator
    {
        protected override string? PathShouldInclude => "hooks";

        protected override List<ITemplate> GetTemplates(string[] args)
        {
            var templates = new List<ITemplate>
            {
                new HookTemplate(args)
            };

            if (!args.Contains("-nt"))
            {
                templates.Add(new HookTestTemplate(args[2]));
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

            var validOptions = new List<string> { "-nt", "-i" };
            var givenOptions = args.Skip(3);

            if (args.Length < 3 || string.IsNullOrWhiteSpace(args[2]))
            {
                errorMessage = "must provide <hookName>";
            }
            else if (!args[2].StartsWith("use"))
            {
                errorMessage = "<hookName> must start with \"use\"";
            }
            if (givenOptions.Any(x => !validOptions.Contains(x)))
            {
                var valid = string.Join(" ", validOptions);
                var given = string.Join(" ", givenOptions);
                errorMessage = $"unknown [options...], acceptable: {valid}, given: {given}";
            }

            return errorMessage.Length == 0;
        }
    }
}