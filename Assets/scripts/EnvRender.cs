using System;
using UnityEngine;

public class EnvRender : MonoBehaviour
{
    public GameObject target;
    ActivationManager activationManager;

    void Awake()
    {
        activationManager = GetComponent<ActivationManager>();
    }

    void Render()
    {
        //target.GetComponent<ActivationManager>().Activation();
        target.SetActive(!target.activeInHierarchy);
    }

    private void OnEnable()
    {
        activationManager.OnActivated += Render;
    }

    private void OnDisable()
    {
        activationManager.OnActivated -= Render;
    }
}
