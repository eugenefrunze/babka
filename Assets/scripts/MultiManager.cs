 using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiManager : MonoBehaviour {

    ActivationManager activationManager;

    [Header("target objects")]
    public List<TargetObject> targets;
    [HideInInspector] public List<ActivationManager> targetsActManagers;

    [Header("target to kill")]
    public GameObject killTarget;
    public float delayBeforeKill = 0.0f;

    IEnumerator ActivationCourutine(float delayBeforeTrigger, int index)
    {
        yield return new WaitForSeconds(delayBeforeTrigger);
        targetsActManagers[index].Activation();
    }

    void TriggerActivation()
    {
        for (int i = 0; i < targets.Count; i++)
        {
            StartCoroutine(ActivationCourutine(targets[i].delayBeforeTrigger, i));
        }

        if (killTarget != null)
        Destroy(killTarget, delayBeforeKill);
    }

    private void Awake()
    {
        activationManager = GetComponent<ActivationManager>();
    }

    private void Start()
    {
        for (int i=0; i < targets.Count; i++)
        {
            targetsActManagers.Add(targets[i].target.GetComponent<ActivationManager>());
        }
    }

    private void OnEnable()
    {
        activationManager.OnActivated += TriggerActivation;
    }

    private void OnDisable()
    {
        activationManager.OnActivated -= TriggerActivation;
    }

}
