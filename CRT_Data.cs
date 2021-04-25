using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary; //แปลงจากภาษาคนเป็นภาษาคอมหรือที่เครื่องเข้าใจ

using UnityEngine.UI;

public class CRT_Data : MonoBehaviour
{
    public GameData data; //เข้าข้อมูลใน GameData มาใส่ใน Data
    string dataFillePath; //เก็บไฟล์ที่เก็บข้อมูล
    BinaryFormatter bf;  //เก็บข้อมูลที่เป็นBinary
    private void Awake() //ใช้เมื่อเริ่ม
    {
        bf = new BinaryFormatter();
        dataFillePath = Application.persistentDataPath + "/game.dat";
    }                   //หาตำแหน่งปัจจุบันของเกมมาให้หน่อย      //ชื่อไฟล์ที่เก็บข้อมูลเกม

    public void UpdateData()
    {
        data.Coin = CoinData.Coin;  //เซฟข้อมูล ตรงนี้สามารถเปลี่ยนได้สามารถเพิ่มเข้าไปได้
        data.HP = CoinData.HP; //ต้องการเซฟอะไรบ้างใส่ในนี้
    }

    public void SaveData()
    {
        UpdateData();
        FileStream fs = new FileStream(dataFillePath, FileMode.Create); //สร้างไฟล์ Stream ขึ้นมา 1 ไฟล์ที่เป็น/game.dat ไว้ในชื่อ fs
                                                                        //สร้างไฟล์ขึ้นมา1ไฟล
        bf.Serialize(fs, data); //เอาdata ไปใส่ในfs แล้วไปแปลงเป็นภาษาคอมชื่อ bf
        fs.Close(); //ให้ปิดไฟล์ให้ด้วยป้องกันโดนแฮก
    }

    public void LoadData()
    {
        if (File.Exists(dataFillePath)) //ถ้ามี/game.dat //ให้เครื่องหาไฟล์/game.dat
        {
            FileStream fs = new FileStream(dataFillePath, FileMode.Open);
            data = (GameData)bf.Deserialize(fs);
            fs.Close();
            DisplayData();
        }
    }

    public void DisplayData() //เปลี่ยนตามตัวแปรในเกมของตนเอง
    {
        GameObject.FindGameObjectWithTag("CoinText").GetComponent<Text>().text = data.Coin.ToString(); //แสดงผลบนหน้าจอ ถ้าไม่อยากให้โชว์ในหน้าจอให้เอาออกได้เลย
        CoinData.Coin = data.Coin;
        GameObject.FindGameObjectWithTag("HPText").GetComponent<Text>().text = data.HP.ToString();
        CoinData.HP = data.HP;
    }

    private void OnEnable() //เปิดขึ้นมาหลังจากAwake
    {
        LoadData();
    }
    private void OnDisable() //ถ้าปิดเกมให้SaveData
    {
        SaveData();
    }
}
