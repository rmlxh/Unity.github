using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed=3;

    private Rigidbody2D rigidbody2d;
    //轴向控制
    public bool vertical;
    //方向控制
    private int direction = 1;
    //方向改变时间间隔，常量
    public float changeTime = 3;
    //计时器
    private float timer;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer<0)
        {
            direction = -direction;

            //PlayMoveAnimation();
            timer = changeTime;
        }

        Vector2 position = rigidbody2d.position;

        if (vertical)//垂直轴向
        {
            position.y = position.y + Time.deltaTime * speed*direction;
        }
        else//水平轴向
        {
            position.x = position.x + Time.deltaTime * speed*direction;
        }
    
        rigidbody2d.MovePosition(position); 
    }
    
    //触发检测
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.ChangeHealth(-1);
        }
    }
}
