using ReactCLI.Exceptions;
using ReactCLI.Extensions;
using ReactCLI.Templates;

namespace ReactCLI.Commands.Generate
{
    internal abstract class Generator
    {
        protected abstract string? PathShouldInclude { get; }

        public void Run(string[] args)
        {
            if (!IsArgsValid(args, out var errorMessage))
                throw new InvalidArgsException(errorMessage);

            var dir = CreateDirectory(args[2]);

            foreach (var template in GetTemplates(args))
            {
                CreateFile(dir, template.FileName, template.Build());
            }
        }

        protected abstract bool IsArgsValid(string[] args, out string errorMessage);

        protected abstract List<ITemplate> GetTemplates(string[] args);

        protected virtual string CreateDirectory(string directoryName)
        {
            var dir = $"{Environment.CurrentDirectory}/bin/{directoryName}"; // TODO: remove /bin

            if (Directory.Exists(dir))
                throw new DirectoryExistsException($"./{directoryName}");

            if (PathShouldInclude != null &&
                !dir.Contains(PathShouldInclude, StringComparison.OrdinalIgnoreCase))
            {
                $"Current path does not include \"{PathShouldInclude}\". Continue? [y|n] ".LogYellow(false);

                if (!string.Equals("y", Console.ReadLine()?.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    throw new DirectoryNameException(dir, PathShouldInclude);
                }
            }

            return Directory.CreateDirectory(dir).FullName;
        }

        protected virtual void CreateFile(string directory, string fileName, string fileText)
        {
            var path = Path.Combine(directory, fileName);
            File.WriteAllText(path, fileText);
            $"Created ./{fileName}".LogGreen();
        }
    }
}