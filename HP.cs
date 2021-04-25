using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    public int increaseHP;
    public Text HPText;
    private void OnTriggerEnter2D(Collider2D collision) //ชนแล้วทะลุ จะไม่มีแรงมาเกี่ยวข้อง
    {
        if (collision.gameObject.tag == "Player")
        {
            CoinData.HP -= increaseHP; //CoinData คือscriptที่เก็บค่าcoinไว้แล้ว
            HPText.text = CoinData.HP.ToString();
            Destroy(gameObject); //ให้ลบเกมออฟเจคที่โดนนั้นด้วย
        }
    }
}
