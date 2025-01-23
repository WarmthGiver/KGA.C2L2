namespace ZL.Unity
{
    public sealed class ErrorBoxAttribute : HelpBoxAttribute
    {
        public ErrorBoxAttribute(string message) : base(MessageType.Error, message) { }

        public ErrorBoxAttribute(IconSize iconSize, string message) : base(MessageType.Error, iconSize, message) { }
    }
}