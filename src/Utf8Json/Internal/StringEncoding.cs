using System.Text;

namespace Spreads.Serialization.Utf8Json.Internal
{
    internal static class StringEncoding
    {
        public static readonly Encoding UTF8 = new UTF8Encoding(false);
    }
}