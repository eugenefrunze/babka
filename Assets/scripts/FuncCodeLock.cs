using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class FuncCodeLock : MonoBehaviour
{

    public bool isUnlocked;
    public InputField inputField;
    public string password = "123";
    public string errorText = "ERROR";
    public string defaultText = "ENTER CODE";
    public string successText = "CODE ACCEPTED";
    public Color errorColor = Color.red;
    public Color successColor = Color.green;
    FirstPersonController playerFPSController;
    Text inputFieldText;
    public GameObject player;
    PlayerInteractor playerInteractor;
    [Header("BUTTONS")]
    public GameObject canvas;
    ActivationManager activationManager;
    public List<GameObject> targets;
    [Header("SPECIALS (DON'T USE)")]
    public List<ActivationManager> targetActivManager;

    public void OpenCodeLock()
    {
        canvas.SetActive(true);
        playerFPSController.enabled = false;
        playerInteractor.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void GetAwayLock()
    {
        canvas.SetActive(false);
        playerFPSController.enabled = true;
        playerInteractor.enabled = true;
    }

    public void  EnterPassword()
    {
        if(inputField.text == password)
        {
            foreach (ActivationManager activationManager in targetActivManager)
            {
                activationManager.Activation();
            }

            ClearText();
            inputFieldText.text = successText;
            inputFieldText.color = successColor;
        }
        else
        {
            ClearText();
            inputFieldText.text = errorText;
            inputFieldText.color = errorColor;
        }
    }

    public void ClearText()
    {
        inputField.text = string.Empty;
    }

    public void AddSymbol(string symbol)
    {
        if (inputField.text.Length < password.Length)
        {
            inputField.text += symbol;
        }
    }

    private void Awake()
    {
        activationManager = GetComponent<ActivationManager>();
    }

    private void Start()
    {
        // filling targets activation managers list

        for (int i = 0; i < targets.Count; i++)
        {
            targetActivManager.Add(targets[i].GetComponent<ActivationManager>());
        }

        canvas.SetActive(false); // delete this later ------------------------------
        isUnlocked = false;
        inputFieldText = inputField.placeholder.GetComponent<Text>();
        inputFieldText.text = defaultText;
        inputField.interactable = false; // delete this later ------------------------------
        inputField.characterLimit = password.Length;

        // player

        playerFPSController = player.GetComponent<FirstPersonController>();
        playerInteractor = player.GetComponentInChildren<PlayerInteractor>();
    }

    private void OnEnable()
    {
        activationManager.OnActivated += OpenCodeLock;
    }

    private void OnDisable()
    {
        activationManager.OnActivated -= OpenCodeLock;
    }
}
