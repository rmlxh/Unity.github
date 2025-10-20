using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YinShua : MonoBehaviour
{
    // 预制体变量，您需要在Unity编辑器中分配这些预制体  
    public GameObject Shu;
    public GameObject Neng;

    // 作为触发器碰撞的tag  
    private string zhiTag = "Zhi";

    float targetHeight = 1.23f; // 高度

    //当前对象为挂载脚本的物体
    //碰撞对象为发生碰撞的另外一个物体
    private void OnTriggerEnter(Collider other)//检测碰撞
    {
        Debug.Log("1");
        if (other.gameObject.CompareTag(zhiTag))//检查与当前对象发生碰撞的另一个对象的tag
        {
            Debug.Log("2");
            // 检查碰撞物体的tag，并实例化对应的预制体  
            if (gameObject.CompareTag("Shu"))//检查当前gameObject对象的tag属性是否等于字符串"Shu"
            {
                // 在碰撞点的位置实例化ShuPrefab  
                // 设置实例化位置，其中y分量为目标高度  
                Vector3 position = new Vector3(transform.position.x, targetHeight, transform.position.z);
                // 设置旋转为平躺  
                Quaternion rotation = Quaternion.Euler(90, 0, 0);
                Instantiate(Shu, position, rotation);
                Debug.Log("Instantiated ShuPrefab at position: " + transform.position);
                Debug.Log("3");
            }
            if (gameObject.CompareTag("Neng"))//检查当前gameObject对象的tag属性是否等于字符串"Neng"
            {
                // 在碰撞点的位置实例化NengPrefab  
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
