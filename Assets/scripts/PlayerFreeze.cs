using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerFreeze : MonoBehaviour
{
    // globals

    ActivationManager activationManager;
    FirstPersonController playerFPSController;
    PlayerInteractor playerInteractor;

    public GameObject player;

    // functionalities

    public float freezeTime = 1.0f;
    public bool isPermanent;
    bool isFrozen = false;

    // global functions

    private void Awake()
    {
        activationManager = GetComponent<ActivationManager>();
    }

    private void Start()
    {
        playerFPSController = player.GetComponent<FirstPersonController>(); // %^&%&%^&%^&
        playerInteractor = player.GetComponentInChildren<PlayerInteractor>(); // %^&$%^$%$
    }

    private void OnEnable()
    {
        activationManager.OnActivated += Freeze;
    }

    private void OnDisable()
    {
        activationManager.OnActivated -= Freeze;
    }

    // user functions

    void Freeze()
    {
        if (!isPermanent)
            StartCoroutine(FreezeCourutine());
        else
        {
            isFrozen = true;
        }
            
    }   

    IEnumerator FreezeCourutine()
    {
        playerInteractor.enabled = false;
        playerFPSController.enabled = false;
        yield return new WaitForSeconds(freezeTime);
        playerFPSController.enabled = true;
        playerInteractor.enabled = true;
    }
}
