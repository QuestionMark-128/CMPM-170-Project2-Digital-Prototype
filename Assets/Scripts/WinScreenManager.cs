
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WinScreenManager : MonoBehaviour
{
    public GameObject winPanel;
    //public TMP_Text winnerText;
    public TMP_Text scoreText;

    void Start()
    {
        winPanel.SetActive(false);
    }

    public void ShowWinScreen(int score)
    {
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
