using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuncPickupable : MonoBehaviour
{

    private GameObject theInteractor;
    public float throwForce = 600;
    private Vector3 objectPosotion;
    private float distance;
    public bool canHold = true;
    public GameObject item;
    public bool isHolding = false;

    void Update()
    {
        if(isHolding)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            transform.SetParent(GetComponent<ActivationManager>().theInteractor.transform);

            if(Input.GetMouseButtonDown(1))
            {
                GetComponent<Rigidbody>().AddForce(GetComponent<ActivationManager>().theInteractor.transform.forward * throwForce, ForceMode.Impulse);
                isHolding = false;
                transform.SetParent(null);
                GetComponent<Rigidbody>().useGravity = true;
                GetComponent<Rigidbody>().detectCollisions = true;
            }
        }
    }

    void OnMouseDown()
    {
        isHolding = true;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().detectCollisions = true;
    }

    void OnMouseUp()
    {
        isHolding = false;
        transform.SetParent(null);
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().detectCollisions = true;
    }
}
