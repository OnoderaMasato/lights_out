//---------------------------------------------
//
//Tile_Change.cs
//
// 作成日:10月20日
// 作成者:小野寺雅斗
//
//---------------------------------------------
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
/// <summary>
/// ライツアウトにおけるタイルのオンオフ切り替えをするためのクラス
/// </summary>
public class Tile_Change : MonoBehaviour, IPointerClickHandler
{
    public Image         image = default;
    //このスクリプトをアタッチしているオブジェクト自身を入れておく
    //public Button       _myself=default;
    //切り替え対象のオブジェクトを一時保管する
    private Image        _target_Tile = default;
    //配列がアタッチされてるゲームオブジェクトを入れておく
    private GameObject  _array_Object = default;
    //生成時に入れられた配列の座標を保持しておくための変数
    private int         _button_Vertical = 0;
    private int         _button_Beside = 0;
    //対象のオブジェクトが入っている配列の座標にアクセスするための変数
    private int         _target_Vertical = 0;
    private int         _target_Beside = 0;
    //変数の受け渡しに使う変数
    private int         _reuse_Vertical = 0;
    private int         _reuse_Beside = 0;
    //配列から取得してきたbool変数を格納するための変数
    private bool        _button_LightsSW;
    //このオブジェクトが上下左右どの端に属するかをbool型で判断
    private bool        _top_End = false;
    private bool        _lower_End = false;
    private bool        _right_End = false;
    private bool        _left_End = false;
    private void Awake()
    {
        //配列がアタッチされてるゲームオブジェクトを見つけてくる
        _array_Object = GameObject.Find("For_Judgment_Game_Object");
    }
    /// <summary>
    /// Imageでリメイクする
    /// </summary>
    public void OnPointerClick(PointerEventData pointerData)
    {
        Debug.Log(+_button_Vertical +","+ _button_Beside + " のタイルがクリックされた!");
        Change();
        Target_Selection();
    }
    //生成時に配列の座標を保持するスクリプト
    public void Store_Array_Number(int Vertical,int Beside)
    {
        _button_Vertical = Vertical;
        _button_Beside = Beside;
        Set_Flag();
        Refresh();
    }
    //生成時に_Verticalと_Besideが特定の値の時に対応するフラグを立てるスクリプト
    private void Set_Flag()
    {
        switch (_button_Vertical)
        {
    //画面最下列時に分岐
            case 0:
                {
                    _lower_End = true;
                }
                break;
    //画面最上列時に分岐
            case 3:
                {
                    _top_End = true;
                }
                break;
        }

        switch (_button_Beside)
        {
    //画面最右列時に分岐
            case 0:
                {
                    _left_End = true;
                }
                break;

            //画面最左列時に分岐
            case 3:
                {
                    _right_End = true;
                }
                break;
        }
    }
    public void Refresh()
    {
    //Reuse_VerticalとReuse_Besideの値を初期化する
        _reuse_Vertical = _button_Vertical;
        _reuse_Beside = _button_Beside;
    }
    public void Change()
    {
    //ライトが消えている場合ライトを点ける
        if (_button_LightsSW == false)
        {
            _button_LightsSW = true;
            //カラーを赤色に設定する
            image.color = Color.red;
        }
    //ライトが点いている場合ライトを消す
        else if (_button_LightsSW == true)
        {
            _button_LightsSW = false;
            //カラーを青色に設定する
            image.color = Color.blue;
        }
    //LightsSWの状態を配列に入れる
        _array_Object.GetComponent<Array>().Swich[_button_Vertical, _button_Beside] = _button_LightsSW;
    }
    public void Target_Selection()
    {
    //立てたフラグに応じて実行するメソッドが変わる
        switch (_top_End, _lower_End, _right_End, _left_End)
        {
    //画面右上端
            case (true, false, true, false):
                {
                    Change_Left_Neighbor();
                    Change_Bottom_Neighbor();
                }
                break;
    //画面左上端
            case (true, false, false, true):
                {
                    Change_Right_Neighbor();
                    Change_Bottom_Neighbor();
                }
                break;
    //画面右下端
            case (false, true, true, false):
                {
                    Change_Left_Neighbor();
                    Change_Top_Neighbor();
                }
                break;
    //画面左下端
            case (false, true, false, true):
                {
                    Change_Right_Neighbor();
                    Change_Top_Neighbor();
                }
                break;
    //画面最上列
            case (true, false, false, false):
                {
                    Change_Left_Neighbor();
                    Change_Right_Neighbor();
                    Change_Bottom_Neighbor();
                }
                break;
    //画面最下列
            case (false, true, false, false):
                {
                    Change_Left_Neighbor();
                    Change_Right_Neighbor();
                    Change_Top_Neighbor();
                }
                break;
    //画面最右列
            case (false, false, true, false):
                {
                    Change_Left_Neighbor();
                    Change_Top_Neighbor(); 
                    Change_Bottom_Neighbor();
                }
                break;
    //画面最左列
            case (false, false, false, true):
                {
                    Change_Right_Neighbor();
                    Change_Top_Neighbor();
                    Change_Bottom_Neighbor();
                }
                break;
    //それ以外
            case (false, false, false, false):
                {
                    Change_Top_Neighbor();
                    Change_Bottom_Neighbor();
                    Change_Left_Neighbor();
                    Change_Right_Neighbor();
                }
                break;
        }
    }
    private void Change_Top_Neighbor()
    {
        _reuse_Vertical++;
        _target_Vertical = _reuse_Vertical;
        _target_Beside = _reuse_Beside;
        Get_Target_Button();

    }
    private void Change_Bottom_Neighbor()
    {
        _reuse_Vertical--;
        _target_Vertical = _reuse_Vertical;
        _target_Beside = _reuse_Beside;
        Get_Target_Button();
    }
    private void Change_Left_Neighbor()
    {
        _target_Vertical = _reuse_Vertical;
        _reuse_Beside--;
        _target_Beside = _reuse_Beside;
        Get_Target_Button();
    }
    //右隣のボタンを選択する
    private void Change_Right_Neighbor()
    {
        _target_Vertical = _reuse_Vertical;
        _reuse_Beside++;
        _target_Beside = _reuse_Beside;
        Get_Target_Button();
    }
    private void Get_Target_Button()
    {
    //配列から対象のボタンを取り出す
        _target_Tile = _array_Object.GetComponent<Array>().Tiles[_target_Vertical,_target_Beside];
    //取り出したボタンの状態を切り替える
        _target_Tile.GetComponent<Tile_Change>().Change();
        Refresh();
    }
}
