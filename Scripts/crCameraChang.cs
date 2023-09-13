using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crCameraChang : MonoBehaviour
{
    public Camera mainCamera;
    public Camera carCamera;
    // Start is called before the first frame update
    private void Start()
    {
        mainCamera.enabled = true;
        carCamera.enabled = false;
    }

    public void SwitchToMainView()
    {
        mainCamera.enabled = true;
        carCamera.enabled = false;
    }

    public void SwitchToCarView()
    {
        mainCamera.enabled = false;
        carCamera.enabled = true;
    }
}
