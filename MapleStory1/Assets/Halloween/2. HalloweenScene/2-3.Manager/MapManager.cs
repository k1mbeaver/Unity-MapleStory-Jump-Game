using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [Header("BackGround")]
    [SerializeField]
    private GameObject BackGround = null;
    [Header("Tile")]
    [SerializeField]
    private GameObject Tiles = null;

    private GameObject myBg = null;
    private GameObject myTiles = null;


    private void Awake()
    {
        myBg = Instantiate(BackGround);
        myTiles = Instantiate(Tiles);


        myBg.name = "BackGroundManager";
        myBg.transform.SetParent(transform);
        myTiles.name = "TilesManager";
        myTiles.transform.SetParent(transform);
    }
}
