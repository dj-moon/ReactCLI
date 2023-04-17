using ReactCLI.Commands;
using ReactCLI.Commands.Generate;
using ReactCLI.Exceptions;
using ReactCLI.Extensions;

namespace ReactCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args == null || args.Length == 0)
                    throw new InvalidArgsException();

                switch (args[0])
                {
                    case "g":
                    case "generate":
                        GeneratorFactory.GetGenerator(args).Run(args);
                        break;
                    case "-?":
                    case "-h":
                    case "-help":
                        ShowHelp();
                        break;
                    default:
                        throw new InvalidArgsException();
                }
            }
            catch (DirectoryNameException dirNameEx)
            {
                dirNameEx.Message.LogRed();
                "aborted - no action was performed".LogBlue(); ;
            }
            catch (DirectoryExistsException dirExistsEx)
            {
                dirExistsEx.Message.LogRed();
                "aborted - no action was performed".LogBlue(); ;
            }
            catch (InvalidArgsException argsEx)
            {
                argsEx.Message.LogRed();
                "try -h for help".LogBlue();
            }
            catch (Exception ex)
            {
                ex.Message.LogRed();
            }
        }

        private static void ShowHelp()
        {
            "usage:".LogYellow();
            "  re (g|generate) (c|component) <componentName> [options...]".Log();
            "".Log();
            "arguments:".LogYellow();
            "  (g|generate)      generate something".Log();
            "  (component|c)     generate component".Log();
            "  <componentName>   name of component".Log();
            "".Log();
            "options:".LogYellow();
            "  -s     styles - creates component scss file".Log();
            "  -p     properties - creates interface for component properties".Log();
            "  -nt    no tests - skips component test file creation".Log();
            "  -nt    index file - creates index file with default export".Log();
        }
    }
}