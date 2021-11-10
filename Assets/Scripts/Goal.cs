using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private GameObject Audio;
    public bool isPlayer1Goal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Audio.SetActive(false);
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (!isPlayer1Goal)
            {
                Audio.SetActive(true);
                Debug.Log("Player 1 Scored ...");
                GameObject.Find("GameManager").GetComponent<GameManager>().Player1Scored();
            }
            else
            {
                Audio.SetActive(true);
                Debug.Log("Player 2 Scored ...");
                GameObject.Find("GameManager").GetComponent<GameManager>().Player2Scored();
            }
        }
    }
}
