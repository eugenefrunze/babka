using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class FuncBook : MonoBehaviour {

    AudioSource audioSource;
    ActivationManager activationManager;
    public GameObject player;
    FirstPersonController playerFPSController;
    PlayerInteractor playerInteractor;
    public GameObject canvas;

    public Image[] imagesPages;
    public AudioClip soundTakeBook;
    public AudioClip soundPageSlide;
    public AudioClip soundPutAway;

    int currentPage = 0;

    void Awake()
    {
        activationManager = GetComponent<ActivationManager>();
        canvas.SetActive(false); // ------------------ must delete it IIAAAARRRR --------------------
    }

    void Start ()
    {
        audioSource = GetComponent<AudioSource>();

        foreach (Image page in imagesPages)
        {
            page.enabled = false;
        }

        playerFPSController = player.GetComponent<FirstPersonController>();
        playerInteractor = player.GetComponentInChildren<PlayerInteractor>();
    }

    public void OpenBook()
    {
        canvas.SetActive(true);
        audioSource.PlayOneShot(soundTakeBook);
        imagesPages[0].enabled = true;
        playerFPSController.enabled = false;
        playerInteractor.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void SlideLeft()
    {
        audioSource.PlayOneShot(soundPageSlide);

        imagesPages[currentPage].enabled = false;

        if (currentPage > 0)
            currentPage--;
        else
            currentPage = imagesPages.Length - 1;

        imagesPages[currentPage].enabled = true;

        Debug.Log("SLIDING LEFT");
    }

    public void SlideRight()
    {
        audioSource.PlayOneShot(soundPageSlide);

        imagesPages[currentPage].enabled = false;

        if (currentPage < imagesPages.Length - 1)
            currentPage++;
        else
            currentPage = 0;

        imagesPages[currentPage].enabled = true;


        Debug.Log("SLIDING RIGHT");
    }

    public void PutBook()
    {
        audioSource.PlayOneShot(soundPutAway);
        canvas.SetActive(false);
        imagesPages[0].enabled = false; // ---- find out, is this shit necessary, maybe just forgot to delete it
        playerFPSController.enabled = true;
        playerInteractor.enabled = true;
    }

    private void OnEnable()
    {
        activationManager.OnActivated += OpenBook;
    }

    private void OnDisable()
    {
        activationManager.OnActivated -= OpenBook;
    }
}
