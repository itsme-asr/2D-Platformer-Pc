using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour
{
    [SerializeField] private float rotatingSpeed = 2f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 360 * rotatingSpeed * Time.deltaTime);
    }
}
