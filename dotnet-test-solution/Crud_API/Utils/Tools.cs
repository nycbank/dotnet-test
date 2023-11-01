using Newtonsoft.Json;

namespace dotnet_test_solution.Utils;

public static class Tools
{
    public static string GetJSONfromObject(object obj)
    {
        string output = JsonConvert.SerializeObject(obj, Formatting.Indented, new JsonSerializerSettings
        {
            PreserveReferencesHandling = PreserveReferencesHandling.Objects
        });
        return output;
    }
}