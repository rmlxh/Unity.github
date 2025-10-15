using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    //public static DialogueUI Instance { get; private set; } //单例模式

    public TextMeshProUGUI nameText; //写UI上的名字
    public TextMeshProUGUI contentText; //写对话的内容
    public Button continueButton; //继续按钮

    private List<string> contentList; //数组存放对话
    private int contentIndex = 0; //当前播放的是第几条

    public GameObject uiGameObject; //UI

    private Action OnDialogueEnd;
    /*
    private void Awake()
    {
        if(Instance!=null && Instance!=this)
        {
            Destroy(this.gameObject);return;
        }

        Instance = this;
    }
   */

    private void Start()
    {
        continueButton.onClick.AddListener(this.OnContinueButtonClick);
        Hide();
    }

    public void Show() //显示UI
    {
        uiGameObject.SetActive(true);
    }

    public void Show(string name,string[] content,Action OnDiagoueEnd=null) //传递名字、对话内容
    {
        nameText.text = name; //名字
        contentList = new List<string>(); //构造数组
        contentList.AddRange(content); //存入一组数组
        contentIndex = 0; //将contentIndex归零
        contentText.text = contentList[0]; //播放第一句话
        uiGameObject.SetActive(true);
        this.OnDialogueEnd = OnDiagoueEnd;
    }
     
    public void Hide() //隐藏UI
    {
        uiGameObject.SetActive(false);
    }
    private void OnContinueButtonClick()
    {
        contentIndex++; //+1
        if (contentIndex >= contentList.Count)
        {
            OnDialogueEnd?.Invoke(); // 调用回调函数
            Hide();
            return;
        }
    contentText.text = contentList[contentIndex]; //展示下一条
    }
}
