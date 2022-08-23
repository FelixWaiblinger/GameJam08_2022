using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Limiter : MonoBehaviour
{
    [SerializeField] private int FPS;

    private void Awake()
    {
        Application.targetFrameRate = FPS;
    }
}
