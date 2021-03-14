namespace CBP.Extensions
{
    public static class BooleanExtensions
    {
        const string YES = "Yes";
        const string NO = "No";

        public static string ToYesNoString(this bool value)
        {
            return value ? YES : NO;
        }
    }
}
