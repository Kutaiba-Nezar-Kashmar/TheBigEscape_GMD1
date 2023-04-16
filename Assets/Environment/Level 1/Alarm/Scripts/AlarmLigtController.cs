using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmLigtController : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100;
    private void Update()
    {
        //transform.Rotate(0,0, 90 * Time.deltaTime * 10);
        transform.RotateAround(transform.position, Vector3.back, rotationSpeed * Time.deltaTime);
    }
}
