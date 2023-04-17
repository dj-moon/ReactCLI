using ReactCLI.Exceptions;

namespace ReactCLI.Commands.Generate
{
    internal class GeneratorFactory
    {
        public static Generator GetGenerator(string[] args)
        {
            if (args.Length < 2)
                throw new InvalidArgsException();

            switch (args[1])
            {
                case "c":
                case "component":
                    return new ComponentGenerator();
                case "h":
                case "hook":
                    return new HookGenerator();
                default:
                    throw new InvalidArgsException();
            }
        }
    }
}