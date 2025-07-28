using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Scores")]
    public int player1Score = 0;
    public int player2Score = 0;
    [SerializeField] private int winningScore = 11;

    [Header("UI")]
    public TextMeshProUGUI player1ScoreText;
    public TextMeshProUGUI player2ScoreText;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI replayText;
    private bool isGameEnded = false;

    [Header("Ball")]
    public GameObject ball;

    void Update()
    {
        if (isGameEnded && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void AddPoint(string player)
    {
        if (isGameEnded) return;

        if (player == "Player2")
        {
            player1Score++;
            UpdateScoreUI(player1ScoreText, player1Score);
            if (player1Score >= winningScore)
            {
                EndGame("Player 1 Wins");
            }
        }
        else if (player == "Player1")
        {
            player2Score++;
            UpdateScoreUI(player2ScoreText, player2Score);
            if (player2Score >= winningScore)
            {
                EndGame("Player 2 Wins");
            }
        }
    }
    void UpdateScoreUI(TextMeshProUGUI scoreText, int score)
    {
        scoreText.text = score.ToString();
    }
    private void EndGame(string message)
    {
        isGameEnded = true;
        Destroy(ball);

        winText.text = message;
        winText.gameObject.SetActive(true);

        replayText.text = "Press Spacebar to Play Again!";
        replayText.gameObject.SetActive(true);
    }
}
