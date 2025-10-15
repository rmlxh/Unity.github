using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialog : MonoBehaviour
{
    public GameObject dialogBox;
    public float displayTime = 4.0f;  //对话框关闭时间
    private float timerDisplay;  //记录对话框是否达到关闭时间
    public Text dialogText;

    //public AudioClip completeTaskclip;

    // Start is called before the first frame update
    void Start()
    {
        dialogBox.SetActive(false);
        timerDisplay = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerDisplay>=0)
        {
            timerDisplay -= Time.deltaTime;  //计时器开始计时
            if (timerDisplay<0)
            {
                dialogBox.SetActive(false);
            }
        }
    }

    public void DisplayDialog()
    {
        timerDisplay = displayTime;
        dialogBox.SetActive(true);
        UIHealthBar.instance.hasTask = true;
        //if (UIHealthBar.instance.Num>=9)
        //{
            //已经完成任务，需要修改对话框内容
            //dialogText.text = "你已经成功通过了我的考验，去找下一个人吧，加油！";    
        //}
    }
}
