using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour
{
    //触发器的目标对象-玩家
    public GameObject player;

    //玩家走到胜利的位置
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
