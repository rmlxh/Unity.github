using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Unity.VisualScripting;
public class StartScene : MonoBehaviour
{

    public GameObject prompt; //��Ϸ˵��
    public void LoadGame()
    {
        Jump.SwitchAndLoadScene(1);
    }
    public void ExitGame()
    {
        Jump.EndApp();
    }

    public void PopsUp() //������ʾ��
    {
        prompt.SetActive(true);
    }
    public void PopsQuit() //�ر���ʾ��
    {
        prompt.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
