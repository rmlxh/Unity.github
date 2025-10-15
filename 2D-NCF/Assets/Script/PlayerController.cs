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
    public float speed = 3;  //Player���ٶ�

    //Player����ֵ
    public int maxHealth = 5;//�������ֵ
    private int currentHealth = 3;//Player�ĵ�ǰ����ֵ
    public int Health { get { return currentHealth; } }

    //Player���޵�ʱ��
    public float timeInvincible = 1.0f;//�޵�ʱ�䳣��
    public bool isInvincible;
    public float invincibleTimer;//��ʱ��
    
    private Vector2 lookDirection = new Vector2(0, -1);  //�������
    private Animator animator;

    //��ʾѪ�����ı���
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
        //����������
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);  //�����ֵ
        
        //��ǰ��������ĳ������ֵ��Ϊ0
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

        //�����Ŀ���
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        //�ƶ�
        Vector2 position = transform.position;  //λ�ö���

        //Playerλ�õ��ƶ�
        position = position + speed * move * Time.deltaTime;
        rigidbody2d.MovePosition(position);  //����Ŀ��λ��

        //�޵�ʱ�����
        if (isInvincible)
        {
            invincibleTimer = invincibleTimer - Time.deltaTime;
            if (invincibleTimer <= 0)
            {
                isInvincible = false;
            }
        }

        //����Ƿ���NPC�Ի�
        if (Input.GetKeyDown(KeyCode.T))  //T�Ի�
        {
            RaycastHit2D hit1 = Physics2D.Raycast(rigidbody2d.position +
                Vector2.up * 0.6f, lookDirection, 1.8f, LayerMask.GetMask("NPC"));
            if (hit1.collider != null)
            {
                //UnityEngine.Debug.Log("��ǰ���߼����ײ������Ϸ�����ǣ�" + hit.collider.gameObject);
                NPCDialog npcDialog = hit1.collider.GetComponent<NPCDialog>();
                if (npcDialog != null)
                {
                    npcDialog.DisplayDialog();
                }
            }
        }

        //����Ƿ���B����
        if (Input.GetKeyDown(KeyCode.Q))  //Q����
        {
            RaycastHit2D hit2 = Physics2D.Raycast(rigidbody2d.position +
                Vector2.up * 0.6f, lookDirection, 1.8f, LayerMask.GetMask("B"));
            if (hit2.collider != null)
            {
                //UnityEngine.Debug.Log("��ǰ���߼����ײ������Ϸ�����ǣ�" + hit.collider.gameObject);
                QuestionDialog questionDialog = hit2.collider.GetComponent<QuestionDialog>();
                if (questionDialog != null)
                {
                    questionDialog.PlayDialog();
                }
            }
        }

        //��Esc���˳���Ϸ
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
            //�յ��˺�
            isInvincible = true;
            invincibleTimer = timeInvincible;  //�޵�ʱ�����ֵ
            //animator.SetTrigger("Hit");
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);  //��ǰ����������������������
        TextLife.text = "X " + currentHealth.ToString();

        //�������
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