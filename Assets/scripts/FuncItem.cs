using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuncItem : MonoBehaviour
{
    ActivationManager activationManager;

    public Inventory inventory;

    public int itemIndex;

    public void PickUp()
    {
        inventory.AddItem(itemIndex);
    }

    private void Awake()
    {
        activationManager = GetComponent<ActivationManager>();
    }

    private void OnEnable()
    {
        activationManager.OnActivated += PickUp;
    }

    private void OnDisable()
    {
        activationManager.OnActivated -= PickUp;
    }
}
