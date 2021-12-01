using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalAnimation : MonoBehaviour
{
    [SerializeField]
    private Sprite[] portalAnimation; //  애니메이션

    private SpriteRenderer portalRend;
    private int frameCount = 0;
    private int spriteCount = 0;

    // Start is called before the first frame update
    private void Start()
    {
        portalRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        portalRend.sprite = portalAnimation[spriteCount];
        frameCount++;
        if (frameCount % 10 == 0)
        {
            spriteCount++;
        }

        if (frameCount == 80)
        {
            frameCount = 0;
        }

        if (spriteCount == 8)
        {
            spriteCount = 0;
        }
    }
}
