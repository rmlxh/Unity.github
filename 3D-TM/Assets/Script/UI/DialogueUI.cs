using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    //public static DialogueUI Instance { get; private set; } //����ģʽ

    public TextMeshProUGUI nameText; //дUI�ϵ�����
    public TextMeshProUGUI contentText; //д�Ի�������
    public Button continueButton; //������ť

    private List<string> contentList; //�����ŶԻ�
    private int contentIndex = 0; //��ǰ���ŵ��ǵڼ���

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

    public void Show() //��ʾUI
    {
        uiGameObject.SetActive(true);
    }

    public void Show(string name,string[] content,Action OnDiagoueEnd=null) //�������֡��Ի�����
    {
        nameText.text = name; //����
        contentList = new List<string>(); //��������
        contentList.AddRange(content); //����һ������
        contentIndex = 0; //��contentIndex����
        contentText.text = contentList[0]; //���ŵ�һ�仰
        uiGameObject.SetActive(true);
        this.OnDialogueEnd = OnDiagoueEnd;
    }
     
    public void Hide() //����UI
    {
        uiGameObject.SetActive(false);
    }
    private void OnContinueButtonClick()
    {
        contentIndex++; //+1
        if (contentIndex >= contentList.Count)
        {
            OnDialogueEnd?.Invoke(); // ���ûص�����
            Hide();
            return;
        }
    contentText.text = contentList[contentIndex]; //չʾ��һ��
    }
}
