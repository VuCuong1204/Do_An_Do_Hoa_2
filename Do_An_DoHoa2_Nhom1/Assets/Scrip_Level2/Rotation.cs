using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] float RotateSpeed = 90;
    void Update()
    {
        transform.Rotate(0, RotateSpeed * Time.deltaTime * 2f, 0);
    }
}
