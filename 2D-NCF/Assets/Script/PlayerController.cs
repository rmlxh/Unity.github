using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;
    public float speed = 3;  //Player的速度

    //Player生命值
    public int maxHealth = 5;//最大生命值
    private int currentHealth = 3;//Player的当前生命值
    public int Health { get { return currentHealth; } }

    //Player的无敌时间
    public float timeInvincible = 1.0f;//无敌时间常量
    public bool isInvincible;
    public float invincibleTimer;//计时器
    
    private Vector2 lookDirection = new Vector2(0, -1);  //面向玩家
    private Animator animator;

    //显示血量的文本框
    public TMP_Text TextLife;

    //public GameObject projectilePrefab;

    public AudioSource audioSource;
    public AudioSource walkAudioSource;

    public AudioClip walkSound;

    // Start is called before the first frame update
    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentHealth = 3;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        //respawnPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //玩家输入监听
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);  //朝向的值
        
        //当前玩家输入的某个轴向值不为0
        if (!Mathf.Approximately(move.x, 0) || !Mathf.Approximately(move.y, 0))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
            if (!walkAudioSource.isPlaying)
            {
                walkAudioSource.clip = walkSound;
                walkAudioSource.Play();
            }
        }
        else
        {
            walkAudioSource.Stop();
        }

        //动画的控制
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        //移动
        Vector2 position = transform.position;  //位置对象

        //Player位置的移动
        position = position + speed * move * Time.deltaTime;
        rigidbody2d.MovePosition(position);  //传递目标位置

        //无敌时间计算
        if (isInvincible)
        {
            invincibleTimer = invincibleTimer - Time.deltaTime;
            if (invincibleTimer <= 0)
            {
                isInvincible = false;
            }
        }

        //检测是否与NPC对话
        if (Input.GetKeyDown(KeyCode.T))  //T对话
        {
            RaycastHit2D hit1 = Physics2D.Raycast(rigidbody2d.position +
                Vector2.up * 0.6f, lookDirection, 1.8f, LayerMask.GetMask("NPC"));
            if (hit1.collider != null)
            {
                //UnityEngine.Debug.Log("当前射线检测碰撞到的游戏物体是：" + hit.collider.gameObject);
                NPCDialog npcDialog = hit1.collider.GetComponent<NPCDialog>();
                if (npcDialog != null)
                {
                    npcDialog.DisplayDialog();
                }
            }
        }

        //检测是否与B交互
        if (Input.GetKeyDown(KeyCode.Q))  //Q答题
        {
            RaycastHit2D hit2 = Physics2D.Raycast(rigidbody2d.position +
                Vector2.up * 0.6f, lookDirection, 1.8f, LayerMask.GetMask("B"));
            if (hit2.collider != null)
            {
                //UnityEngine.Debug.Log("当前射线检测碰撞到的游戏物体是：" + hit.collider.gameObject);
                QuestionDialog questionDialog = hit2.collider.GetComponent<QuestionDialog>();
                if (questionDialog != null)
                {
                    questionDialog.PlayDialog();
                }
            }
        }

        //按Esc键退出游戏
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Jump.EndApp();
        }
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
            {
                return;
            }
            //收到伤害
            isInvincible = true;
            invincibleTimer = timeInvincible;  //无敌时间最大值
            //animator.SetTrigger("Hit");
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);  //当前生命，最低生命，最高生命
        TextLife.text = "X " + currentHealth.ToString();

        //输的条件
        if (currentHealth <= 0)
        {
            Jump.SwitchAndLoadScene(3);
        }
    }

    public void PlaySound(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }
}