using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTexHandler : MonoBehaviour
{
    public Camera camB;
    public Material camMatB;
    
    void Start() {
        if (camB.targetTexture != null) {
            camB.targetTexture.Release();
        }

        camB.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        camMatB.mainTexture = camB.targetTexture;
    }
}
