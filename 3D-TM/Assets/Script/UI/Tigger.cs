using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tigger : MonoBehaviour
{
    public GameObject prompt;

    public void Show(GameObject prompt)
    {
        //������ĳ�����弤����ǽ��ã�������prompt��Ҳ�����Ǹ�ͼ��
        //����ʱ���������������嶼����ã���������Ľű���������ܷ���
        prompt.SetActive(true);
    }
    public void Hide(GameObject prompt)
    {
        prompt.SetActive(false);
    }
    void OnTriggerEnter(Collider other)//�Ӵ�ʱ�������������
    {
        //Debug.Log(Time.time + ":����ô������Ķ����ǣ�" + other.gameObject.name);
        //Debug.Log(Time.time);
        Show(prompt);
    }
    void OnTriggerStay(Collider other)    //ÿ֡����һ��OnTriggerStay()����
    {
        //Debug.Log(Time.time + "���ڴ������Ķ����ǣ�" + other.gameObject.name);
        //Debug.Log(Time.time);
    }
    void OnTriggerExit(Collider other)
    {
        //Debug.Log(Time.time + "�뿪�������Ķ����ǣ�" + other.gameObject.name);
        //Debug.Log(Time.time);
        Hide(prompt);
    }

    // Start is called before the first frame update
    void Start()
    {
        Hide(prompt);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

