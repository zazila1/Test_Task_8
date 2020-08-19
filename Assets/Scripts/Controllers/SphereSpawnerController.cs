using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpawnerController : MonoBehaviour
{
    [SerializeField] private JsonSerializationController _SerializationController;
    [SerializeField] private SpherePoolController _Pool;
    [SerializeField] private int _SpheresCount = 10;
    
    
    List<GameObject> _SpheresInScene = new List<GameObject>();
    
    public void GenerateSpheres()
    {
        
        for (int i = 0; i < _SpheresCount; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-10f, 10f), Random.Range(-3f, 5f),Random.Range(-10f, 10f));
            float randomScale = Random.Range(0.1f, 1.5f);
            
            var sphere = _Pool.Spawn(randomPosition, transform);
            sphere.transform.localScale = Vector3.one * randomScale;
            
            _SpheresInScene.Add(sphere);
        }
        
        
        // SphereModelForJson x = new SphereModelForJson(spheresInScene[0]);
        // x.id = "1";
        // x.scale = SphereModelForJson.FloatToString(0.2f);
        // x.wordPosition = new WordPositionForJson(new Vector3(1.5f, 2, 3));
        //
        // SetsForJson setsForJson = new SetsForJson();
        // setsForJson.AddSet(spheresInScene);
        // setsForJson.AddSet(spheresInScene);
        
        // Debug.Log(JsonUtility.ToJson(x));
        // Debug.Log(SphereModelForJson.StringToFloat("2.4f"));
        // Debug.Log(JsonUtility.ToJson(setsForJson));
        
        // _SerializationController.AddSet(_SpheresInScene);
        // _SerializationController.AddSet(_SpheresInScene);
        // _SerializationController.SaveToFile();
    }

    public void ClearSpheres()
    {
        _Pool.RemoveAll();
        _SpheresInScene.Clear();
    }

    public void SaveCurrentSet()
    {
        _SerializationController.AddSet(_SpheresInScene);
    }
}
