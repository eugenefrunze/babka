using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationManager : MonoBehaviour, IActivable
{
    public GameObject theInteractor;
    public delegate void ActivateAction();
    public event ActivateAction OnActivated;
    public bool isMastered = false;

    public void Activation()
    {
        if (OnActivated != null)
        {
            OnActivated();
            Debug.Log("ACTIVATED ( ͡ ͡° ͜ ʖ ͡ ͡°)");
        }
    }
}
