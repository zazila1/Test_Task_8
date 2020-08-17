using System;
using System.Globalization;
using UnityEngine;

[Serializable]
public class SphereModelForJson
{
    public string id;
    public WordPositionForJson wordPosition;
    public string scale;
    
    
    
    public static string FloatToString(float f)
    {
        return $"{f.ToString(CultureInfo.InvariantCulture)}{(Math.Abs(f % 1) < float.Epsilon ? ".0" : "")}f"/*.Replace(",", ".")*/;
    }

    public static float StringToFloat(string s)
    {
        var charsToTrim = new[] {'f'};
        return float.Parse(s.TrimEnd(charsToTrim), CultureInfo.InvariantCulture);
    }
}

[Serializable]
public struct WordPositionForJson
{
    public string x;
    public string y;
    public string z;

    public WordPositionForJson(Vector3 position)
    {
        x = SphereModelForJson.FloatToString(position.x);
        y = SphereModelForJson.FloatToString(position.y);
        z = SphereModelForJson.FloatToString(position.z);
    }
}
