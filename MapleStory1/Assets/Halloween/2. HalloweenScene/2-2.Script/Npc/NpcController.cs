using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    [SerializeField]
    private Sprite[] npcAnimation; //  애니메이션
    [SerializeField]
    private GameObject dialogBox;
    [SerializeField]
    private float displayTime = 5.0f;

    private SpriteRenderer npcRend;
    private int frameCount = 0;
    private int spriteCount = 0;
    private float timerDisplay;

    // Start is called before the first frame update
    private void Start()
    {
        npcRend = GetComponent<SpriteRenderer>();
        dialogBox.SetActive(false);
        timerDisplay = -1.0f;
    }

    // Update is called once per frame
    private void Update()
    {
        npcRend.sprite = npcAnimation[spriteCount];
        frameCount++;
        if (frameCount % 10 == 0)
        {
            spriteCount++;
        }

        if (frameCount == 90)
        {
            frameCount = 0;
        }

        if (spriteCount == 9)
        {
            spriteCount = 0;
        }

        if (timerDisplay >= 0)
        {
            timerDisplay -= Time.deltaTime;
            if (timerDisplay < 0)
            {
                dialogBox.SetActive(false);
            }
        }
    }

    public void DisplayDialog()
    {
        timerDisplay = displayTime;
        dialogBox.SetActive(true);
    }
}
