using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player = null;
    [SerializeField]
    private CinemachineVirtualCamera vcam = null;

    private CinemachineVirtualCamera myCamera = null;
    private GameObject myPlayer = null;

    private void Awake()
    {
        myPlayer = Instantiate(player);

        myPlayer.name = "Cat"; // Tile ������Ʈ�� �̸��� "Tile"�� ����
        myPlayer.transform.SetParent(transform); // MonsterManager ������Ʈ�� Monster ������Ʈ�� �θ�� ����

        myCamera = Instantiate(vcam);
        myCamera.name = "FollowCamera"; // Tile ������Ʈ�� �̸��� "Tile"�� ����
        myCamera.transform.SetParent(transform); // MonsterManager ������Ʈ�� Monster ������Ʈ�� �θ�� ����
    }

    private void Update()
    {
        myCamera.Follow = myPlayer.transform;
    }
}
