using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera playerCamera;
    public Camera helicopterCamera;

    private void Start()
    {
        playerCamera.enabled = true;
        helicopterCamera.enabled = false;
    }

    public void SwitchToPlayerView()
    {
        playerCamera.enabled = true;
        helicopterCamera.enabled = false;
    }

    public void SwitchToHelicopterView()
    {
        playerCamera.enabled = false;
        helicopterCamera.enabled = true;
    }
}
