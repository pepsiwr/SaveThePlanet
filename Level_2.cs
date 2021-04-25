using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_2 : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)//ชนแล้วไม่ทะลุ
    {
        if (collision.gameObject.tag == "Player") //ถ้าชนแท้คที่ชื่อ player
        {
            SceneManager.LoadScene("Level_3"); //ให้โหลดซีน
        }
    }
}
