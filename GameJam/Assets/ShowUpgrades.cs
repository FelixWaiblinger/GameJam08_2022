using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowUpgrades : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private Transform parent;
    [SerializeField] private GameObject slider;
    [SerializeField] private Vector3 offset = new Vector3(50f, 0f, 0f);

    private List<GameObject> upgrades = new List<GameObject>();

    void Start()
    {
        PlayerController.upgradeListEvent += showUpgrade;
    }

    void showUpgrade(bool add)
    {
        //if (add)
        //{
        //    GameObject obj = player.getUpgrades()[player.getUpgrades().Count - 1];
//
        //    
        //}
        //else
        //{
//
        //}
        //int idx = 0;
        //foreach (GameObject upgrade in player.getUpgrades())
        //{
//
        //}
        //for (int i = 0; i < upgrades.Count; ++i)
        //{
        //    GameObject icon = Instantiate(slider, parent.position + i * offset, Quaternion.identity);
        //    
        //    Slider slider = icon.GetComponent<Slider>();
//
        //    slider.maxValue = upgrades[i].
        //}
    }

    void Update()
    {
        
    }
}
