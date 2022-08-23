using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    [SerializeField] protected Image icon;

    protected GameObject player;
    protected bool active = false;
    protected float timer;

    public void Setup(GameObject p)
    {
        player = p;
        active = true;
        icon.color -= new Color(0, 0, 0, 0.2f);
    }

    public void Relocate(Vector3 pos)
    {
        icon.gameObject.transform.position = pos;
    }
}
