using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    protected GameObject player;
    protected GameObject wave;
    protected bool active = false;
    protected float timer;

    public void Setup(GameObject p, GameObject w)
    {
        player = p;
        wave = w;
        active = true;
    }
}
