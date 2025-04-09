using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{   
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    public Player Player;


    private int score;
    private void Awake()
    {
        Player  = FindFirstObjectByType<Player>();
        Pause();
        gameOver.SetActive(false);

    }
    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1.0f;
        Player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        Player.enabled = false;
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        
        gameOver.SetActive(true);
        playButton.SetActive(true);
        
        Pause();
    }
}
