using System;
using UnityEngine;

public class TriggerMultiple : MonoBehaviour
{
    public GameObject[] target;
    ActivationManager[] activationManager;
    public bool items = false;
    public bool player = true;
    public bool once;

    private void Start()
    {
        {
            Array.Resize(ref activationManager, target.Length);

            for (int i = 0; i < target.Length; i++)
            {
                activationManager[i] = target[i].GetComponent<ActivationManager>();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (!items && player)
        {
            if (other.gameObject.tag == "Player")
            {
                foreach (ActivationManager i in activationManager)
                {
                    i.Activation();
                }
            }
        }
        else if (items && !player)
        {
            if (other.gameObject.tag != "Player")
            {
                foreach (ActivationManager i in activationManager)
                {
                    i.Activation();
                }
            }
        }
        else
        {
            foreach (ActivationManager i in activationManager)
            {
                i.Activation();
            }
        }

        if (once)
            GetComponent<Collider>().enabled = false;
    }
}
