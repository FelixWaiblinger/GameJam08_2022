using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSetup : MonoBehaviour
{
    [SerializeField] private ParticleSystem ps;

    public void setColor(Color color)
    {
        ParticleSystem.MainModule mainModule = ps.main;
        mainModule.startColor = new Color(color.r / 255f, color.g / 255f, color.b / 255);
    }
}
