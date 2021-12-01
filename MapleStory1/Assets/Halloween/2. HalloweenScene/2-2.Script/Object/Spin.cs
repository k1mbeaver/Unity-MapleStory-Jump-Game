using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float changeTime;
    [SerializeField]
    private Sprite[] spinAnimation; //  �ִϸ��̼�
    private bool vertical;

    private SpriteRenderer spinRend;
    private int frameCount = 0;
    private int spriteCount = 0;

    private Rigidbody2D spinObject;
    private float timer;
    private int direction = 1;

    // Start is called before the first frame update
    private void Start()
    {
        spinRend = GetComponent<SpriteRenderer>();
        spinObject = GetComponent<Rigidbody2D>();
        timer = changeTime;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        // ���� �ִϸ��̼�
        spinRend.sprite = spinAnimation[spriteCount];
        frameCount++;
        if (frameCount % 10 == 0)
        {
            spriteCount++;
        }

        if (frameCount == 30)
        {
            frameCount = 0;
        }

        if (spriteCount == 3)
        {
            spriteCount = 0;
        }

        // ���� ���� ��ȯ
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
        Vector2 position = spinObject.position;
        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction;
        }

        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;
        }
        spinObject.MovePosition(position);
    }
}
