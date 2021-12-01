using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodSpinManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] MyObject = null;

    private void Awake()
    {
        for (int index = 0; index < MyObject.Length; index++)
        {
            GameObject myMonster = Instantiate(MyObject[index]);

            myMonster.name = "WoodSpin"; // Tile ������Ʈ�� �̸��� "Tile"�� ����
            myMonster.transform.SetParent(transform); // MonsterManager ������Ʈ�� Monster ������Ʈ�� �θ�� ����
        }
    }
}
