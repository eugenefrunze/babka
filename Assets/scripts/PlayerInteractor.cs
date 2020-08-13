using System;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour {

    public float distance = 0.5f;

    public LayerMask mask;

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hitInfo;
            Debug.Log("IMTRIYNG!");
            if (Physics.Raycast(ray, out hitInfo, distance, mask))
            {
                hitInfo.transform.GetComponent<ActivationManager>().Activation();
                hitInfo.transform.GetComponent<ActivationManager>().theInteractor = gameObject;
            }
        }
	}
}
