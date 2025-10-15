using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseOn : MonoBehaviour
{
    public GameObject q1, q2, q3, q4, q5, q6; // 信息窗口的UI面板
    public GameObject p1, p2, p3, p4, p5, p6; //
    private void Update()
    {
        // 检测鼠标点击事件
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // 判断是否点击到了模型
                if (hit.collider.gameObject == p1)
                {
                    // 点击到了模型，显示信息窗口并设置模型名称
                    q1.SetActive(true);
                }
                if (hit.collider.gameObject == p2)
                {
                    // 点击到了模型，显示信息窗口并设置模型名称
                    q2.SetActive(true);
                }
                if (hit.collider.gameObject == p3)
                {
                    // 点击到了模型，显示信息窗口并设置模型名称
                    q3.SetActive(true);
                }
                if (hit.collider.gameObject == p4)
                {
                    // 点击到了模型，显示信息窗口并设置模型名称
                    q4.SetActive(true);
                }
                if (hit.collider.gameObject == p5)
                {
                    // 点击到了模型，显示信息窗口并设置模型名称
                    q5.SetActive(true);
                }
                if (hit.collider.gameObject == p6)
                {
                    // 点击到了模型，显示信息窗口并设置模型名称
                    q6.SetActive(true);
                }
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

}
