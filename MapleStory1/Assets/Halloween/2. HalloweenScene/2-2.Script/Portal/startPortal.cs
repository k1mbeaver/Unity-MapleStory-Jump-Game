using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startPortal : MonoBehaviour
{
    private float displayTime = 4.0f;
    private float timerDisplay;

    // Start is called before the first frame update
    private void Start()
    {
        timerDisplay = -1.0f;
    }

    // Update is called once per frame
    private void Update()
    {
        if(timerDisplay >= 0)
        {
            timerDisplay -= Time.deltaTime;
            if(timerDisplay < 0)
            {
                GameObject.Find("Canvas").transform.Find("start").gameObject.SetActive(false);
                GameObject.Find("Canvas").transform.Find("start").transform.Find("Box").gameObject.SetActive(false);
                GameObject.Find("Canvas").transform.Find("start").transform.Find("Box").transform.Find("Text").gameObject.SetActive(false);
            }
        }
    }

    public void DisplayDialog()
    {
        timerDisplay = displayTime;
        GameObject.Find("Canvas").transform.Find("start").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("start").transform.Find("Box").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("start").transform.Find("Box").transform.Find("Text").gameObject.SetActive(true);
    }
}
