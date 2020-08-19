using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonSerializationController : MonoBehaviour
{
    private SetsForJson _SphereSets = new SetsForJson();

    private string _FilePath = "json.txt";
    private void SaveToFile()
    {
        File.WriteAllText(_FilePath, JsonUtility.ToJson(_SphereSets));
    }

    public void LoadFromFile()
    {
        string jsonString = File.ReadAllText(_FilePath);

        _SphereSets = JsonUtility.FromJson<SetsForJson>(jsonString);
        
        Debug.Log(_SphereSets);
    }

    public void AddSet(List<GameObject> spheres)
    {
        _SphereSets.AddSet(spheres);
        SaveToFile();
    }
}
