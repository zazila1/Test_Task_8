using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEditor;
using UnityEngine;

[Serializable]
public class SphereModelForJson
{
    public string id;
    public WordPositionForJson wordPosition;
    public string scale;

    public SphereModelForJson(GameObject sphereGameObject)
    {
        wordPosition = new WordPositionForJson(sphereGameObject.transform.position);
        scale = FloatToString(sphereGameObject.transform.localScale.x);
    }
    
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

[Serializable]
public class SetForJson
{
    //private static int _Id = 1;
    
    public string set;
    public List<SphereModelForJson> spheres = new List<SphereModelForJson>();

    public SetForJson(List<GameObject> spheresList, string setId)
    {
        set = setId;
        int sphereId = 1;
        
        foreach (var sphere in spheresList)
        {
            SphereModelForJson sphereForJson = new SphereModelForJson(sphere)
            {
                id = sphereId.ToString(),
            };
            spheres.Add(sphereForJson);
            sphereId++;
        }
        // _Id++;
    }
}
[Serializable]
public class SetsForJson
{
    private int _NextSetId = 1;
 
    public List<SetForJson> sets = new List<SetForJson>();

    public bool AddSet(List<GameObject> spheresList)
    {
        if (_NextSetId <= 15)
        {
            SetForJson setForJson = new SetForJson(spheresList, _NextSetId.ToString());
            sets.Add(setForJson);

            _NextSetId++;

            return true;
        }
        else
        {
            return false;
        }
    }
    // (_Id++).ToString(CultureInfo.InvariantCulture);
}
