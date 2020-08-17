using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpherePoolController : MonoBehaviour
{
    [SerializeField] private GameObject _SpherePrefab;
    
    [SerializeField] [Range(0, 200)] private int _InitPoolSize = 10;

    private Queue<GameObject> _Pool = new Queue<GameObject>();
    private List<GameObject> _SpawnedEnemys = new List<GameObject>();

    //private BoxCollider2D _EnemyCollider;
    //private Vector2 _EnemyColliderSize;
    private bool _PoolReady = false;

    private void Awake()
    {
        //_EnemyColliderSize  = _SpherePrefab.GetComponent<BoxCollider2D>().size;
    }

    void Start()
    {
        FillPool(_InitPoolSize);
        _PoolReady = true;
    }
    
    private void FillPool(int count)
    {
        for (int i = 0; i < _InitPoolSize; i++)
        {
            var sphereGameObject = Instantiate(_SpherePrefab, transform.position, Quaternion.identity, transform);
            
            //enemyGameObject.layer = LayerMask.NameToLayer("Hided");
            sphereGameObject.SetActive(false);
            _Pool.Enqueue(sphereGameObject);
        }
    }
  

    // Достаем врага из пула или создаем нового, если пул пустой
    public GameObject Spawn(Vector3 spawnPosition, Transform parentTransform)
    {
        // Если пул пустой
        if (_Pool.Count == 0)
        {
            FillPool(_InitPoolSize);
        }
        
        var sphereGameObject = _Pool.Dequeue();
        Transform sphereTransform = sphereGameObject.transform;
        
        sphereTransform.SetParent(parentTransform);
        sphereTransform.position = spawnPosition;
        
        _SpawnedEnemys.Add(sphereGameObject);
        
        sphereGameObject.SetActive(true);
        
        return sphereGameObject;
    }

    // Возвращаем объект в пул, вайпаем дату и прячем
    public void Remove(GameObject sphereGameObject)
    {
        Transform itemTransform = sphereGameObject.transform;
        
        itemTransform.SetParent(transform);
        itemTransform.position = transform.position;
        
        sphereGameObject.SetActive(false);
        
        _Pool.Enqueue(sphereGameObject);
    }

    // public Vector2 GetEnemyColliderSize()
    // {
    //     return _EnemyColliderSize;
    // }
}
