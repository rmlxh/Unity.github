using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YinShua : MonoBehaviour
{
    // Ԥ�������������Ҫ��Unity�༭���з�����ЩԤ����  
    public GameObject Shu;
    public GameObject Neng;

    // ��Ϊ��������ײ��tag  
    private string zhiTag = "Zhi";

    float targetHeight = 1.23f; // �߶�

    //��ǰ����Ϊ���ؽű�������
    //��ײ����Ϊ������ײ������һ������
    private void OnTriggerEnter(Collider other)//�����ײ
    {
        Debug.Log("1");
        if (other.gameObject.CompareTag(zhiTag))//����뵱ǰ��������ײ����һ�������tag
        {
            Debug.Log("2");
            // �����ײ�����tag����ʵ������Ӧ��Ԥ����  
            if (gameObject.CompareTag("Shu"))//��鵱ǰgameObject�����tag�����Ƿ�����ַ���"Shu"
            {
                // ����ײ���λ��ʵ����ShuPrefab  
                // ����ʵ����λ�ã�����y����ΪĿ��߶�  
                Vector3 position = new Vector3(transform.position.x, targetHeight, transform.position.z);
                // ������תΪƽ��  
                Quaternion rotation = Quaternion.Euler(90, 0, 0);
                Instantiate(Shu, position, rotation);
                Debug.Log("Instantiated ShuPrefab at position: " + transform.position);
                Debug.Log("3");
            }
            if (gameObject.CompareTag("Neng"))//��鵱ǰgameObject�����tag�����Ƿ�����ַ���"Neng"
            {
                // ����ײ���λ��ʵ����NengPrefab  
                Vector3 position = new Vector3(transform.position.x, targetHeight, transform.position.z);
                Quaternion rotation = Quaternion.Euler(90, 0, 0);
                Instantiate(Neng, position, rotation);
                Debug.Log("Instantiated NengPrefab at position: " + transform.position);
                Debug.Log("4");
            }
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
