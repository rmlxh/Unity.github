using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour
{
    //��������Ŀ�����-���
    public GameObject player;

    //����ߵ�ʤ����λ��
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            Jump.SwitchAndLoadScene(2);
        }
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
