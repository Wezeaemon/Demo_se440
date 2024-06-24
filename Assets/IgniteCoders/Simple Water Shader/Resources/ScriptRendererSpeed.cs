using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptRendererSpeed : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        meshRenderer.material.mainTextureOffset = new Vector3(-Speed * Time.deltaTime, 0,Speed * Time.deltaTime);
    }
}
