using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]

public class Move : MonoBehaviour
{
    [SerializeField]
    private AudioClip JumpClip = null;
    [SerializeField]
    private float jumpForce = 0.0f;
    [SerializeField]
    private float walkForce = 0.0f;
    [SerializeField]
    private float maxWalkSpeed = 0.0f;
    [SerializeField]
    private Sprite[] standCharacter = null; // ���ִ� �ִϸ��̼�
    [SerializeField]
    private Sprite[] walkCharacter = null; // �ȴ� �ִϸ��̼�
    [SerializeField]
    private Sprite[] jumpCharacter = null; // ���� ��������Ʈ
    [SerializeField]
    private Sprite[] deathCharacter = null; // ��� ��������Ʈ
    [SerializeField]
    private int maxHealth = 0;
    [SerializeField]
    private int health { get { return currentHealth; } }

    private BoxCollider2D myPath;
    private BoxCollider2D myCatCollider;
    private AudioSource audioSource;
    private Rigidbody2D player;

    private int key = 0; // ĳ������ ���� = ���� ������ ������ 1 (������ -1)
    private bool jumpCount = false;
    private Vector3 startVector = new Vector3(-6.0f, 0.665f, -1);

    private int currentHealth;
    private bool isInvincible;
    private int InvincibleTime = 0;

    private SpriteRenderer playerRend;
    private int spriteCount = 0;
    private int frameCount = 0;
    private bool directionCharacter = true; // ĳ������ ���� = ���� ������ ������ true (������ false)

    private bool ground = true;
    private bool death = false;

    // Start is called before the first frame update
    private void Start()
    {
        player = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        audioSource = GetComponent<AudioSource>();

        playerRend = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // �׾��� ��
        
        if(death)
        {
            // ������ 
            if (directionCharacter == true)
            {
                playerRend.flipX = true;
                playerRend.sprite = deathCharacter[spriteCount];
                frameCount++;
                if (frameCount % 10 == 0)
                {
                    spriteCount++;
                }

                if (frameCount == 100)
                {
                    frameCount = 0;
                }

                if (spriteCount == 10)
                {
                    SceneManager.LoadScene("End");
                }
            }
            // ����
            else if (directionCharacter == false)
            {
                playerRend.flipX = false;
                playerRend.sprite = deathCharacter[spriteCount];
                frameCount++;
                if (frameCount % 10 == 0)
                {
                    spriteCount++;
                }

                if (frameCount == 100)
                {
                    frameCount = 0;
                }

                if (spriteCount == 10)
                {
                    SceneManager.LoadScene("End");
                }
            }
            //transform.position = startVector;
            //death = false;
        }
        else
        {
            // �¿� �̵� ( FixedUpdate�� )
            key = 0;
            if (Input.GetKey(KeyCode.RightArrow))
            {
                key = 1;
                directionCharacter = true;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                key = -1;
                directionCharacter = false;
            }

            // �ִϸ��̼� �κ�

            // ������ ������ ��
            if (ground == true && Input.GetAxis("Horizontal") == 0)
            {
                // ������ 
                if (directionCharacter == true)
                {
                    playerRend.flipX = true;
                    playerRend.sprite = standCharacter[spriteCount];
                    frameCount++;
                    if (frameCount % 10 == 0)
                    {
                        spriteCount++;
                    }

                    if (frameCount == 60)
                    {
                        frameCount = 0;
                    }

                    if (spriteCount == 6)
                    {
                        spriteCount = 0;
                    }
                }
                // ����
                else if (directionCharacter == false)
                {
                    playerRend.flipX = false;
                    playerRend.sprite = standCharacter[spriteCount];
                    frameCount++;
                    if (frameCount % 10 == 0)
                    {
                        spriteCount++;
                    }

                    if (frameCount == 60)
                    {
                        frameCount = 0;
                    }

                    if (spriteCount == 6)
                    {
                        spriteCount = 0;
                    }
                }
            }

            // �������� �ɾ� �� ��
            else if (ground == true && Input.GetAxis("Horizontal") < 0)
            {
                playerRend.flipX = false;
                playerRend.sprite = walkCharacter[spriteCount];
                frameCount++;
                if (frameCount % 10 == 0)
                {
                    spriteCount++;
                }

                if (frameCount == 60)
                {
                    frameCount = 0;
                }

                if (spriteCount == 6)
                {
                    spriteCount = 0;
                }
            }

            // ���������� �ɾ� �� ��
            else if (ground == true && Input.GetAxis("Horizontal") > 0)
            {
                playerRend.flipX = true;
                playerRend.sprite = walkCharacter[spriteCount];
                frameCount++;
                if (frameCount % 10 == 0)
                {
                    spriteCount++;
                }

                if (frameCount == 60)
                {
                    frameCount = 0;
                }

                if (spriteCount == 6)
                {
                    spriteCount = 0;
                }
            }
            // ���� �� ���� ���� �� ��
            else if (ground == false)
            {
                // ������ 
                if (directionCharacter == true)
                {
                    playerRend.flipX = true;
                    playerRend.sprite = jumpCharacter[0];
                }
                // ����
                else if (directionCharacter == false)
                {
                    playerRend.flipX = false;
                    playerRend.sprite = jumpCharacter[0];
                }
            }

            // ���� �� �̲�������
            if (Input.GetAxis("Horizontal") == 0)
            {
                player.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            }
            else
            {
                player.constraints = RigidbodyConstraints2D.FreezeRotation;
            }

            // ĳ���Ͱ� ȭ�� ���� �ȳ�����
            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

            if (pos.x < 0f)
            {
                pos.x = 0f;
            }

            if (pos.x > 1f)
            {
                pos.x = 1f;
            }

            if (pos.y < 0f)
            {
                pos.y = 0f;
            }

            transform.position = Camera.main.ViewportToWorldPoint(pos);

            // ĳ���Ͱ� ȭ�� �Ʒ��� �������� �� �ʱ� ��ġ�� ���ġ
            if (transform.position.y < 0.0f)
            {
                transform.position = startVector;
            }

            // ����
            if (Input.GetKeyDown(KeyCode.LeftAlt))
            {
                if (ground == true)
                {
                    jumpCount = true;
                    PlaySound(JumpClip);
                }
            }

            // ĳ���Ͱ� npc�� ������ ��
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Vector2 lookDirection = new Vector2(key, 0);
                RaycastHit2D hit = Physics2D.Raycast(player.position + Vector2.right * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("Npc"));

                if (hit.collider != null)
                {
                    NpcController npc = hit.collider.GetComponent<NpcController>();
                    if (npc != null)
                    {
                        npc.DisplayDialog();
                    }
                }
            }
            // ĳ���Ͱ� ��Ż ������ �� ����Ű�� ������ ��
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Vector2 lookDirection = new Vector2(key, 1);
                RaycastHit2D hit = Physics2D.Raycast(player.position + Vector2.down * 1.0f, lookDirection, 1.5f, LayerMask.GetMask("Portal"));

                if (hit.collider != null)
                {
                    startPortal myStart = hit.collider.GetComponent<startPortal>();
                    endPortal myEnd = hit.collider.GetComponent<endPortal>();
                    if (myStart != null)
                    {
                        myStart.DisplayDialog();
                    }
                    else if (myEnd != null)
                    {
                        myEnd.DisplayDialog();
                    }
                }
            }
        }   
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(death == false)
        {
            // �������� �޾��� �� ���� �ð�
            if (isInvincible)
            {
                if(InvincibleTime % 30 == 0)
                {
                    playerRend.color = new Color32(255, 255, 255, 90);
                }

                else
                {
                    playerRend.color = new Color32(255, 255, 255, 180);
                }

                InvincibleTime++;
                if (InvincibleTime == 300)
                {
                    isInvincible = false;
                    InvincibleTime = 0;
                    playerRend.color = new Color32(255, 255, 255, 255);
                    return;
                }
            }

            // ����
            if (jumpCount)
            {
                player.AddForce(transform.up * jumpForce);
                jumpCount = false;
                //ground = false;
            }

            // ĳ���� �̵�
            
            float speedx = Mathf.Abs(player.velocity.x);

            if (speedx < maxWalkSpeed)
            {
                player.AddForce(transform.right * key * walkForce);
            }
            
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.layer == 6)
        {
            ground = true;
        }
    }

    private void OnCollisionExit2D(Collision2D coll)
    {
        if (player.velocity.y != 0) // �������� �����̴� ������ ���� ���� ���� ���̸�
        {
            ground = false;
        }
    }

    // ���� �꿴�� ��
    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.layer == 6)
        {
            GetComponent<BoxCollider2D>().isTrigger = true;
        }

        if (obj.gameObject.layer == 11 && isInvincible == false)
        {
            ChangeHealth(-1);
        }
    }

    private void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.gameObject.layer == 6)
        {
            GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }
    // ĳ���� ü�� ��ȭ
    private void ChangeHealth(int amount)
    {
        if(amount < 0)
        {
            if (isInvincible)
                return;

            isInvincible = true;
            InvincibleTime = 0;
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        if (currentHealth == 0)
        {
            death = true;
        }
        CatHealthBar.instance.SetValue(currentHealth / (float)maxHealth);
    }

    // �����Ҹ�
    private void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
