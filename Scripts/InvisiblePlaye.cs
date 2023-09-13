using UnityEngine;

public class PlayerVisibility : MonoBehaviour
{
    private Renderer playerRenderer;

    private void Start()
    {
        playerRenderer = GetComponent<Renderer>();
    }

    // Call this method to hide the player.
    public void HidePlayer()
    {
        playerRenderer.enabled = false;
    }

    // Call this method to show the player.
    public void ShowPlayer()
    {
        playerRenderer.enabled = true;
    }
}
