using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCamera : MonoBehaviour
{
    [SerializeField] private  int Select; // SelectCamera Lựa chọn Camera
    // Start is called before the first frame update
    void Start()
    {
        Selected();
    }

    // Update is called once per frame
    void Update()
    {
        int PrevoiusSelectCamera = Select;
        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if(Select >= transform.childCount - 1)
            {
                Select = 0;
            }
            else
            {
             Select++;
            }
        }
        
        if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if(Select <=  0)
            {
                Select = transform.childCount - 1;
            }
            else
            {
                Select--;
            }
        }
        if(Input.GetKey(KeyCode.Alpha1))
        {
           Select =0;
        }
        if(Input.GetKey(KeyCode.Alpha2) && transform.childCount >= 2f)
        {
           Select = 1;
        }
        if(PrevoiusSelectCamera != Select)
        {
            Selected();
        }
    }
    public void Selected()
    {
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if(i == Select)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
