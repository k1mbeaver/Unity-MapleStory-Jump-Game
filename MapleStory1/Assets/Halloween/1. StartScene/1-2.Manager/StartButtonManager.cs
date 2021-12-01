using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonManager : MonoBehaviour
{
    [Header("Yes")]
    [SerializeField]
    private GameObject YesButton;

    [Header("No")]
    [SerializeField]
    private GameObject NoButton;

    private GameObject myYes;
    private GameObject myNo;

    private void Awake()
    {
        myYes = Instantiate(YesButton);
        myNo = Instantiate(NoButton);

        myYes.name = "Yes";
        myYes.transform.SetParent(transform);

        myNo.name = "No";
        myNo.transform.SetParent(transform);
    }
}
