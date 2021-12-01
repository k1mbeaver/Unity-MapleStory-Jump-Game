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

            myMonster.name = "WoodSpin"; // Tile 오브젝트의 이름을 "Tile"로 설정
            myMonster.transform.SetParent(transform); // MonsterManager 오브젝트를 Monster 오브젝트의 부모로 설정
        }
    }
}
