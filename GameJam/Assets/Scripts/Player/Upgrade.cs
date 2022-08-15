using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    protected GameObject player;
    protected bool active = false;
    protected float timer;

    public void Setup(GameObject p)
    {
        player = p;
        active = true;
    }
}
