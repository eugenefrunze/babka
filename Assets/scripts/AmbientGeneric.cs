using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientGeneric : MonoBehaviour {

    ActivationManager activationManager;
    AudioSource audioSource;

    void PlaySound()
    {
        audioSource.Play();
    }

	// Use this for initialization
	void Awake ()
    {
        activationManager = GetComponent<ActivationManager>();
	}

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        activationManager.OnActivated += PlaySound;
    }

    private void OnDisable()
    {
        activationManager.OnActivated -= PlaySound;
    }
}
