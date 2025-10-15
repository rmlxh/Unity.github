﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    public Image mask;
    private float originalSize;

    public static UIHealthBar instance { get; private set; }

    public bool hasTask;  //当前是否有任务

    //public bool ifCompleteTask;
    public int Num;  //数量

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        originalSize = mask.rectTransform.rect.width;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
