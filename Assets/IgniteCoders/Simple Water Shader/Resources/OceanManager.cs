using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanManager : MonoBehaviour
{
    [SerializeField] private GameObject ocean;
    [SerializeField] private float wavePower = 2f;
    private Material _oceanMat;
    // Start is called before the first frame update
    void Start()
    {
        SetValue();
    }
    private void SetValue()
    {
        _oceanMat = ocean.GetComponent<Renderer>().sharedMaterial;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
