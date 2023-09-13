using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynchronizePlayerWithHelicopter : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform playerTransform;
    public Transform helicopterTransform;
    public bool isInsideHelicopter = false;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // Assuming the player has the "Player" tag.
        helicopterTransform = transform.parent; // Assuming the helicopter is a child of an empty GameObject.

        // Disable the script initially to prevent immediate synchronization.
        enabled = false;
    }

    private void Update()
    {
        if (isInsideHelicopter)
        {
            // Synchronize the player's position with the helicopter.
            playerTransform.position = helicopterTransform.position;
        }
    }

    // This method is called when the player enters the helicopter.
    public void EnterHelicopter()
    {
        isInsideHelicopter = true;
        enabled = true; // Enable the script to start synchronizing.
    }

    // This method is called when the player exits the helicopter.
    public void ExitHelicopter()
    {
        isInsideHelicopter = false;
        enabled = false; // Disable the script to stop synchronizing.
    }
}
