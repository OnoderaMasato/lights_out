using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Array : MonoBehaviour
{   public bool[,]  Swich= new bool[5, 5];//�^�C���̏�Ԃ��i�[���邽�߂̔z��
    public Image[,] Tiles = new Image[5, 5];//�^�C�����i�[���邽�߂̔z��
    public bool LightsSW=true;//
    private int Vertical = 3;//�^�C���̏c�l�Ǘ��p�ϐ�
    private int Beside = -1;//�^�C���̉��l�Ǘ��p�ϐ�
    private int False_Count = 0;//�����Ă��郉�C�g�̐��𐔂���
    public void Judgment()//���C�g�����ׂď��������ǂ����𔻒f����
    {
        foreach(bool i in Swich)
        {
            LightsSW = Swich[Vertical, Beside];//�z�񂩂�LightsSW�����o��
            if(LightsSW==false)
            {
                False_Count++;
            }
            Debug.Log(Beside + "," + Vertical + "=" + LightsSW);//���W�̈ʒu�ƃI�u�W�F�N�g�̏�Ԃ�Debug.Log�ŏ����o��
            Debug.Log(False_Count);
        }
        if(False_Count==16)
        {
            False_Count = 0;
        }

    }
}
