using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyExplosionCube : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float CubePerTap = 8f;
    [SerializeField] private int Radious = 200;
    [SerializeField] private float Force = 200;
    [SerializeField] private float RemainingTime = 0.3f;
     [SerializeField] private float RemainingDelete;
    void Start()
    {
       Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    public void Main()
    {
        for(int X = 0; X < CubePerTap ; X++)
        {
            for(int Y = 0; Y < CubePerTap ; Y++)
            {
                for(int Z = 0; Z < CubePerTap; Z++)
                {
                    CreateCube(new Vector3(X, Y , Z));
                    Application.targetFrameRate = 60;
                }
            }
        }
        Destroy(gameObject);
        Application.targetFrameRate = 60;
    }
    private void CreateCube(Vector3 Dominant)
    {
      GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
      Destroy(cube, RemainingDelete);
      Renderer rd = cube.GetComponent<Renderer>();
      rd.material = GetComponent<Renderer>().material;
      cube.transform.localScale = transform.localScale/CubePerTap;
      Vector3 First = transform.position - transform.localScale/2 + cube.transform.localScale/2;
      cube.transform.position = First + Vector3.Scale(cube.transform.localScale, Dominant);
      Rigidbody rb = cube.AddComponent<Rigidbody>();
      rb.AddExplosionForce(Force, transform.position, Radious);
      Application.targetFrameRate = 60;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Invoke(nameof(Main), RemainingTime);
            Application.targetFrameRate = 60;
        }
    }
}
