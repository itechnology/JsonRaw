using System.Web.Script.Serialization;

public static class ExtensionMethods
{
    public static readonly JavaScriptSerializer JavaScriptSerializer = new JavaScriptSerializer();

    public static string ToJson(this object item)
    {
        return JavaScriptSerializer.Serialize(item);
    }

    public static T FromJson<T>(this string item)
    {
        return JavaScriptSerializer.Deserialize<T>(item);
    }
}