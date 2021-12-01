using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesCollide : MonoBehaviour
{
    [SerializeField]
    private GameObject[] colliderList = null;

    public void makeCollider()
    {
        for(int index = 0; index < colliderList.Length; index++)
        {
            GameObject myCollider = Instantiate(colliderList[index]);

            myCollider.name = "Collider"; // Tile 오브젝트의 이름을 "Tile"로 설정
            myCollider.transform.SetParent(transform); // Tilemap2D 오브젝트를 Tile 오브젝트의 부모로 설정
        }
    }
}