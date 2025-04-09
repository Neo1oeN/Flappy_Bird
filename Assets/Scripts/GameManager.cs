using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{   
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    private Player player;


    private int score;
    private void Awake()
    {
        player  = FindFirstObjectByType<Player>();
        Pause();

    }
    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1.0f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        Pause();
        gameOver.SetActive(true);
        playButton.SetActive(true);
    }
}
