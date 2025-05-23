using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//HP UI Player 정면 방향 고정
public class Billboard : MonoBehaviour
{
    private Camera mainCam;
    private GameObject player;
    // Start is called before the first frame update

    private void Awake()
    {
        player = transform.root.gameObject;
    }
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame

    private void LateUpdate()
    {
        if (mainCam == null) return;

        Vector3 lookDir = mainCam.transform.position - player.transform.position;
        lookDir.y = 0f; 
        transform.rotation = Quaternion.LookRotation(-lookDir);
    }
}
