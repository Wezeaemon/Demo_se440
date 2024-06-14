using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCome : MonoBehaviour
{
    [SerializeField] Transform[] WayPoint;
   [SerializeField] GameObject Point;
   [SerializeField] private int Speed;
   private int Direction = 1;
   private int  PointCount;
   private int PointIndex;
   [SerializeField] private float StopTemporary;
   [SerializeField] private int SpeedMultiplear;
   private Vector3 MoveDirection;
    private void Awake()
    {
      WayPoint = new Transform[Point.transform.childCount];
        for(int i = 0 ; i < Point.gameObject.transform.childCount; i++)
        {
            WayPoint[i] = Point.transform.GetChild(i).gameObject.transform;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        PointCount = WayPoint.Length;
        PointIndex = 1;
        MoveDirection = WayPoint[PointIndex].transform.position;
    }
 
    // Update is called once per frame
    void Update()
    {
      var Step = SpeedMultiplear * Speed * Time.deltaTime;
      transform.position = Vector3.MoveTowards(transform.position, MoveDirection, Step);
      if(transform.position == MoveDirection)
      {
        NextPoint();
      }   
    }
    private void NextPoint()
    {
         if(PointIndex == PointCount -1)
         {
             Direction = -1;
         }
         if(PointIndex == 0)
         {
            Direction = 1;
         }
         PointIndex += Direction;
         MoveDirection = WayPoint[PointIndex].transform.position;
         StartCoroutine(LinePoint());
    }
    IEnumerator LinePoint()
    {
        SpeedMultiplear = 0;
         yield return new WaitForSeconds(StopTemporary);
         SpeedMultiplear = 1;
    }

}
