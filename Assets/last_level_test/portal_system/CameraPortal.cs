using UnityEngine;

public class CameraPortal : MonoBehaviour
{
    public Camera cameraPlayer;
    public Transform localPortal;
    public Transform remotePortal;

    private void Awake() {
    }

    void Update()
    {
        transform.position = localPortal.position + (cameraPlayer.transform.position - remotePortal.transform.position);
        // transform.rotation = cameraPlayer.transform.rotation;

        float portalsAngleDifference = Quaternion.Angle(localPortal.rotation, remotePortal.rotation);
        Quaternion portalRotationDifference = Quaternion.AngleAxis(portalsAngleDifference, Vector3.up);
        Vector3 newCameraDirection = portalRotationDifference * cameraPlayer.transform.forward;
        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
    }
}