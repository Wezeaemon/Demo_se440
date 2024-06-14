using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    [SerializeField] private float spawnInterval = 1f;
    private float _timer;
    
        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if(_timer >= spawnInterval)
        {
            _timer -= spawnInterval ;
            Spawn();
        }
    }
    private void Spawn()
    {
        if(!ObjectPool.Instance.CanSpawn()) return;
      var Obj = ObjectPool.Instance.PickOne(transform);
      Obj.SetActive(true);
    }
    
}
