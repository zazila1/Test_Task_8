using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonSerializationController : MonoBehaviour
{
    private SetsForJson _SphereSets;
    private string _FilePath = "json.txt";

    public delegate void SetsUpdates(List<int> ids);
    public event SetsUpdates OnSetsUpdate;

    private void Start()
    {
        _SphereSets = new SetsForJson();
        LoadFromFile();
    }

    private void SaveToFile()
    {
        File.WriteAllText(_FilePath, JsonUtility.ToJson(_SphereSets));
    }

    public void LoadFromFile()
    {
        try
        {
            string jsonString = File.ReadAllText(_FilePath);

            _SphereSets = JsonUtility.FromJson<SetsForJson>(jsonString);
        
            OnSetsUpdate?.Invoke(_SphereSets.GetIdList());
        }
        catch (Exception e)
        {
            return;
        }
        
    }

    public void AddSet(List<GameObject> spheres)
    {
        _SphereSets.AddSet(spheres);
        
        OnSetsUpdate?.Invoke(_SphereSets.GetIdList());
        
        SaveToFile();
    }
    
    public List<(Vector3, float)> GetSetParamsById(int id)
    {
        List<(Vector3, float)> spheresParams = new List<(Vector3, float)>();
        
        foreach (var set in _SphereSets.sets)
        {
            if (set.GetId() == id)
            {
                for (int i = 0; i < set.spheres.Count; i++)
                {
                    float scale = SphereModelForJson.StringToFloat(set.spheres[i].scale);
                    Vector3 position = new Vector3()
                    {
                        x = SphereModelForJson.StringToFloat(set.spheres[i].wordPosition.x),
                        y = SphereModelForJson.StringToFloat(set.spheres[i].wordPosition.y),
                        z = SphereModelForJson.StringToFloat(set.spheres[i].wordPosition.z),
                    };
                    spheresParams.Add((position, scale));
                }
            }
        }

        return spheresParams;
    }

    
}
