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

        myPlayer.name = "Cat"; // Tile 오브젝트의 이름을 "Tile"로 설정
        myPlayer.transform.SetParent(transform); // MonsterManager 오브젝트를 Monster 오브젝트의 부모로 설정

        myCamera = Instantiate(vcam);
        myCamera.name = "FollowCamera"; // Tile 오브젝트의 이름을 "Tile"로 설정
        myCamera.transform.SetParent(transform); // MonsterManager 오브젝트를 Monster 오브젝트의 부모로 설정
    }

    private void Update()
    {
        myCamera.Follow = myPlayer.transform;
    }
}
