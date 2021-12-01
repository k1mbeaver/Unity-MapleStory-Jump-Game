using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    public float changeTime;
    private bool vertical;

    private SpriteRenderer monsterRend;
    [SerializeField]
    private Sprite[] monsterAnimation; //  애니메이션
    private int frameCount = 0;
    private int spriteCount = 0;

    private Rigidbody2D monster;
    private float timer;
    private int direction = 1;

    // Start is called before the first frame update
    private void Start()
    {
        monster = GetComponent<Rigidbody2D>();
        monsterRend = GetComponent<SpriteRenderer>();
        timer = changeTime;
    }

    private void Update()
    {
        // 애니메이션
        // 오른쪽 
        if (direction == 1)
        {
            monsterRend.flipX = true;
            monsterRend.sprite = monsterAnimation[spriteCount];
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
        // 왼쪽
        else if (direction == -1)
        {
            monsterRend.flipX = false;
            monsterRend.sprite = monsterAnimation[spriteCount];
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

    // Update is called once per frame
    private void FixedUpdate()
    {
        timer -= Time.deltaTime;

        if(timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
        Vector2 position = monster.position;
        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction;
        }

        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;
        }
        monster.MovePosition(position);
    }
}
