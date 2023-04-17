namespace ReactCLI.Exceptions
{
    internal class DirectoryNameException : Exception
    {
        public DirectoryNameException(string directoryPath, string shouldInclude) : base($"Current path does not include \"{shouldInclude}\". Given: {directoryPath}") { }
    }
}