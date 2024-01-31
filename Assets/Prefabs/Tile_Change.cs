//---------------------------------------------
//
//Tile_Change.cs
//
// �쐬��:10��20��
// �쐬��:���쎛��l
//
//---------------------------------------------
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
/// <summary>
/// ���C�c�A�E�g�ɂ�����^�C���̃I���I�t�؂�ւ������邽�߂̃N���X
/// </summary>
public class Tile_Change : MonoBehaviour, IPointerClickHandler
{
    public Image         image = default;
    //���̃X�N���v�g���A�^�b�`���Ă���I�u�W�F�N�g���g�����Ă���
    //public Button       _myself=default;
    //�؂�ւ��Ώۂ̃I�u�W�F�N�g���ꎞ�ۊǂ���
    private Image        _target_Tile = default;
    //�z�񂪃A�^�b�`����Ă�Q�[���I�u�W�F�N�g�����Ă���
    private GameObject  _array_Object = default;
    //�������ɓ����ꂽ�z��̍��W��ێ����Ă������߂̕ϐ�
    private int         _button_Vertical = 0;
    private int         _button_Beside = 0;
    //�Ώۂ̃I�u�W�F�N�g�������Ă���z��̍��W�ɃA�N�Z�X���邽�߂̕ϐ�
    private int         _target_Vertical = 0;
    private int         _target_Beside = 0;
    //�ϐ��̎󂯓n���Ɏg���ϐ�
    private int         _reuse_Vertical = 0;
    private int         _reuse_Beside = 0;
    //�z�񂩂�擾���Ă���bool�ϐ����i�[���邽�߂̕ϐ�
    private bool        _button_LightsSW;
    //���̃I�u�W�F�N�g���㉺���E�ǂ̒[�ɑ����邩��bool�^�Ŕ��f
    private bool        _top_End = false;
    private bool        _lower_End = false;
    private bool        _right_End = false;
    private bool        _left_End = false;
    private void Awake()
    {
        //�z�񂪃A�^�b�`����Ă�Q�[���I�u�W�F�N�g�������Ă���
        _array_Object = GameObject.Find("For_Judgment_Game_Object");
    }
    /// <summary>
    /// Image�Ń����C�N����
    /// </summary>
    public void OnPointerClick(PointerEventData pointerData)
    {
        Debug.Log(+_button_Vertical +","+ _button_Beside + " �̃^�C�����N���b�N���ꂽ!");
        Change();
        Target_Selection();
    }
    //�������ɔz��̍��W��ێ�����X�N���v�g
    public void Store_Array_Number(int Vertical,int Beside)
    {
        _button_Vertical = Vertical;
        _button_Beside = Beside;
        Set_Flag();
        Refresh();
    }
    //��������_Vertical��_Beside������̒l�̎��ɑΉ�����t���O�𗧂Ă�X�N���v�g
    private void Set_Flag()
    {
        switch (_button_Vertical)
        {
    //��ʍŉ��񎞂ɕ���
            case 0:
                {
                    _lower_End = true;
                }
                break;
    //��ʍŏ�񎞂ɕ���
            case 3:
                {
                    _top_End = true;
                }
                break;
        }

        switch (_button_Beside)
        {
    //��ʍŉE�񎞂ɕ���
            case 0:
                {
                    _left_End = true;
                }
                break;

            //��ʍō��񎞂ɕ���
            case 3:
                {
                    _right_End = true;
                }
                break;
        }
    }
    public void Refresh()
    {
    //Reuse_Vertical��Reuse_Beside�̒l������������
        _reuse_Vertical = _button_Vertical;
        _reuse_Beside = _button_Beside;
    }
    public void Change()
    {
    //���C�g�������Ă���ꍇ���C�g��_����
        if (_button_LightsSW == false)
        {
            _button_LightsSW = true;
            //�J���[��ԐF�ɐݒ肷��
            image.color = Color.red;
        }
    //���C�g���_���Ă���ꍇ���C�g������
        else if (_button_LightsSW == true)
        {
            _button_LightsSW = false;
            //�J���[��F�ɐݒ肷��
            image.color = Color.blue;
        }
    //LightsSW�̏�Ԃ�z��ɓ����
        _array_Object.GetComponent<Array>().Swich[_button_Vertical, _button_Beside] = _button_LightsSW;
    }
    public void Target_Selection()
    {
    //���Ă��t���O�ɉ����Ď��s���郁�\�b�h���ς��
        switch (_top_End, _lower_End, _right_End, _left_End)
        {
    //��ʉE��[
            case (true, false, true, false):
                {
                    Change_Left_Neighbor();
                    Change_Bottom_Neighbor();
                }
                break;
    //��ʍ���[
            case (true, false, false, true):
                {
                    Change_Right_Neighbor();
                    Change_Bottom_Neighbor();
                }
                break;
    //��ʉE���[
            case (false, true, true, false):
                {
                    Change_Left_Neighbor();
                    Change_Top_Neighbor();
                }
                break;
    //��ʍ����[
            case (false, true, false, true):
                {
                    Change_Right_Neighbor();
                    Change_Top_Neighbor();
                }
                break;
    //��ʍŏ��
            case (true, false, false, false):
                {
                    Change_Left_Neighbor();
                    Change_Right_Neighbor();
                    Change_Bottom_Neighbor();
                }
                break;
    //��ʍŉ���
            case (false, true, false, false):
                {
                    Change_Left_Neighbor();
                    Change_Right_Neighbor();
                    Change_Top_Neighbor();
                }
                break;
    //��ʍŉE��
            case (false, false, true, false):
                {
                    Change_Left_Neighbor();
                    Change_Top_Neighbor(); 
                    Change_Bottom_Neighbor();
                }
                break;
    //��ʍō���
            case (false, false, false, true):
                {
                    Change_Right_Neighbor();
                    Change_Top_Neighbor();
                    Change_Bottom_Neighbor();
                }
                break;
    //����ȊO
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
    //�E�ׂ̃{�^����I������
    private void Change_Right_Neighbor()
    {
        _target_Vertical = _reuse_Vertical;
        _reuse_Beside++;
        _target_Beside = _reuse_Beside;
        Get_Target_Button();
    }
    private void Get_Target_Button()
    {
    //�z�񂩂�Ώۂ̃{�^�������o��
        _target_Tile = _array_Object.GetComponent<Array>().Tiles[_target_Vertical,_target_Beside];
    //���o�����{�^���̏�Ԃ�؂�ւ���
        _target_Tile.GetComponent<Tile_Change>().Change();
        Refresh();
    }
}
