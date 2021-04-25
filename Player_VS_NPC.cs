using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_VS_NPC : MonoBehaviour
{
    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("BoolDead", false);
    }
    private void OnCollisionEnter2D(Collision2D collision) //เช็ดการชนObjectของ2D เมื่อชนแล้วเอาค่ามาใส่ในCollition
    {
        if (collision.gameObject.tag == "NPC") //ใส่playerเพราะใส่ในcoin แล้วจะเช็คว่าชนplayer
        {
            anim.SetBool("BoolDead", true);
        }
    }
}
