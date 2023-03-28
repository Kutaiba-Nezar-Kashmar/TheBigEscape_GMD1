using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    public Transform player;
    public Vector3 cameraOffset;
    public float smoothFa;
    public bool lookAt = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        var newPos = player.transform.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPos, smoothFa);

        if (lookAt)
        {
            transform.LookAt(player);
        }
    }
}
