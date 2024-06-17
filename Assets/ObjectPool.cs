using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _poolList = new List<GameObject>();
    private Stack<GameObject> _poolStack = new Stack<GameObject>();
    private Queue<GameObject> _poolQueue = new Queue<GameObject>();
    [SerializeField] private GameObject prefab;
    [SerializeField] private int poolSize = 10;
    private static ObjectPool _instance;
    public static ObjectPool Instance
    {
        get{
            if( _instance == null)
            {
                 _instance = FindObjectOfType<ObjectPool>();
            }
            return  _instance;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < poolSize; i++)
        {
            var Obj = Instantiate(prefab, transform);
            Obj.SetActive(false);
            Obj.name = prefab.name + $"({i})";
            _poolQueue.Enqueue(Obj);
        }
       
    }
    public bool CanSpawn()
    {
        return _poolQueue.Count > 0;
    }
    public GameObject PickOne(Transform parent)
    {
       var Obj = _poolQueue.Dequeue();
       Obj.transform.SetParent(parent);
       
       return Obj; 
    }
    public void ReturnOne(GameObject Obj)
    {
        Obj.SetActive(false);
        Obj.transform.SetParent(transform);
        _poolQueue.Enqueue(Obj);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
