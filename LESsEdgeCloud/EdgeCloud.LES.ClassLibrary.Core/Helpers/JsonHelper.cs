using System.Text.Json;

namespace EdgeCloud.LES.ClassLibrary.Core.Helpers
{
    public static class JsonHelper<T> where T : class
    {
        public static bool Parsable(string data)
        {
            try { JsonSerializer.Deserialize<T>(data); return true; } catch { return false; }
        }
        public static T ParseString(string data)
        {
            try { return JsonSerializer.Deserialize<T>(data); } catch { return null; }
        }
        public static string ToJSONString(T data)
        {
            try { return JsonSerializer.Serialize(data); } catch { return null; }
        }
    }
}
