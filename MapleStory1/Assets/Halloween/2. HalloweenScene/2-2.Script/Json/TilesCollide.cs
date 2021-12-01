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

            myCollider.name = "Collider"; // Tile ������Ʈ�� �̸��� "Tile"�� ����
            myCollider.transform.SetParent(transform); // Tilemap2D ������Ʈ�� Tile ������Ʈ�� �θ�� ����
        }
    }
}