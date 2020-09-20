using System;
using System.Text;

namespace DNCD.Common.Base.Extensions
{
    public static class ExceptionExtensions
    {
        public static string GetAllMessages(this Exception ex)
        {
            if (ex == null)
                throw new ArgumentNullException("ex");

            StringBuilder sb = new StringBuilder();

            while (ex != null)
            {
                if (!string.IsNullOrEmpty(ex.Message))
                {
                    if (sb.Length > 0)
                        sb.Append(" ");

                    sb.Append(ex.Message);
                }

                ex = ex.InnerException;
            }

            return sb.ToString();
        }

        /// <summary>
        /// Remove double quotes at begingin and ending of string.
        /// Example: "<xml>input</xml>" to <xml>input</xml>
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static string RemoveDoubleQuotes(this string data)
        {
            data = data.StartsWith("\"") ? data.Remove(0, 1) : data;
            data = data.EndsWith("\"") ? data.Remove(data.Length - 1, 1) : data;

            return data;
        }
    }
}
