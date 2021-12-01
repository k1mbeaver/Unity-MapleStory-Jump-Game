using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    [Header("Image")]
    [SerializeField]
    private GameObject myImage = null;

    [Header("Sound")]
    [SerializeField]
    private GameObject mySound = null;

    private void Awake()
    {
        GameObject myBackImage = Instantiate(myImage);

        myBackImage.name = "bgImage";
        myBackImage.transform.SetParent(transform); // MonsterManager 오브젝트를 Monster 오브젝트의 부모로 설정

        GameObject myBackSound = Instantiate(mySound);

        myBackSound.name = "bgSound";
        myBackSound.transform.SetParent(transform); // MonsterManager 오브젝트를 Monster 오브젝트의 부모로 설정
    }
}
