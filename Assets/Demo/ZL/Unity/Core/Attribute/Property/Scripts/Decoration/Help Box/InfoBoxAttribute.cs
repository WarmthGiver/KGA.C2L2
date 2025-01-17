namespace ZL.Unity
{
    public sealed class InfoBoxAttribute : HelpBoxAttribute
    {
        public InfoBoxAttribute(string message) : base(MessageType.Info, message) { }

        public InfoBoxAttribute(IconSize iconSize, string message) : base(MessageType.Info, iconSize, message) { }
    }
}