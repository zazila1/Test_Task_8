using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonSerializationController : MonoBehaviour
{
    private SetsForJson _SphereSets = new SetsForJson();

    private string _FilePath = "json.txt";
    public void SaveToFile()
    {
        File.WriteAllText(_FilePath, JsonUtility.ToJson(_SphereSets));

        LoadFromFile();
    }

    public void LoadFromFile()
    {
        SetsForJson setsForJson = new SetsForJson();
        string jsonString = File.ReadAllText(_FilePath);

        var x = JsonUtility.FromJson<SetsForJson>(jsonString);
        
        Debug.Log(x);
    }

    public void AddSet(List<GameObject> spheres)
    {
        _SphereSets.AddSet(spheres);
        SaveToFile();
    }
}
