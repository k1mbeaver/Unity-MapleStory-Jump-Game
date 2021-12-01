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
        myBackImage.transform.SetParent(transform); // MonsterManager ������Ʈ�� Monster ������Ʈ�� �θ�� ����

        GameObject myBackSound = Instantiate(mySound);

        myBackSound.name = "bgSound";
        myBackSound.transform.SetParent(transform); // MonsterManager ������Ʈ�� Monster ������Ʈ�� �θ�� ����
    }
}
