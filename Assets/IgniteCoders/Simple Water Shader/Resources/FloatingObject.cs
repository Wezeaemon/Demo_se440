using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class FloatingObject : MonoBehaviour
{
   [SerializeField] private float underWaterDrag;
   [SerializeField] private float underWaterAngularDrag;
   [SerializeField] private float airDrag;
   [SerializeField] private float airAngularDrag;
   [SerializeField] private float waterpower;
   [SerializeField] private float CoolDown;
   [SerializeField] private Transform[] FeetPosition;
   private Rigidbody rb;
   private bool _isUnderWater;
   private void Start()
   {
     rb = gameObject.GetComponent<Rigidbody>();
     // Application.targetFrameRate = 60;
   }
   void Update()
   {
    int pointUnderWaterCount = 0;
    foreach(var point in FeetPosition)
    {
       var diff = transform.position.y - CoolDown;
    if(diff < 0)
    {
         rb.AddForceAtPosition(Vector3.up * waterpower *  Mathf.Abs(diff), transform.position, ForceMode.Force);
        if(! _isUnderWater)
        {
            SetStage(true);
             _isUnderWater = true;
        }
    }
    }
    
     if(_isUnderWater && pointUnderWaterCount == 0)
    {
       _isUnderWater = false;
        SetStage(false);
    }
   }

   private void SetStage(bool underWater)
   {
      if(underWater)
      {
        rb.drag = underWaterDrag;
        rb.angularDrag = underWaterAngularDrag;
      }
      else
      {
        rb.drag = airDrag;
        rb.angularDrag = airAngularDrag;
      }
   }
   private void OnTriggerEnter(Collider other)
   {
    if(other.gameObject.tag == "ObjectWater")
    {
      
    }
    if(other.gameObject.tag == "ObjectLayer")
    {
      Destroy(gameObject);
    }
   }
}
