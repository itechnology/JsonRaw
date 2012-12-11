using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

public class Response
{
    /// <summary>
    /// Reusable Serializer instance
    /// </summary>
    public static readonly JavaScriptSerializer JavaScriptSerializer = new JavaScriptSerializer();


    /// <summary>
    /// Returns a list of users in a old style JsonR format, that does not support recursion.
    /// </summary>
    /// <returns>{"Values":[["Robert",41],["Teddy",35]],"Keys":["Pseudo","Age"]}</returns>
    public static string GetUsers()
    {
        // Mockup userList
        var users = new List<User> {
            new User() { Pseudo = "Robert", Age = 41},
            new User() { Pseudo = "Teddy" , Age = 35}
        };



        // Initialize keys
		var response = new AjaxArray(new [] { "Pseudo", "Age" });

        // Add values
        foreach (var u in users) {
            response.Add(new ArrayList() { u.Pseudo, u.Age });
        }
        
        // Return JSON
        return JavaScriptSerializer.Serialize(response);
    }
}

/// <summary>
/// Mockup class
/// </summary>
public class User {
    public string Pseudo { get; set; }
    public int    Age    { get; set; }
}

/// <summary>
/// Collection Wrapper
/// </summary>
public class AjaxArray
{
    public AjaxArray(string[] keys)
    {
        Keys   = keys;
        Values = new List<ArrayList>();
    }

    public void Add(ArrayList item)
    {
        Values.Add(item);
    }

    public List<ArrayList> Values { get; set; }

    public string[] Keys { get; set; }
}