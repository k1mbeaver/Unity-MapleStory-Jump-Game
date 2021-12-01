using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    [SerializeField]
    private GameObject NpcManager = null;
    [SerializeField]
    private GameObject MonsterManager = null;
    [SerializeField]
    private GameObject PortalManager = null;
    [SerializeField]
    private GameObject WoodSpinManager = null;

    private GameObject myNpc = null;
    private GameObject myMonster = null;
    private GameObject myPortal = null;
    private GameObject myWoodSpin = null;


    private void Awake()
    {
        myNpc = Instantiate(NpcManager);
        myMonster = Instantiate(MonsterManager);
        myPortal = Instantiate(PortalManager);
        myWoodSpin = Instantiate(WoodSpinManager);


        myNpc.name = "NpcManager";
        myNpc.transform.SetParent(transform);
        myMonster.name = "MonsterManager";
        myMonster.transform.SetParent(transform);
        myPortal.name = "PortalManager";
        myPortal.transform.SetParent(transform);
        myWoodSpin.name = "WoodSpinManager";
        myWoodSpin.transform.SetParent(transform);
    }
}
