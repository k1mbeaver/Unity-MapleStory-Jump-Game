using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileName {Halloween_Tile1_1, Halloween_Tile1_2, Halloween_Tile1_3, Halloween_Tile1_4, Halloween_Tile1_5, Halloween_Tile1_6,
    Halloween_Incline_Tile1_1, Halloween_Incline_Tile1_2, Halloween_Incline_Tile1_3, Halloween_Incline_Tile1_4, Halloween_Incline_Tile1_5,
    Halloween_Incline_Tile2_1, Halloween_Incline_Tile2_2, Halloween_Incline_Tile2_3, Halloween_Incline_Tile2_4, Halloween_Incline_Tile2_5
}
// LastIndex = ���� �ľǿ�, Empty = �����

public class Tile : MonoBehaviour
{
    [SerializeField]
    private Sprite[] images = null; // Ÿ�Ͽ� ����� �� �ִ� �̹��� �迭
    private SpriteRenderer spriteRenderer = null; // Ÿ�� �̹��� ������ ���� SpriteRenderer
    private TileName tileName; // ���� Ÿ���� �̸�

    public void Setup(TileName tileName)
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        TileName = tileName;
    }

    public TileName TileName
    {
        get => tileName;
        set
        {
            tileName = value;
            spriteRenderer.sprite = images[(int)tileName];
        }
    }
}
