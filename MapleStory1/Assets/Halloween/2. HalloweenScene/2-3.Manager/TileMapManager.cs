using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMapManager : MonoBehaviour
{
    [SerializeField]
    private TilesCollide tilescollide = null;

    private void Awake()
    {
        tilescollide.makeCollider();
    }
}
