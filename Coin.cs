using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public int increaseCoin;
    public Text CoinText;
    private void OnTriggerEnter2D(Collider2D collision) //ชนแล้วทะลุ จะไม่มีแรงมาเกี่ยวข้อง
    {
        if (collision.gameObject.tag == "Player")
        {
            CoinData.Coin += increaseCoin; //CoinData คือscriptที่เก็บค่าcoinไว้แล้ว
            CoinText.text = CoinData.Coin.ToString();
            Destroy(gameObject);
        }
    }
}
