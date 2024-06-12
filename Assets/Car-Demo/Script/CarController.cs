using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 //[RequireComponent(typeof(ParticleSystem))]
public class CarController : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private float Gravity;
    private Vector3 VeGravity;
    [SerializeField] Transform LeftTransform;
    [SerializeField] Transform RightTransform;
    [SerializeField] Transform LeftTransformCar;
    [SerializeField] Transform RightTransformCar;
    [SerializeField] private float SpeedRotationCar;
    [SerializeField] private float SpeedRotation;
    [SerializeField] CharacterController controller;
    [SerializeField] Animator animator;
    [SerializeField] ParticleSystem ps;
    [SerializeField] ParticleSystem ps1;
    [SerializeField] private float MaxSpeed;
    [SerializeField] private float Delta;
    [SerializeField] private float MaxSpeedNow;
   
    // Start is called before the first frame update
    void Start()
    {
       Cursor.lockState = CursorLockMode.Locked;
        animator = gameObject.GetComponent<Animator>();
         ParticleSystem ps = GetComponent<ParticleSystem>();
         ParticleSystem ps1 = GetComponent<ParticleSystem>();

        
    }

    // Update is called once per frame
    void Update()
    {
       //float MoveX = Input.GetAxis("Horizontal");
       float MoveZ = Input.GetAxis("Vertical");
       Vector3 move =  transform.forward * MoveZ;
       VeGravity.y += Gravity * Time.deltaTime;
       controller.Move(VeGravity * Time.deltaTime);
       controller.Move(Speed * move * Time.deltaTime);
       if(Input.GetKey(KeyCode.A))
       {
          //LeftTransform.Rotate(0, SpeedRotattion * -Time.deltaTime, 0);
          LeftTransformCar.Rotate(0, SpeedRotationCar * -Time.deltaTime, 0);
          animator.SetTrigger("Run");
          animator.ResetTrigger("Idea");
         // ParticleSystem.emission.enabled = true;
         ps.Play();
         ps1.Play();
       }
       else if(Input.GetKeyUp(KeyCode.A))
       {
         animator.SetTrigger("Idea");
         animator.SetTrigger("Run");
         ps.Stop();
          ps1.Stop();
       }
       else if(Input.GetKey(KeyCode.D))
       {
          //RightTransform.Rotate(0, SpeedRotattion * Time.deltaTime, 0);
          RightTransformCar.Rotate(0, SpeedRotationCar * Time.deltaTime, 0);
          animator.SetTrigger("Run");
          animator.ResetTrigger("Idea");
            ps.Play();
             ps1.Play();
       }
       else if(Input.GetKeyUp(KeyCode.D))
       {
         animator.SetTrigger("Idea");
         animator.ResetTrigger("Run");
          ps.Stop();
          ps1.Stop();
       }
       else if(Input.GetKey(KeyCode.LeftArrow))
       {
         /// LeftTransform.Rotate(0, SpeedRotattion * -Time.deltaTime, 0);
           LeftTransformCar.Rotate(0, SpeedRotationCar * -Time.deltaTime, 0);
           animator.SetTrigger("Run");
           animator.ResetTrigger("Idea");
           ps.Play();
           ps1.Play();
       }
       else if(Input.GetKeyUp(KeyCode.LeftArrow))
       {
         animator.SetTrigger("Idea");
         animator.ResetTrigger("Run");
          ps.Stop();
           ps1.Stop();
       }
       else if(Input.GetKey(KeyCode.RightArrow))
       {
         //RightTransform.Rotate(0, SpeedRotattion * Time.deltaTime, 0);
         RightTransformCar.Rotate(0, SpeedRotationCar * Time.deltaTime, 0);
         animator.SetTrigger("Run");
         animator.ResetTrigger("Idea");
         ps.Play();
         ps1.Play();
       }
       else if(Input.GetKeyUp(KeyCode.RightArrow))
       {
         animator.SetTrigger("Idea");
         animator.ResetTrigger("Run");
          ps.Stop();
          ps1.Stop();
       }
       else if(Input.GetKey(KeyCode.W))
       {
          //LeftTransform.Rotate(0, SpeedRotattion * -Time.deltaTime, 0);
          LeftTransformCar.Rotate(0, SpeedRotationCar * -Time.deltaTime, 0);
          animator.SetTrigger("Run");
          animator.ResetTrigger("Idea");
          ps.Play();
           ps1.Play();
       }
       else if(Input.GetKeyUp(KeyCode.W))
       {
         animator.SetTrigger("Idea");
         animator.ResetTrigger("Run");
         ps.Stop();
          ps1.Stop();
       }
       else if(Input.GetKey(KeyCode.S))
       {
          //LeftTransform.Rotate(0, SpeedRotattion * -Time.deltaTime, 0);
          LeftTransformCar.Rotate(0, SpeedRotationCar * -Time.deltaTime, 0);
          animator.SetTrigger("Run");
          animator.ResetTrigger("Idea");
           ps.Play();
           ps1.Play();
       }
       else if(Input.GetKeyUp(KeyCode.S))
       {
         animator.SetTrigger("Idea");
         animator.ResetTrigger("Run");
         ps.Stop();
         ps1.Stop();
       }
       else if(Input.GetKey(KeyCode.UpArrow))
       {
          //LeftTransform.Rotate(0, SpeedRotattion * -Time.deltaTime, 0);
          LeftTransformCar.Rotate(0, SpeedRotationCar * -Time.deltaTime, 0);
          animator.SetTrigger("Run");
          animator.ResetTrigger("Idea");
           ps.Play();
            ps1.Play();
       }
       else if(Input.GetKeyUp(KeyCode.UpArrow))
       {
         animator.SetTrigger("Idea");
         animator.ResetTrigger("Run");
          ps.Stop();
           ps1.Stop();
       }
       else if(Input.GetKey(KeyCode.DownArrow))
       {
          //LeftTransform.Rotate(0, SpeedRotattion * -Time.deltaTime, 0);
          LeftTransformCar.Rotate(0, SpeedRotationCar * -Time.deltaTime, 0);
          animator.SetTrigger("Run");
          animator.ResetTrigger("Idea");
          ps.Play();
           ps1.Play();
       }
       else if(Input.GetKeyUp(KeyCode.DownArrow))
       {
         animator.SetTrigger("Idea");
         animator.ResetTrigger("Run");
         ps.Stop();
          ps1.Stop();
       }
        AddSpeed();
       Invoke(nameof(AddSpeedF), MaxSpeedNow);
    }
    private void AddSpeedF()
    {
       if(Input.GetKeyDown(KeyCode.F))
       {  
         Speed = 20;
       }
       
    }
    private void AddSpeed()
    {
       if(Speed > MaxSpeed)
       {
         Speed -= Delta * Time.deltaTime;
       }
    }
}
