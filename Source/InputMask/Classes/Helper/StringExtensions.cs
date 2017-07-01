using System;
namespace InputMask.Classes.Helper
{
    public static class StringExtensions
    {
        public static string TruncateFirst(this string content){
            return content.Substring(1);
        }
    }
}
