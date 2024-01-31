using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Create : MonoBehaviour
{
    public Image Tile;
    private GameObject Array_Object;
    public GameObject parent;
    Vector3 Coordinate;
    public bool LightsSW;
    private int Rnd =0;//生成した数の格納先
    private int Vertical = 3;//タイルの縦値管理用変数
    private int Beside = 0;//タイルの横値管理用変数
    private int VerticalMin = 0;//縦軸の最小値(番兵)
    private int BesideMax = 4;//横軸の最大値(番兵)
    private void Start()
    {
        Array_Object = GameObject.Find("For_Judgment_Game_Object");//配列がアタッチされてるゲームオブジェクトを見つけてくる
    }
    private void Update()
    {
        if (Vertical>=VerticalMin)
        {
            Coordinate = new Vector3((Vertical * 200)-300,(Beside * 200)-300, 0);//中心に生成されるように生成位置を調整

            if (Beside <= BesideMax)
            {
                Image _Tile = Instantiate(Tile, Coordinate, Quaternion.identity);//タイルを生成する
                Array_Object.GetComponent<Array>().Tiles[Vertical, Beside]=_Tile;//タイルを指定した配列の座標に入れておく
                _Tile = _Tile.GetComponent<Tile_Change>().image;//生成したタイルにアタッチしているスクリプトのオブジェクト自身を入れておく
                _Tile.GetComponent<Tile_Change>().Store_Array_Number(Beside, Vertical);//生成したタイルに配列の座標を入れる

                Rnd = Random.Range(0, 2);
                switch (Rnd)
                {
                    case 0:
                        LightsSW = true;
                        _Tile.GetComponent<Tile_Change>().Change();//タイルの状態を「オン」に設定する
                        _Tile.color = Color.red;//カラーを赤色に設定する
                        Array_Object.GetComponent<Array>().Swich[Vertical, Beside] = LightsSW;//LightsSWの状態を配列に入れる
                        break;
                    
                    case 1:
                        LightsSW = false;//タイルの状態を「オフ」に設定する
                        _Tile.GetComponent<Tile_Change>().Change();

                        _Tile.color = Color.blue;//カラーを青色に設定する
                        Array_Object.GetComponent<Array>().Swich[Vertical, Beside] = LightsSW;//LightsSWの状態を配列に入れる
                        break;
                }
                _Tile.transform.SetParent(parent.transform, false);
                Beside++;
            }
            if(Beside==BesideMax)
            {
                Vertical--;
                Beside = 0;//変数Besideを0で初期化
            }

        }
    }
}