using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Rat : MonoBehaviour
{
    public int increaseHP;

    Animator anim; //เรียกใช้งานเอนิเมชัน
    SpriteRenderer sr; //ใช้งานภาพ 2D

    [SerializeField] int speed = 1;
    [SerializeField] Transform Player; //ตำแหน่งของPlayer
    [SerializeField] float closeDistance = 5f; //วงแดง รัศมี=5
    [SerializeField] float LongDistance = 7f;  //วงสีเขียว รัศมี=7 
    //*SerializeFieldgs เหมือนกับกับPublic แต่ใช้ได้เฉพาะในควาสนี้เท่านั้น ไม่สามารถเรียกใช้มรคลาสอื่นได้
    float distanceToPlayer = Mathf.Infinity; //ค่าระยะห่าง
    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        DetectPlayer();
    }

    public void DetectPlayer() //สรวจสอบผู้เล่น
    {
        distanceToPlayer = Vector3.Distance(Player.position, transform.position); //ไว้หาDistance ระหว่าง Player,NPC
                                                                                  //ตำแหน่งผู้เล่น        //ตำแหน่งNPC
        if (distanceToPlayer <= LongDistance) //ถ้าเข้าในว่าสีเขียวจะทำงาน
                                              //วงสีเขียว
        {
            anim.SetInteger("Status", 0);
            FollowPlayer();
            if (distanceToPlayer <= closeDistance)  //ถ้าเข้าในว่าสีแดงจะทำงาน
            {
                CoinData.HP -= increaseHP;
                anim.SetInteger("Status", 1);
                FollowPlayer(); //ติดตามผู้เล่น
            }
        }
        else //หากหลุดออกจากวงหรืออยู่นอกว่า
        {
            anim.SetInteger("Status", 2);
        }
    }

    public void FollowPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.position, speed * Time.deltaTime); //ให้ตามPlayer ด้วยความเร็ว*Time.deltaTime                                                                                                    //ตำแหน่งNPC       //ตำแหน่งPlayer    //ติดตามด้วยความเร็วที่กำหนด
    }
    private void OnDrawGizmosSelected() //เพื่อให้เห็นระยะ
    {
        Gizmos.color = Color.red; //ให้วงกลมสีแดง
        Gizmos.DrawWireSphere(transform.position, closeDistance);

        Gizmos.color = Color.green; //ให้วงกลมสีเขียว
        Gizmos.DrawWireSphere(transform.position, LongDistance);
    }
}
