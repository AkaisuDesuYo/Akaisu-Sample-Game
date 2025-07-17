using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreUI;
    public GameObject gameOverScreen;
    public GameObject gameStartScreen;
    public Button gameStartButton;
    public bool gameIsDead = false;

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreUI.text = playerScore.ToString();
    }
    public void gameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }
    public void gameStartScreenOff()
    {
        gameStartScreen.SetActive(false);
        gameIsDead = true;
    }
    public void gameStart()
    {
        gameStartButton.onClick.AddListener(gameStartScreenOff);
    }
    public void freezeFrame(int time)
    {
        Time.timeScale = time;
    }
}
