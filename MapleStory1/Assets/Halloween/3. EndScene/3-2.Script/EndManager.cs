using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndManager : MonoBehaviour
{
    [Header("Yes")]
    [SerializeField]
    private GameObject yesButton;

    [Header("No")]
    [SerializeField]
    private GameObject noButton;

    [Header("BGM")]
    [SerializeField]
    private GameObject bgm;

    private GameObject myYes;
    private GameObject myNo;
    private GameObject myBgm;

    private void Awake()
    {
        myYes = Instantiate(yesButton);
        myNo = Instantiate(noButton);
        myBgm = Instantiate(bgm);

        myYes.name = "Yes";
        myYes.transform.SetParent(transform);

        myNo.name = "No";
        myNo.transform.SetParent(transform);

        myBgm.name = "BGM";
        myBgm.transform.SetParent(transform);
    }
}
