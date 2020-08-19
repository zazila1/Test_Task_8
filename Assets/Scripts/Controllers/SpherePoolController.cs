using System.Collections.Generic;
using UnityEngine;

public class SpherePoolController : MonoBehaviour
{
    [SerializeField] private GameObject _SpherePrefab;
    
    [SerializeField] [Range(0, 200)] private int _InitPoolSize = 10;

    private Queue<GameObject> _Pool = new Queue<GameObject>();
    private List<GameObject> _SpawnedObjects = new List<GameObject>();

    private bool _PoolReady = false;

    void Start()
    {
        FillPool(_InitPoolSize);
        _PoolReady = true;
    }
    
    private void FillPool(int count)
    {
        for (int i = 0; i < count; i++)
        {
            var sphereGameObject = Instantiate(_SpherePrefab, transform.position, Quaternion.identity, transform);
            
            sphereGameObject.SetActive(false);
            _Pool.Enqueue(sphereGameObject);
        }
    }
  

    public GameObject Spawn(Vector3 spawnPosition, Transform parentTransform)
    {
        if (_Pool.Count == 0)
        {
            FillPool(_InitPoolSize);
        }
        
        var sphereGameObject = _Pool.Dequeue();
        Transform sphereTransform = sphereGameObject.transform;
        
        sphereTransform.SetParent(parentTransform);
        sphereTransform.position = spawnPosition;
        
        _SpawnedObjects.Add(sphereGameObject);
        
        sphereGameObject.SetActive(true);
        
        return sphereGameObject;
    }

    public void Remove(GameObject sphereGameObject)
    {
        Transform itemTransform = sphereGameObject.transform;
        
        itemTransform.SetParent(transform);
        itemTransform.position = transform.position;
        
        sphereGameObject.SetActive(false);

        _SpawnedObjects.Remove(sphereGameObject);
        _Pool.Enqueue(sphereGameObject);
    }

    public void RemoveAll()
    {
        List<GameObject> copy = new List<GameObject>(_SpawnedObjects);

        foreach (var sphere in copy)
        {
            Remove(sphere);
        }
    }
}
