using UnityEngine;

public class GoalTriggerScript : MonoBehaviour
{
    public string scoringPlayer;
    public GameManager gameManager;
    public AudioSource goalAudio;
    public GoalLightsFlashing lightsFlashing;
    public Transform ballSpawnPoint;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Ball")) return;

        gameManager.AddPoint(scoringPlayer);

        goalAudio.Play();

        if (scoringPlayer == "Player1")
        {
            lightsFlashing.Flash(lightsFlashing.player2Color);
        }
        else
        {
            lightsFlashing.Flash(lightsFlashing.player1Color);
        }

        Ball ball = other.GetComponent<Ball>();
        if (ball != null)
        {
            ball.ResetBall(ballSpawnPoint.position);
        }


    }
}
