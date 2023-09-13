using UnityEngine;
using UnityEngine.UI;

public class HelicopterInteraction : MonoBehaviour
{
    private AudioSource audioSource;
    private float rotorSpeed = 10f;
    [SerializeField] public Transform rotor;
    public float mouseSensitivity = 2f;
    private Vector3 currentRotation;
    public float throttleSpeed = 10f;
    public float rotationSpeed = 2f;
    private Rigidbody rb;
    // public GameObject helicopter;
    public Text interactionText; // Reference to the UI text element.
    public CameraSwitch cameraSwitch; // Reference to the camera switching script.
    public PlayerVisibility playerVisibility; // Reference to the player visibility script.
    private bool isPlayerInsideHelicopter = false;


    private bool isPlayerNear = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        currentRotation = transform.rotation.eulerAngles;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            interactionText.text = "Press E to enter/exit the helicopter.";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            interactionText.text = "";
        }
    }


    private void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            if (isPlayerInsideHelicopter)
            {
                ExitHelicopter();
                // Player is inside the helicopter, so exit.
                // synchronizationScript.ExitHelicopter();

            }
            else
            {
                EnterHelicopter();
                // Player is outside the helicopter, so enter.
                // synchronizationScript.EnterHelicopter();

            }
        }
        if (isPlayerInsideHelicopter)
        {
            rotor.Rotate(Vector3.up * throttleSpeed * rotorSpeed);
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = (Input.GetAxis("Mouse Y"));

            currentRotation.x -= mouseY * mouseSensitivity;
            currentRotation.y += mouseX * mouseSensitivity;

            currentRotation.x = Mathf.Clamp(currentRotation.x, -80f, 80f); // Clamp the vertical rotation

            // Apply rotation to the helicopter
            transform.rotation = Quaternion.Euler(currentRotation);

            // Handle helicopter controls
            float throttle = Input.GetAxis("HelicopterVertical") * throttleSpeed;
            float rotationInput = Input.GetAxis("HelicopterHorizontal") * rotationSpeed;

            // Apply forces to the helicopter based on control inputs
            Vector3 forwardForce = transform.forward * throttle;
            Vector3 rotationTorque = Vector3.up * rotationInput;

            rb.AddForce(forwardForce);
            rb.AddTorque(rotationTorque);
        }
    }
    private void EnterHelicopter()
    {
        audioSource.Play();
        // Set the camera to show the helicopter's view.
        cameraSwitch.SwitchToHelicopterView();

        // Hide the player.
        playerVisibility.HidePlayer();

        // Update the state.
        isPlayerInsideHelicopter = true;

        // Display instructions for flying the helicopter.
        // helicopterInstructions.ShowInstructions("Press W, A, S, D to fly the helicopter.");
    }

    private void ExitHelicopter()
    {
        audioSource.Stop();
        // Reset the camera to show the player's view.
        cameraSwitch.SwitchToPlayerView();

        // Show the player.
        playerVisibility.ShowPlayer();

        // Update the state.
        isPlayerInsideHelicopter = false;

        // Clear any instructions.
        // helicopterInstructions.ClearInstructions();
    }


}
