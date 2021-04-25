using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag=="Ground") //หากชน tag ที่ชื่อ "Ground"
        {
            Player.GetComponent<CRT_Player>().isGrounded = true; //ให้ isGrounded เป็น true
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground") //หากไม่ชน tag ที่ชื่อ "Ground"
        {
            Player.GetComponent<CRT_Player>().isGrounded = false; //ให้ isGrounded เป็น true
        }
    }
}
