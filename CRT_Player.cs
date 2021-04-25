using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CRT_Player : MonoBehaviour
{
    SpriteRenderer sr;
    Animator anim;
    public float speed= 5;
    //float speedJump = 13;
    float xInput,yInput;
    //bool checkPressBtt = false;
    public string nameScene;
    public float timeLeft = 3f;
    public bool isGrounded = false;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 CharacterScale = transform.localScale;
        if (CoinData.HP>0) //ถ้า HP มากกว่า 0 ถึงจะทำงาน
        {
            if (Input.GetButton("Horizontal")) //ถ้าเดินในเกมHorizontal
            {
                xInput = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

                string Walk_2 = MoveHorizontal(); //รีเทิร์นค่า walk มาเก็บใน Walk_2 เเละเรียกใช้งานฟังชั่น
                print(Walk_2); //แล้วสั่งปริ้น Walk_2

                if(Input.GetAxis("Horizontal")<0) //ถ้าเคลื่อนที่ในเกม Horizontal น้อยกว่า 0
                {
                    CharacterScale.x = -0.05560755f; //ให้สเกลเกล แกนx
                }
                if (Input.GetAxis("Horizontal") > 0)//ถ้าเคลื่อนที่ในเกม Horizontal มากกว่า 0
                {
                    CharacterScale.x = 0.05560755f; //ให้สเกลเกล แกนx
                }
                transform.localScale = CharacterScale;
            }
            else
            {
                anim.SetBool("BoolWalk", false); //หยุดเล่นอนิเมชั่นเดิน
            }

            if (Input.GetButton("Jump"))
            {

                /*yInput = Input.GetAxis("Jump") * speedJump * Time.deltaTime;*/
                
                string Jump_2 = MoveJump(); //รีเทิร์นค่า Jump มาเก็บใน Jump_2 และเรียกใช้งานฟังก์ชั่น
                print(Jump_2); //สั่งปริ้น Jump_2
                MoveJump();
                audioSource.PlayOneShot(SoundManager.Instance.Jump);  //ใส่เสียงให้การกระโดด
            }
            else
            {
                anim.SetBool("BoolJump", false); //หยุดเล่นอนิเมชั่นกระโดด
            }

            /*if (checkPressBtt) //เช็คการกดปุ่ม
            {
                MoveHorizontal();//ฟังก์ชันนี้จะทำงานก็ต่อเมื่อ checkPressBtt เป็น True
                MoveJump();
            }*/
        }
        if(CoinData.HP<=0) //ถ้า HP <=0 ให้ทำงาน
        {
            anim.SetBool("BoolDead", true); //เล่น animetion dead
            if(timeLeft>0) //ถ้า timeLeft>0
            {
                timeLeft -= Time.deltaTime;//timeLeft จะถูกลบด้วย Time.deltaTime
                if(timeLeft<=1) //ถ้าtimeLeft <=1
                {
                    SceneManager.LoadScene("Lose"); //ให้LoadScene Lose
                }
            }
        }
        else 
        {
            anim.SetBool("BoolDead", false); //หยุดเล่น animetion dead
        }
    }

    public string MoveHorizontal() 
    {
        anim.SetBool("BoolWalk", true); //แสดงอนิเมชั่นเดิน
        transform.Translate(xInput, 0, 0);
        string Walk = "You Walk";  //เก็บคำว่า "You Walk" เก็บใน Walk
        return Walk; //รีเทิร์นค่า Walk

    }

    public string MoveJump()
    {
        anim.SetBool("BoolJump", true); //เล่นอนิเมชั่นกระโดด
        //transform.Translate(0, yInput, 0);
        if(Input.GetButtonDown("Jump") && isGrounded==true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 7f), ForceMode2D.Impulse);
        }
        string Jump = "You Jump"; //เก็บคำว่า "You Jump" เก็บใน Jump
        return Jump; //รีเทิร์นค่า Jump
    }



   /* public void RightPressBtt() //กดปุ่มไปซ้าย
    {
        xInput = speed * Time.deltaTime;
        checkPressBtt = true;
    }
    public void LeftPressBtt()  //กดปุ่มไปขวา
    {
        xInput = -speed * Time.deltaTime;
        checkPressBtt = true;
    }
    public void UpPressBtt()  //กดปุ่มกระโดด
    {
        yInput = speedJump * Time.deltaTime;
        checkPressBtt = true;
    }

    public void UpBtt() //ไม่กดปุ่มใดๆ
    {
        checkPressBtt = false;
    }*/
}
