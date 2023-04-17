namespace ReactCLI.Templates
{
    internal interface ITemplate
    {
        string FileName { get; }

        string Build();
    }
}