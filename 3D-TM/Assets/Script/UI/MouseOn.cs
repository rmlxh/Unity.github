using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseOn : MonoBehaviour
{
    public GameObject q1, q2, q3, q4, q5, q6; // ��Ϣ���ڵ�UI���
    public GameObject p1, p2, p3, p4, p5, p6; //
    private void Update()
    {
        // ���������¼�
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // �ж��Ƿ�������ģ��
                if (hit.collider.gameObject == p1)
                {
                    // �������ģ�ͣ���ʾ��Ϣ���ڲ�����ģ������
                    q1.SetActive(true);
                }
                if (hit.collider.gameObject == p2)
                {
                    // �������ģ�ͣ���ʾ��Ϣ���ڲ�����ģ������
                    q2.SetActive(true);
                }
                if (hit.collider.gameObject == p3)
                {
                    // �������ģ�ͣ���ʾ��Ϣ���ڲ�����ģ������
                    q3.SetActive(true);
                }
                if (hit.collider.gameObject == p4)
                {
                    // �������ģ�ͣ���ʾ��Ϣ���ڲ�����ģ������
                    q4.SetActive(true);
                }
                if (hit.collider.gameObject == p5)
                {
                    // �������ģ�ͣ���ʾ��Ϣ���ڲ�����ģ������
                    q5.SetActive(true);
                }
                if (hit.collider.gameObject == p6)
                {
                    // �������ģ�ͣ���ʾ��Ϣ���ڲ�����ģ������
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
