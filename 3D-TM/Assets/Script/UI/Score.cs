using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;//引用UI库

public class Score : MonoBehaviour
{
    int a = 0, b = 0, c = 0, d = 0, e = 0, f = 0, g = 0;  //a分数 b,c,d,e,f,g判断是否只执行一次

    [SerializeField]
    TMP_Text textscore;//分数文本框
    public GameObject ques1, ques2, ques3, ques4, ques5, ques6;
    public GameObject door1, door2, door3, door4, door5, door6;

    //1
    public void ques1up()
    {
        ques1.SetActive(true);
    }
    public void ques1down()
    {
        ques1.SetActive(false);
    }
    //2
    public void ques2up()
    {
        ques2.SetActive(true);
    }
    public void ques2down()
    {
        ques2.SetActive(false);
    }
    //3
    public void ques3up()
    {
        ques3.SetActive(true);
    }
    public void ques3down()
    {
        ques3.SetActive(false);
    }
    //4
    public void ques4up()
    {
        ques4.SetActive(true);
    }
    public void ques4down()
    {
        ques4.SetActive(false);
    }
    //5
    public void ques5up()
    {
        ques5.SetActive(true);
    }
    public void ques5down()
    {
        ques5.SetActive(false);
    }
    //6
    public void ques6up()
    {
        ques6.SetActive(true);
    }
    public void ques6down()
    {
        ques6.SetActive(false);
    }

    //1
    public void Question1()
    {
        if (b < 1)
        {
            a = a + 1;
            b = b + 1;
            ques1down();
        }
        if (a == 1)
        {
            door1.SetActive(false);
        }
    }
    //2
    public void Question2()
    {
        if (c < 1)
        {
            a = a + 1;
            c = c + 1;
            ques2down();
        }
        if (a == 2)
        {
            door2.SetActive(false);
        }
    }
    //3
    public void Question3()
    {
        if (d < 1)
        {
            a = a + 1;
            d = d + 1;
            ques3down();
        }
        if (a == 3)
        {
            door3.SetActive(false);
        }
    }
    //4
    public void Question4()
    {
        if (e < 1)
        {
            a = a + 1;
            e = e + 1;
            ques4down();
        }
        if (a == 4)
        {
            door4.SetActive(false);
        }
    }
    public void Question5()
    {
        if (f < 1)
        {
            a = a + 1;
            f = f + 1;
            ques5down();
        }
        if (a == 5)
        {
            door5.SetActive(false);
        }
    }
    //5
    public void Question6()
    {
        if (g < 1)
        {
            a = a + 1;
            g = g + 1;
            ques6down();
        }
        if (a == 6)
        {
            door6.SetActive(false);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textscore.text = (" "+a+" ");
    }
}
