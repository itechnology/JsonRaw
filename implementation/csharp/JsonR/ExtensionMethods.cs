using System.Web.Script.Serialization;

public static class ExtensionMethods
{
    public static JavaScriptSerializer JavaScriptSerializer = new JavaScriptSerializer();

    public static string ToJson(this object item)
    {
        return JavaScriptSerializer.Serialize(item);
    }
}

