using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor_Translate : MonoBehaviour
{
    public GameObject[] Floor;
    float X;
    string Status ="Left";
    float Left, Right;
    // Start is called before the first frame update
   
    void Start()
    {
        Left = -5;
        Right = -2.5f;

    }

    // Update is called once per frame
    void Update()
    {
        MoveX(Floor[0],Left,Right);  //เรียกใช้งาน โดนรับค่าซ้าย ขวา มา
    }
    void MoveX(GameObject Floor,float Left,float Right) //รับค่า GOJ,Left<Right
    {
       if(Floor.transform.position.x>= Right) //ถ้าFloor ตำแหน่ง X มากกว่าหรือเท่ากับ Right 
       {
            Status = "Left"; //Status เท่ากับ Left
       }
       if (Floor.transform.position.x <= Left) //ถ้าFloor ตำแหน่ง X น้อยกว่าหรือเท่ากับ Left
        {
            Status = "Right";
       }

       if (Status == "Left") //ถ้าStatus เท่ากับ Left
       {
            X = -0.01f; //ให้ X เท่ากับ -0,1f
       }
       if (Status == "Right")//ถ้าStatus เท่ากับ Right
       {
            X = 0.01f; //ให้ X เท่ากับ 0,1f
       }
        Floor.transform.position += new Vector3(X, 0, 0); //คำสั่งเคลื่อนที่ 
    }

}
