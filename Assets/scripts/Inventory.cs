using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Inventory : MonoBehaviour
{
    // main and global objects

    ActivationManager activationManager;

    // inventory objects

    [Header("level items database")]
    public List<Item> itemsDB;

    [Header("player's inventory")]
    public List<Item> items;

    [Header("slots backgrounds, direct references")]
    public Image[] slotsImagesObjects; // used to avoid the GetComponent function and set component refs directly

    public Sprite slotEmptySprite;

    // player components

    [Header("player and interaction side")]
    // player
    public GameObject player;
    FirstPersonController playerFPSConroller;
    PlayerInteractor playerInteractor;
    //canvas
    public GameObject canvas;
    //states
    bool isOpened = false;



    // main functions

    void Awake()
    {
        activationManager = GetComponent<ActivationManager>();
    }

    void Start()
    {
        playerFPSConroller = player.GetComponent<FirstPersonController>();
        playerInteractor = player.GetComponentInChildren<PlayerInteractor>();

        canvas.SetActive(false); // ------------   -- -- -- - delete this after AAAAAAAa  a%&$%^#$sgdrgg  e42355345re -----
    }

    private void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            if (!isOpened)
                OpenInventory();
            else
                CloseInventory();
        }
    }

    private void OnEnable()
    {
        activationManager.OnActivated += OpenInventory;
    }

    private void OnDisable()
    {
        activationManager.OnActivated -= OpenInventory;
    }

    // user functions

    public void OpenInventory()
    {
        isOpened = true;
        canvas.SetActive(true);
        playerFPSConroller.enabled = false;
        playerInteractor.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void CloseInventory()
    {
        isOpened = false;
        canvas.SetActive(false);
        playerFPSConroller.enabled = true;
        playerInteractor.enabled = true;
    }

    public void AddItem(int index)
    {
        items.Add(itemsDB[index]);
        slotsImagesObjects[items.Count - 1].sprite = itemsDB[index].image;
    }

    public void ReleaseItem(int index)
    {
        if(index > items.Count || items.Count == 0)
        {
            Debug.Log("YOU'RE USING AN EMPTY SLOT");
            return;
        }

        if (!items[index].isFreePlace)
        {
            if (items[index].triggerInOut.isPlayerIn)
            {
                items[index].target.GetComponent<ActivationManager>().Activation(); // to think, how optimize this -- ---d%^&%^&$%
            }
            else
            {
                Debug.Log("YOU CAN'T USE THIS ITEM HERE");
                return;
            }

            MultiplyItem(index);
        }
        else
        {
            items[index].target.GetComponent<ActivationManager>().Activation();
            MultiplyItem(index);
        }
    }

    public void MultiplyItem(int index)
    {
        if (items[index].multiply > 0)
        {
            items[index].multiply--;
        }
        if (items[index].multiply == 0)
        {
            RemoveItem(index);
        }
    }

    public void RemoveItem(int index)
    {

        if (index < items.Count)
        {
            items.RemoveAt(index);
            Debug.Log("DELETED");
            for (int i = 0; i < slotsImagesObjects.Length; i++)
            {
                if (i < items.Count)
                {
                    slotsImagesObjects[i].sprite = items[i].image;
                }
                else
                {
                    slotsImagesObjects[i].sprite = slotEmptySprite;
                }
            }
        }
        else
            Debug.Log("THERE IS NO ITEM IN THIS SLOT");
    }
}
