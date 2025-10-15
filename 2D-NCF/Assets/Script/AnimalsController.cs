using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalsController : MonoBehaviour
{
    public float speed = 3;

    private Rigidbody2D rigidbody2d;
    //�������
    public bool vertical;
    //�������
    private int direction = 1;
    //����ı�ʱ����������
    public float changeTime = 3;
    //��ʱ��
    private float timer;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();

        PlayMoveAnimation();

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;

            PlayMoveAnimation();
            timer = changeTime;
        }

        Vector2 position = rigidbody2d.position;

        if (vertical)//��ֱ����
        {
            position.y = position.y + Time.deltaTime * speed * direction;
        }
        else//ˮƽ����
        {
            position.x = position.x + Time.deltaTime * speed * direction;
        }

        rigidbody2d.MovePosition(position);
    }
    
    //�����ƶ������ķ���
    private void PlayMoveAnimation()
    {
        if (vertical)//��ֱ���򶯻��Ŀ���
        {
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", direction);
        }
        else//ˮƽ���򶯻��Ŀ���
        {
            animator.SetFloat("MoveX", direction);
            animator.SetFloat("MoveY", 0);
        }
    }
    
}
