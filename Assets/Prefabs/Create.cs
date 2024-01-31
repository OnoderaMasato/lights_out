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
    private int Rnd =0;//�����������̊i�[��
    private int Vertical = 3;//�^�C���̏c�l�Ǘ��p�ϐ�
    private int Beside = 0;//�^�C���̉��l�Ǘ��p�ϐ�
    private int VerticalMin = 0;//�c���̍ŏ��l(�ԕ�)
    private int BesideMax = 4;//�����̍ő�l(�ԕ�)
    private void Start()
    {
        Array_Object = GameObject.Find("For_Judgment_Game_Object");//�z�񂪃A�^�b�`����Ă�Q�[���I�u�W�F�N�g�������Ă���
    }
    private void Update()
    {
        if (Vertical>=VerticalMin)
        {
            Coordinate = new Vector3((Vertical * 200)-300,(Beside * 200)-300, 0);//���S�ɐ��������悤�ɐ����ʒu�𒲐�

            if (Beside <= BesideMax)
            {
                Image _Tile = Instantiate(Tile, Coordinate, Quaternion.identity);//�^�C���𐶐�����
                Array_Object.GetComponent<Array>().Tiles[Vertical, Beside]=_Tile;//�^�C�����w�肵���z��̍��W�ɓ���Ă���
                _Tile = _Tile.GetComponent<Tile_Change>().image;//���������^�C���ɃA�^�b�`���Ă���X�N���v�g�̃I�u�W�F�N�g���g�����Ă���
                _Tile.GetComponent<Tile_Change>().Store_Array_Number(Beside, Vertical);//���������^�C���ɔz��̍��W������

                Rnd = Random.Range(0, 2);
                switch (Rnd)
                {
                    case 0:
                        LightsSW = true;
                        _Tile.GetComponent<Tile_Change>().Change();//�^�C���̏�Ԃ��u�I���v�ɐݒ肷��
                        _Tile.color = Color.red;//�J���[��ԐF�ɐݒ肷��
                        Array_Object.GetComponent<Array>().Swich[Vertical, Beside] = LightsSW;//LightsSW�̏�Ԃ�z��ɓ����
                        break;
                    
                    case 1:
                        LightsSW = false;//�^�C���̏�Ԃ��u�I�t�v�ɐݒ肷��
                        _Tile.GetComponent<Tile_Change>().Change();

                        _Tile.color = Color.blue;//�J���[��F�ɐݒ肷��
                        Array_Object.GetComponent<Array>().Swich[Vertical, Beside] = LightsSW;//LightsSW�̏�Ԃ�z��ɓ����
                        break;
                }
                _Tile.transform.SetParent(parent.transform, false);
                Beside++;
            }
            if(Beside==BesideMax)
            {
                Vertical--;
                Beside = 0;//�ϐ�Beside��0�ŏ�����
            }

        }
    }
}