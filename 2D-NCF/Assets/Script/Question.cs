using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Question : MonoBehaviour
{
    int a = 0;
    PlayerController player = new PlayerController();

    [SerializeField]
    public TMP_Text Textscore;//分数文本框
    public GameObject ques1, ques2, ques3, ques4, ques5, ques6, ques7, ques8, ques9;  //弹窗
    public GameObject b1, b2, b3, b4, b5, b6, b7, b8, b9;  //被销毁的物体


    //1
    public void ques1up()
    {
        ques1.SetActive(true);
    }
    public void ques1down()
    {
        ques1.SetActive(false);
        player.ChangeHealth(-1);
    }
    //2
    public void ques2up()
    {
        ques2.SetActive(true);
    }
    public void ques2down()
    {
        ques2.SetActive(false);
        player.ChangeHealth(-1);
    }
    //3
    public void ques3up()
    {
        ques3.SetActive(true);
    }
    public void ques3down()
    {
        ques3.SetActive(false);
        player.ChangeHealth(-1);
    }
    //4
    public void ques4up()
    {
        ques4.SetActive(true);
    }
    public void ques4down()
    {
        ques4.SetActive(false);
        player.ChangeHealth(-1);
    }
    //5
    public void ques5up()
    {
        ques5.SetActive(true);
    }
    public void ques5down()
    {
        ques5.SetActive(false);
        player.ChangeHealth(-1);
    }
    //6
    public void ques6up()
    {
        ques6.SetActive(true);
    }
    public void ques6down()
    {
        ques6.SetActive(false);
        player.ChangeHealth(-1);
    }
    //7
    public void ques7up()
    {
        ques7.SetActive(true);
    }
    public void ques7down()
    {
        ques7.SetActive(false);
        player.ChangeHealth(-1);
    }
    //8
    public void ques8up()
    {
        ques8.SetActive(true);
    }
    public void ques8down()
    {
        ques8.SetActive(false);
        player.ChangeHealth(-1);
    }
    //9
    public void ques9up()
    {
        ques9.SetActive(true);
    }
    public void ques9down()
    {
        ques9.SetActive(false);
        player.ChangeHealth(-1);
    }

    //1
    public void Question1()
    {
        a = a + 1;
        Destroy(b1);
        ques1.SetActive(false);
    }
    //2
    public void Question2()
    {
        a = a + 1;
        Destroy(b2);
        ques2.SetActive(false);
    }
    //3
    public void Question3()
    {
        a = a + 1;
        Destroy(b3);
        ques3.SetActive(false);
    }
    //4
    public void Question4()
    {
        a = a + 1;
        Destroy(b4);
        ques4.SetActive(false);
    }
    //5
    public void Question5()
    {
        a = a + 1;
        Destroy(b5);
        ques5.SetActive(false);
    }
    //6
    public void Question6()
    {
        a = a + 1;
        Destroy(b6);
        ques6.SetActive(false);
    }
    //7
    public void Question7()
    {
        a = a + 1;
        Destroy(b7);
        ques7.SetActive(false);
    }
    //8
    public void Question8()
    {
        a = a + 1;
        Destroy(b8);
        ques8.SetActive(false);
    }
    //9
    public void Question9()
    {
        a = a + 1;
        Destroy(b9);
        ques9.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Textscore.text = a.ToString();
        //UIHealthBar.instance.Num = a;
        if (a >= 9)
        {
            Jump.SwitchAndLoadScene(2);
        }
    }
}
