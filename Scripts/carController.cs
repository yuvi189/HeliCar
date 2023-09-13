using UnityEngine;
using UnityEngine.UI;

public class caController : MonoBehaviour
{
    private AudioSource audioSource;
    float turnSpeed = 100.0f;
    float moveSpeed = 200.0f;
    public Transform PlayerCamera;
    public Vector2 Sensitivities;
    private Vector2 XYRotation;
    private Rigidbody rb;
    // public GameObject helicopter;
    public Text interactionText; // Reference to the UI text element.
    public crCameraChang cameraSwitch; // Reference to the camera switching script.
    public PlayerVisibility playerInvisibility; // Reference to the player visibility script.
    private bool isPlayerInsideCar = false;


    private bool isPlayerNear = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            interactionText.text = "Press E to enter/exit the Car.";
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
            if (isPlayerInsideCar)
            {
                ExitCar();

            }
            else
            {
                EnterCar();

            }
        }
        if (isPlayerInsideCar)
        {
            Vector2 MouseInput = new Vector2
            {
                x = Input.GetAxis("Mouse X"),
                y = Input.GetAxis("Mouse Y")
            };
            XYRotation.x -= MouseInput.y * Sensitivities.y;
            XYRotation.y += MouseInput.x * Sensitivities.x;

            XYRotation.x = Mathf.Clamp(XYRotation.x, -90f, 90f);
            transform.eulerAngles = new Vector3(0f, XYRotation.y, 0f);
            PlayerCamera.localEulerAngles = new Vector3(XYRotation.x, 0f, 0f);
            transform.Translate(0f, 0f, moveSpeed * Input.GetAxis("CarVertical") * Time.deltaTime);
        }
    }
    private void EnterCar()
    {
        audioSource.Play();
        // Set the camera to show the helicopter's view.
        cameraSwitch.SwitchToCarView();

        // Hide the player.
        playerInvisibility.HidePlayer();

        // Update the state.
        isPlayerInsideCar = true;

        // Display instructions for flying the helicopter.
        // helicopterInstructions.ShowInstructions("Press W, A, S, D to fly the helicopter.");
    }

    private void ExitCar()
    {
        audioSource.Stop();
        // Reset the camera to show the player's view.
        cameraSwitch.SwitchToMainView();

        // Show the player.
        playerInvisibility.ShowPlayer();

        // Update the state.
        isPlayerInsideCar = false;

        // Clear any instructions.
        // helicopterInstructions.ClearInstructions();
    }


}
