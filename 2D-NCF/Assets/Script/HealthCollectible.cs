using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public AudioClip audioClip;

    //public GameObject effectParticle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("与我们发生碰撞的对象是："+collision);
        PlayerController playerController = collision.GetComponent<PlayerController>();
        //当前发生触发检测的游戏物体对象身上有否有PlayerController脚本
        if (playerController != null)
        {
            //有PlayerController脚本
            //Player是否满血
            if (playerController.Health< playerController.maxHealth)
            {
                //Player是不满血状态
                playerController.ChangeHealth(1);
                //playerController.PlaySound(audioClip);
                //Instantiate(effectParticle,transform.position,Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
