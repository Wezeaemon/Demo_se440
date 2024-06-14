using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBox : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField]  private float MaxSpeed;
    [SerializeField] private float Delta;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * Speed * Time.deltaTime;
        if(Speed > MaxSpeed)
        {
            Speed -= Delta * Time.deltaTime;
        }
    }
}
