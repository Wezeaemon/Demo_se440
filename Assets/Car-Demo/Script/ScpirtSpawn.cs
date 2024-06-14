using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScpirtSpawn : MonoBehaviour
{
    [SerializeField] 
   private Queue <GameObject> _poolQuaueue = new Queue<GameObject>();
   [SerializeField] GameObject Egges;
   [SerializeField] private int poolSize = 10; 
   [SerializeField] private float Current;
   [SerializeField] private float MaxCurrent;
   [SerializeField] private float CurrentSpeed;
   [SerializeField] ScpirtSpawn Spawn;
   void Start()
   {
       Invoke(nameof(EggesOff), CurrentSpeed);
   }
    // Start is called before the first frame update
    public void OnEnable()
    {
        InvokeRepeating(nameof(UpdateEgges), MaxCurrent,MaxCurrent);
    }
    public void OnDisable()
    {
           CancelInvoke(nameof(UpdateEgges));
    }
    // Update is called once per frame
    void UpdateEgges()
    {
        GameObject SpawnEgges = Instantiate(Egges, transform.position, Quaternion.identity);
    }
    public void EggesOff()
    {
       Spawn.enabled = false;
    }
}
