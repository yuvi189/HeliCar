using UnityEngine;
using UnityEngine.UI;

public class button : MonoBehaviour
{
    public Button startButton;

    private void Start()
    {
        // Ensure the button is visible at the start
        startButton.gameObject.SetActive(true);

        // Add an event listener to the button
        startButton.onClick.AddListener(StartGame);
    }

    private void StartGame()
    {
        // This method is called when the button is clicked
        // Hide the button
        startButton.gameObject.SetActive(false);

        // Add your code here to start the game or perform other actions
        // For example, you can load a new scene, enable player control, etc.
    }
}
