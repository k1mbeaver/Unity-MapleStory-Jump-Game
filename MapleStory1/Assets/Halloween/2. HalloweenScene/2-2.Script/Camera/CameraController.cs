using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private PolygonCollider2D vcamCollider = null;
    private PolygonCollider2D myCollider = null;
    private CinemachineConfiner vcamConfiner = null;

    // Start is called before the first frame update
    void Awake()
    {
        vcamConfiner = GetComponent<CinemachineConfiner>();

        myCollider = Instantiate(vcamCollider);
        myCollider.name = "MaxConfiner";

        vcamConfiner.m_BoundingShape2D = myCollider;
        vcamConfiner.m_ConfineScreenEdges = true;
    }
}
