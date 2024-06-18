using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 //[RequireComponent(typeof(ParticleSystem))]
public class CarController : MonoBehaviour
{
    [SerializeField] private float Speed; // Car này được sử dụng CharacterController và Animator 
    [SerializeField] private float Gravity;
    private Vector3 VeGravity;
    [SerializeField] Transform LeftTransform;
    [SerializeField] Transform RightTransform;
    [SerializeField] Transform LeftTransformCar;
    [SerializeField] Transform RightTransformCar;
    [SerializeField] private float SpeedRotationCar;
    [SerializeField] private float SpeedRotation;
    [SerializeField] Animator animator;
    
    [SerializeField] private float MaxSpeed;
    [SerializeField] private float Delta;
    [SerializeField] private float MaxSpeedNow;
    private float Current;
    [SerializeField] private float CurrentInvoke;
    [SerializeField] private float MaxCurrent;
    [System.Serializable]
    public struct Wheel
    {
        public ParticleSystem ps;
        public CharacterController Controller;
    
    }
    [SerializeField]
    private List<Wheel> Wheels = new List<Wheel>();
  //  private List<Wheel1> Wheels1 = new List<Wheel1>();
    // Start is called before the first frame update
    void Start()
    {
       Cursor.lockState = CursorLockMode.Locked;
        animator = gameObject.GetComponent<Animator>();
       Current = MaxCurrent;
        

        
    }
    
    // Update is called once per frame
    void Update()
    {
       //float MoveX = Input.GetAxis("Horizontal");
       float MoveZ = Input.GetAxis("Vertical");
       Vector3 move =  transform.forward * MoveZ;
       VeGravity.y += Gravity * Time.deltaTime;
       foreach(var Wheel in Wheels)
       {
        Wheel.Controller.Move(VeGravity * Time.deltaTime);
        Wheel.Controller.Move(Speed * move * Time.deltaTime);
       }
       if(Input.GetKey(KeyCode.A))
       {
          //LeftTransform.Rotate(0, SpeedRotattion * -Time.deltaTime, 0);
          LeftTransformCar.Rotate(0, SpeedRotationCar * -Time.deltaTime, 0);
          animator.SetTrigger("Run");
          animator.ResetTrigger("Idea");
         // ParticleSystem.emission.enabled = true;
          PlayFx(true);
        
       }
       else if(Input.GetKeyUp(KeyCode.A))
       {
         animator.SetTrigger("Idea");
         animator.ResetTrigger("Run");
          PlayFx(false);
  
       }
       else if(Input.GetKey(KeyCode.D))
       {
          //RightTransform.Rotate(0, SpeedRotattion * Time.deltaTime, 0);
          RightTransformCar.Rotate(0, SpeedRotationCar * Time.deltaTime, 0);
          animator.SetTrigger("Run");
          animator.ResetTrigger("Idea");
          PlayFx(true);
       }
       else if(Input.GetKeyUp(KeyCode.D))
       {
         animator.SetTrigger("Idea");
         animator.ResetTrigger("Run");
         PlayFx(false);
       }
       else if(Input.GetKey(KeyCode.LeftArrow))
       {
         /// LeftTransform.Rotate(0, SpeedRotattion * -Time.deltaTime, 0);
           LeftTransformCar.Rotate(0, SpeedRotationCar * -Time.deltaTime, 0);
           animator.SetTrigger("Run");
           animator.ResetTrigger("Idea");
           PlayFx(true);
       }
       else if(Input.GetKeyUp(KeyCode.LeftArrow))
       {
         animator.SetTrigger("Idea");
         animator.ResetTrigger("Run");
         PlayFx(false);
       }
       else if(Input.GetKey(KeyCode.RightArrow))
       {
         //RightTransform.Rotate(0, SpeedRotattion * Time.deltaTime, 0);
         RightTransformCar.Rotate(0, SpeedRotationCar * Time.deltaTime, 0);
         animator.SetTrigger("Run");
         animator.ResetTrigger("Idea");
         PlayFx(true);
       }
       else if(Input.GetKeyUp(KeyCode.RightArrow))
       {
         animator.SetTrigger("Idea");
         animator.ResetTrigger("Run");
         PlayFx(false);
       }
       else if(Input.GetKey(KeyCode.W))
       {
          //LeftTransform.Rotate(0, SpeedRotattion * -Time.deltaTime, 0);
          LeftTransformCar.Rotate(0, SpeedRotationCar * -Time.deltaTime, 0);
          animator.SetTrigger("Run");
          animator.ResetTrigger("Idea");
          PlayFx(true);
       }
       else if(Input.GetKeyUp(KeyCode.W))
       {
         animator.SetTrigger("Idea");
         animator.ResetTrigger("Run");
         PlayFx(false);
       }
       else if(Input.GetKey(KeyCode.S))
       {
          //LeftTransform.Rotate(0, SpeedRotattion * -Time.deltaTime, 0);
          LeftTransformCar.Rotate(0, SpeedRotationCar * -Time.deltaTime, 0);
          animator.SetTrigger("Run");
          animator.ResetTrigger("Idea");
          PlayFx(true);
       }
       else if(Input.GetKeyUp(KeyCode.S))
       {
         animator.SetTrigger("Idea");
         animator.ResetTrigger("Run");
         PlayFx(false);
       }
       else if(Input.GetKey(KeyCode.UpArrow))
       {
          //LeftTransform.Rotate(0, SpeedRotattion * -Time.deltaTime, 0);
          LeftTransformCar.Rotate(0, SpeedRotationCar * -Time.deltaTime, 0);
          animator.SetTrigger("Run");
          animator.ResetTrigger("Idea");
           PlayFx(true);
       }
       else if(Input.GetKeyUp(KeyCode.UpArrow))
       {
         animator.SetTrigger("Idea");
         animator.ResetTrigger("Run");
         PlayFx(false);
       }
       else if(Input.GetKey(KeyCode.DownArrow))
       {
          //LeftTransform.Rotate(0, SpeedRotattion * -Time.deltaTime, 0);
          LeftTransformCar.Rotate(0, SpeedRotationCar * -Time.deltaTime, 0);
          animator.SetTrigger("Run");
          animator.ResetTrigger("Idea");
          PlayFx(true);
       }
       else if(Input.GetKeyUp(KeyCode.DownArrow))
       {
         animator.SetTrigger("Idea");
         animator.ResetTrigger("Run");
         PlayFx(false);
       }
        AddSpeed();
      Invoke(nameof(AddSpeedF), CurrentInvoke);
    }
    private void AddSpeedF()
    {
       if(Input.GetKeyDown(KeyCode.F))
       {  
         AddTime();
       }
       
    }
    private void AddSpeed()
    {
       if(Speed > MaxSpeed)
       {
         Speed -= Delta * Time.deltaTime;
       }
    }
    public void AddTime()
    {
      if(Time.time >= Current )
      {
        Speed = 20;
        Current = Time.time + 2/ MaxCurrent; 
      }

    }
    private void PlayFx(bool isPlay)
    {
       foreach(var Wheel in Wheels )
       {
         if(isPlay)
         {
           Wheel.ps.Play();
         }
         else
         {
           Wheel.ps.Stop();
         }
       }
    }
    
   private void Return(GameObject Obj)
    {
        ObjectPool.Instance.ReturnOne(Obj);
    }
}
