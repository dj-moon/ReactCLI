namespace ReactCLI.Exceptions
{
    internal class DirectoryExistsException : Exception
    {
        public DirectoryExistsException(string directory) : base($"{directory} already exists") { }
    }
}