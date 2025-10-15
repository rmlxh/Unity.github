using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Progress : MonoBehaviour
{
    public static int Score = 0;  //设置初始得分
    //定义完，记得挂组件对象
    [SerializeField]
    TMP_Text score;  //得分

    public GameObject quest1,quest2,quest3,quest4,quest5,quest6;
    public void PopsUp1() //弹出显示框
    {
        quest1.SetActive(true);
    }
    public void PopsQuit1() //关闭显示框
    {
        quest1.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        score.text = GameResultScore();//在文本内显示结果 ；结果需调用GameResultScore()
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
