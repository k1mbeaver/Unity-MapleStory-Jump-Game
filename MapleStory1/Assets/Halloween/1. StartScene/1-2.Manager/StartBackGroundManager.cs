using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBackGroundManager : MonoBehaviour
{
    [Header("Image")]
    [SerializeField]
    private GameObject bgImage;

    [Header("Sound")]
    [SerializeField]
    private GameObject bgSound;

    private GameObject myImage;
    private GameObject mySound;

    private void Awake()
    {
        myImage = Instantiate(bgImage);
        mySound = Instantiate(bgSound);

        myImage.name = "Image";
        myImage.transform.SetParent(transform); 

        mySound.name = "Sound";
        mySound.transform.SetParent(transform);
    }
}
