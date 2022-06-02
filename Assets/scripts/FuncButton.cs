using System;
using UnityEngine;

public class FuncButton : MonoBehaviour {

    public GameObject[] targets;
    ActivationManager[] targetActivationManager;
    ActivationManager activationManager;
    [Header("is button destroys itself after all")]
    public bool killYourSelf;

    void Awake()
    {
        activationManager = GetComponent<ActivationManager>();
    }

    void Start()
    {
        Array.Resize(ref targetActivationManager, targets.Length);
        for (int i = 0; i < targets.Length; i++)
        {
            targetActivationManager[i] = targets[i].GetComponent<ActivationManager>();
        }
    }

    void triggerActivation()
    {
        foreach (ActivationManager activationManager in targetActivationManager)
            activationManager.Activation();
        //Debug.Log(targets); - is this a necessary?  ---- ----           -----  --- -     -      $%^&%&%^&$%#$
        if (killYourSelf)
            Destroy(gameObject);
    }

    private void OnEnable()
    {
        activationManager.OnActivated += triggerActivation;
    }

    private void OnDisable()
    {
        activationManager.OnActivated -= triggerActivation;
    }
}
