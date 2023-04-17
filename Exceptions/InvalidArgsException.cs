namespace ReactCLI.Exceptions
{
    internal class InvalidArgsException : Exception
    {
        public InvalidArgsException(string message = "arguments are invalid") : base(message) { }
    }
}