using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuncDoor : MonoBehaviour {

    // main types and parameters
    
    ActivationManager activationManager;
    AudioSource audioSource;

    public delegate Quaternion AxisChanger(float distance);
    AxisChanger[] NAxisDel = new AxisChanger[3];

    public enum Axis
    {
        XAxis,
        YAxis,
        ZAxis
    }
    public Axis axis = Axis.YAxis;

    [Header("sounds")]
    public AudioClip openingSound;
    public AudioClip lockedSound;

    [Header("moving parameters")]
    public float distance = 90f;
    public float defaultDistance = 0f;
    public float speed = 2f;
    bool isOpening;

    // user functions

    #region user functions...

    void Rotation()
    {
        if (!activationManager.isMastered)
        {
            isOpening = !isOpening;
            audioSource.PlayOneShot(openingSound);
        }
        else
        {
            audioSource.PlayOneShot(lockedSound);
        }
    }

    Quaternion XAxis(float distance)
    {
        return Quaternion.Euler(distance, 0, 0);
    }

    Quaternion YAxis(float distance)
    {
        return Quaternion.Euler(0, distance, 0);
    }

    Quaternion ZAxis(float distance)
    {
        return Quaternion.Euler(0, 0, distance);
    }

    #endregion

    // engine functions

    void Awake()
    {
        activationManager = GetComponent<ActivationManager>();
    }

    void Start()
    {
        NAxisDel[0] = new AxisChanger(XAxis);
        NAxisDel[1] = new AxisChanger(YAxis);
        NAxisDel[2] = new AxisChanger(ZAxis);

        audioSource = GetComponent<AudioSource>();
        isOpening = false;
    }

    void Update()
    {
        if(isOpening)
        {
            Quaternion targetRotation = NAxisDel[(int)axis](distance);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, speed * Time.deltaTime);
        }
        else
        {
            Quaternion targetRotation2 = NAxisDel[(int)axis](defaultDistance);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation2, speed * Time.deltaTime);
        }
    }

    void OnEnable()
    {
        activationManager.OnActivated += Rotation;
    }

    void OnDisable()
    {
        activationManager.OnActivated -= Rotation;
    }
}
