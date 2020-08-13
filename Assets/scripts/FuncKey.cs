using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuncKey : MonoBehaviour
{
    public GameObject lockedObject;
    ActivationManager activationManager;
    ActivationManager targetActivManager;

    public void Unlock()
    {
        targetActivManager.isMastered = false;
        Destroy(gameObject);
    }

    private void Awake()
    {
        activationManager = GetComponent<ActivationManager>();
        targetActivManager = lockedObject.GetComponent<ActivationManager>();
    }

    private void OnEnable()
    {
        activationManager.OnActivated += Unlock;
    }

    private void OnDisable()
    {
        activationManager.OnActivated -= Unlock;
    }

}
