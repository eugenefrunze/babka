using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChangeLevel : MonoBehaviour
{
    // global

    ActivationManager activationManager;

    // functionalities

    public string sceneToLoad;
    public string sceneToUnload;

    public bool isPointEntity = true;

    // global functions

    private void Awake()
    {
        activationManager = GetComponent<ActivationManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isPointEntity)
            return;
        else
            DoDirt();
    }

    private void OnEnable()
    {
        activationManager.OnActivated += DoDirt;
    }

    private void OnDisable()
    {
        activationManager.OnActivated -= DoDirt;
    }

    // user functions

    public void DoDirt()
    {
        if (sceneToLoad != "")
            SceneManage.sceneManageInstance.Load(sceneToLoad);
        if (sceneToUnload != "")
            StartCoroutine(UnloadSceneCoroutine());
    }

    IEnumerator UnloadSceneCoroutine()
    {
        yield return new WaitForSeconds(0.10f);
        SceneManage.sceneManageInstance.Unload(sceneToUnload);
    }
}
