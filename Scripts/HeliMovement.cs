using UnityEngine;

public class HelicopterControls : MonoBehaviour
{
    public float throttleSpeed = 10f;
    public float rotationSpeed = 2f;
    public float mouseSensitivity = 2f;
    public bool isPlayerInside = false;
    [SerializeField] public float rotorSpeed = 10f;
    [SerializeField] public Transform rotorBlades;
    private Rigidbody rb;
    private Vector3 currentRotation;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentRotation = transform.rotation.eulerAngles;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (isPlayerInside)
        {
            // Handle mouse input to change camera rotation
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

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

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                isPlayerInside = true;
            }
        }

            void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                isPlayerInside = false;
            }
        }
    }
}
