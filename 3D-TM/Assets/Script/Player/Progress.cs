using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Progress : MonoBehaviour
{
    public static int Score = 0;  //���ó�ʼ�÷�
    //�����꣬�ǵù��������
    [SerializeField]
    TMP_Text score;  //�÷�

    public GameObject quest1,quest2,quest3,quest4,quest5,quest6;
    public void PopsUp1() //������ʾ��
    {
        quest1.SetActive(true);
    }
    public void PopsQuit1() //�ر���ʾ��
    {
        quest1.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        score.text = GameResultScore();//���ı�����ʾ��� ����������GameResultScore()
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private string GameResultScore()
    {
        return "Score";
    }

}
