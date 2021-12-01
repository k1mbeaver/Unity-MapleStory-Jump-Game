using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] MyObject = null;

    private void Awake()
    {
        for (int index = 0; index < MyObject.Length; index++)
        {
            GameObject myMonster = Instantiate(MyObject[index]);

            myMonster.name = "Npc";
            myMonster.transform.SetParent(transform); // MonsterManager 오브젝트를 Monster 오브젝트의 부모로 설정
        }
    }
}
