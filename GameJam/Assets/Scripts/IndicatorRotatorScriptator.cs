using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorRotatorScriptator : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = -150;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * rotateSpeed, Space.World);
    }
}
