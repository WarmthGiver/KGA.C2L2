namespace ZL.Unity
{
    public sealed class WarningBoxAttribute : HelpBoxAttribute
    {
        public WarningBoxAttribute(string message) : base(MessageType.Warning, message) { }

        public WarningBoxAttribute(IconSize iconSize, string message) : base(MessageType.Warning, iconSize, message) { }
    }
}