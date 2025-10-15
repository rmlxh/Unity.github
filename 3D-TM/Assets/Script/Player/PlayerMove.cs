using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //����UI
using TMPro; //�����ı���
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody Rbd; //�����ö���Inspector����еĸ����������
    public float Speed = 3;

    Vector3 move;
    Animator anim; //�������
    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal"); //��ȡˮƽ����
        float z = Input.GetAxis("Vertical");

        move = new Vector3(x, 0, z); //�ƶ�����

        transform.LookAt(transform.position + new Vector3(x, 0, z)); //ʹģ��ʼ�ճ��˶�����
        transform.position += new Vector3(x, 0, z) * Speed * Time.deltaTime; //�ƶ�
    }

    //����
    void UpdateAnim()
    {
        anim.SetFloat("Speed", move.magnitude); //���������Ⱦ����ٶȿ���
    }

    // Start is called before the first frame update
    void Start()
    {
        Rbd = GetComponent<Rigidbody>(); //��ȡ�ö���Inspector����еĸ����������

        anim = GetComponent<Animator>(); //��ȡ�������
    }
    // Update is called once per frame
    void Update()
    {
        UpdateAnim();
        //���������
        if (Input.GetMouseButtonDown(0) ) //&& EventSystem.current.IsPointerOverGameObject() == false
        {
            //���λ��
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            bool isCollide = Physics.Raycast(ray, out hit);
            if (isCollide) //�ж������Ƿ���ײ
            {
                if (hit.collider.tag == "Interactable") //�ж���ײ��������
                {
                    hit.collider.GetComponent<InteractableObject>().OnClick(); //����InteractableObject��OnClick
                }
            }
        }
    }
}
