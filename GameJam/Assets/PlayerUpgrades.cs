using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUpgrades : MonoBehaviour
{
    [SerializeField] private Transform parent;
    [SerializeField] private Image upgradeBackground;
    [SerializeField] private Vector3 offset = new Vector3(1f, 0f, 0f);
    [SerializeField] private List<Upgrade> upgrades;

    private Vector3 position;

    public static event Action upgradeEvent;

    void Start()
    {
        upgradeEvent += Relocate;
        upgrades = new List<Upgrade>();
        position = parent.position - Vector3.right * 0.87f;
    }

    void Relocate()
    {
        if (upgrades.Count > 0)
            upgradeBackground.enabled = true;
        else
            upgradeBackground.enabled = false;

        int idx = 0;
        foreach (Upgrade upgrade in upgrades)
        {
            upgrade.Relocate(position + idx * offset);
            ++idx;
        }

        upgradeBackground.GetComponent<RectTransform>().sizeDelta =
            Vector2.right * (++idx) + Vector2.up;
    }

    public void Remove(Upgrade upgrade)
    {
        upgrades.Remove(upgrade);
        upgradeEvent();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // collect upgrade
        if (col.gameObject.layer == LayerMask.NameToLayer("UpgradeLayer"))
        {
            // deactivate upgrade "on screen"
            col.collider.enabled = false;

            // keep track of upgrade and set it up
            Upgrade upgrade = col.gameObject.GetComponent<Upgrade>();
            upgrades.Add(upgrade);
            upgradeEvent();
            upgrade.Setup(gameObject);
        }
    }
}
