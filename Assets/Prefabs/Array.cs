using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Array : MonoBehaviour
{   public bool[,]  Swich= new bool[5, 5];//タイルの状態を格納するための配列
    public Image[,] Tiles = new Image[5, 5];//タイルを格納するための配列
    public bool LightsSW=true;//
    private int Vertical = 3;//タイルの縦値管理用変数
    private int Beside = -1;//タイルの横値管理用変数
    private int False_Count = 0;//消えているライトの数を数える
    public void Judgment()//ライトがすべて消えたかどうかを判断する
    {
        foreach(bool i in Swich)
        {
            LightsSW = Swich[Vertical, Beside];//配列からLightsSWを取り出す
            if(LightsSW==false)
            {
                False_Count++;
            }
            Debug.Log(Beside + "," + Vertical + "=" + LightsSW);//座標の位置とオブジェクトの状態をDebug.Logで書き出す
            Debug.Log(False_Count);
        }
        if(False_Count==16)
        {
            False_Count = 0;
        }

    }
}
