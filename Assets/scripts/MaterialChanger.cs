using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChanger : MonoBehaviour {

    public Material[] material;
    ActivationManager activationManager;
    Renderer rendererSelf;

    void ChangeMaterial()
    {
        rendererSelf.sharedMaterial = material[1];
        Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
    }

    void Awake()
    {
        activationManager = GetComponent<ActivationManager>();
    }

    void Start ()
    {
        rendererSelf = GetComponent<Renderer>();
        rendererSelf.enabled = true;
        rendererSelf.sharedMaterial = material[0];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnEnable()
    {
        activationManager.OnActivated += ChangeMaterial;
    }

    void OnDisable()
    {
        activationManager.OnActivated -= ChangeMaterial;
    }
}
