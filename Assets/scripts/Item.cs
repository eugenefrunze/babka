using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Item
{

    // base

    public int id;
    public string itemName;
    public Sprite image;

    // specials

    public GameObject target;
    public int multiply = 0;
    public bool isFreePlace = false;
    public TriggerInOut triggerInOut;
}
