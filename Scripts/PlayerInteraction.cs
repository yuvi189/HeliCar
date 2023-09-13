using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject helicopter;
    public Text interactionText; // Reference to the UI Text object

    private SynchronizePlayerWithHelicopter synchronizationScript;

    private void Start()
    {
        synchronizationScript = helicopter.GetComponent<SynchronizePlayerWithHelicopter>();
        interactionText.text = ""; // Initialize the text as empty
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (synchronizationScript.isInsideHelicopter)
            {
                // Exit the helicopter.
                synchronizationScript.ExitHelicopter();
            }
            else if (IsPlayerNearHelicopter())
            {
                // Enter the helicopter.
                synchronizationScript.EnterHelicopter();
            }
        }

        // Display the message based on player's proximity to the helicopter.
        if (IsPlayerNearHelicopter())
        {
            interactionText.text = "Press E to Enter/Exit";
        }
        else
        {
            interactionText.text = "";
        }
    }

    private bool IsPlayerNearHelicopter()
    {
        // Check if the player is close to the helicopter based on some condition.
        // For example, you can check the distance between the player and the helicopter.
        float distance = Vector3.Distance(transform.position, helicopter.transform.position);
        return distance <= 3f; // Adjust the distance as needed.
    }
}
