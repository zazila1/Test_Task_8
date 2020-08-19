using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SphereSpawnerController : MonoBehaviour
{
    [SerializeField] private JsonSerializationController _SerializationController;
    [SerializeField] private SpherePoolController _Pool;
    private int _SpheresCount = 10;
    private float screenBordersOffset = 0.1f; // 10%
    
    List<GameObject> _SpheresInScene = new List<GameObject>();

    private void Start()
    {
        
    }

    public void GenerateSpheres()
    {
        List<(Vector3, float)> sphereParams = new List<(Vector3, float)>();
        for (int i = 0; i < _SpheresCount; i++)
        {
            Camera camera = Camera.main;

            Vector3 randomCamPosition = new Vector3(Random.Range(Screen.width * screenBordersOffset, Screen.width * (1-screenBordersOffset)), 
                                                    Random.Range(Screen.height * screenBordersOffset, Screen.height * (1-screenBordersOffset)), 
                                                    Random.Range(camera.farClipPlane * screenBordersOffset, camera.farClipPlane * (1-screenBordersOffset)));
            Vector3 randomPosition = camera.ScreenToWorldPoint(randomCamPosition);
            float randomScale = Random.Range(0.1f, 1.5f);
            
            sphereParams.Add((randomPosition, randomScale));
        }
        
        SpawnSpheres(sphereParams);
    }
    
    public void SpawnSpheres(List<(Vector3, float)> sphereParams)
    {
        ClearSpheres();
        foreach (var sphereParam in sphereParams)
        {
            var sphere = _Pool.Spawn(sphereParam.Item1, transform);
            sphere.transform.localScale = Vector3.one * sphereParam.Item2;
            
            _SpheresInScene.Add(sphere);
        }
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
