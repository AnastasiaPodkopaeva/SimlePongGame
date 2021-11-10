using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Ball")]
    public GameObject ball;

    [Header("Player 1")]
    public GameObject player1Paddle;
    public GameObject player1Goal;

    [Header("Player 2")]
    public GameObject player2Paddle;
    public GameObject player2Goal;

    [Header("Score UI")]
    public GameObject player1Text;
    public GameObject player2Text;
    
    private int Player1Score;
    private int Player2Score;

    public void Player1Scored()
    {
        Player1Score++;
        if (Player1Score == 15) SceneManager.LoadScene("Player1Win");
        player1Text.GetComponent<TextMeshProUGUI>().text = "Player 1: "+ Player1Score.ToString(); ;
        ResetPosition();
    }

    public void Player2Scored()
    {
        Player2Score++;
        if (Player2Score == 15) SceneManager.LoadScene("Player2Win");
        player2Text.GetComponent<TextMeshProUGUI>().text = "Player 2: " + Player2Score.ToString(); ;
        ResetPosition();
    }

    public void ResetPosition()
    {
        ball.GetComponent<Ball>().RestartGame();
        player1Paddle.GetComponent<Paddle>().Reset();
        player2Paddle.GetComponent<Paddle>().Reset();
    }
}
