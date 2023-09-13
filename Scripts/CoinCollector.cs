using UnityEngine;
using UnityEngine.UI;

public class CoinCollector : MonoBehaviour
{
    public Text scoreText;
    private int score = 0;
    public AudioSource[] playerAudioSources; // Array to hold player's audio sources

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            // Play the coin collection sound from a selected audio source on the player
            if (playerAudioSources.Length > 0)
            {
                int randomIndex = Random.Range(0, playerAudioSources.Length); // Choose a random audio source
                AudioSource coinSound = playerAudioSources[randomIndex];
                coinSound.Play();
            }

            // Increase the score and update the score display
            score++;
            scoreText.text = "Score: " + score;

            // Disable the collected coin
            other.gameObject.SetActive(false);
        }
    }
}
