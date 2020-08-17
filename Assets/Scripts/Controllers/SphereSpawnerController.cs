using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpawnerController : MonoBehaviour
{
    [SerializeField] private SpherePoolController _Pool;
    [SerializeField] private int _SpheresCount = 10;
    public void GenerateSpheres()
    {
        for (int i = 0; i < _SpheresCount; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-10f, 10f), Random.Range(-3f, 5f),Random.Range(-10f, 10f));
            float randomScale = Random.Range(0.1f, 1.5f);
            
            var sphere = _Pool.Spawn(randomPosition, transform);
            sphere.transform.localScale = Vector3.one * randomScale;
        }
    }

    public void ClearSpheres()
    {
        _Pool.RemoveAll();
    }
}
