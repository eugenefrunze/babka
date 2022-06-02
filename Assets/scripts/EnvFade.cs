using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvFade : MonoBehaviour
{
    ActivationManager activationManager;

    public float duration;
    public bool fadeFrom;

    private void Awake()
    {
        activationManager = GetComponent<ActivationManager>();
    }

    IEnumerator FadeFrom()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>(); // ----- -- to think about it %&&^%&^*^&
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime / duration;
            yield return null;
        }
    }

    IEnumerator FadeTo()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>(); // ----- -- to think about it %&&^%&^*^&
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime / duration;
            yield return null;
        }
    }

    public void Fade()
    {
        if (fadeFrom)
            StartCoroutine(FadeFrom());
        else
            StartCoroutine(FadeTo());
    }

    private void OnEnable()
    {
        activationManager.OnActivated += Fade;
    }

    private void OnDisable()
    {
        activationManager.OnActivated -= Fade;
    }
}
