using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //引用UI
using TMPro; //引用文本框
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody Rbd; //声明该对象Inspector面板中的刚体组件变量
    public float Speed = 3;

    Vector3 move;
    Animator anim; //动画组件
    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal"); //获取水平输入
        float z = Input.GetAxis("Vertical");

        move = new Vector3(x, 0, z); //移动幅度

        transform.LookAt(transform.position + new Vector3(x, 0, z)); //使模型始终朝运动方向
        transform.position += new Vector3(x, 0, z) * Speed * Time.deltaTime; //移动
    }

    //动画
    void UpdateAnim()
    {
        anim.SetFloat("Speed", move.magnitude); //向量，长度决定速度快慢
    }

    // Start is called before the first frame update
    void Start()
    {
        Rbd = GetComponent<Rigidbody>(); //获取该对象Inspector面板中的刚体组件变量

        anim = GetComponent<Animator>(); //获取动画组件
    }
    // Update is called once per frame
    void Update()
    {
        UpdateAnim();
        //鼠标左键点击
        if (Input.GetMouseButtonDown(0) ) //&& EventSystem.current.IsPointerOverGameObject() == false
        {
            //检测位置
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            bool isCollide = Physics.Raycast(ray, out hit);
            if (isCollide) //判断射线是否碰撞
            {
                if (hit.collider.tag == "Interactable") //判断碰撞到的物体
                {
                    hit.collider.GetComponent<InteractableObject>().OnClick(); //调用InteractableObject的OnClick
                }
            }
        }
    }
}
