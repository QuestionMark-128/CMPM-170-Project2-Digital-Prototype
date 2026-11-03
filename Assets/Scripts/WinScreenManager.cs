
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WinScreenManager : MonoBehaviour
{
    public GameObject winPanel;
    //public TMP_Text winnerText;
    public TMP_Text scoreText;

    public float timeRemaining = 180f;
    private bool gameEnded = false;

    void Start()
    {
        winPanel.SetActive(false);
    }

    void Update()
    {
        if (gameEnded)
        {
            return;
        }

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0)
        {
            gameEnded = true;
            ShowWinScreen(0);
        }
    }

    public void ShowWinScreen(int score)
    {
        gameEnded = true;
        winPanel.SetActive(true);
        //winnerText.text = "Player 1 Wins!";
        scoreText.text = "Stamps Collected: " + score;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
}
