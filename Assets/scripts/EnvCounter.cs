using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvCounter : MonoBehaviour
{
    public int targetValue = 1;
    public int currentValue;
    public GameObject target;
    ActivationManager activationManager;

    void Awake()
    {
        activationManager = GetComponent<ActivationManager>();
    }

    void Count()
    {
        if (currentValue < targetValue - 1)
            currentValue++;
        else
        {
            currentValue++;
            target.GetComponent<ActivationManager>().Activation();
        }
    }

    private void OnEnable()
    {
        activationManager.OnActivated += Count;
    }

    private void OnDisable()
    {
        activationManager.OnActivated -= Count;
    }
}
