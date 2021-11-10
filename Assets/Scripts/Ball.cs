using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private GameObject Audio;
    public float speed=30;
    private Rigidbody2D rb;

    void GoBall()
    {
        float rand = Random.Range(0, 4);
        if (rand < 1) rb.AddForce(new Vector2(20, -15) * speed);
        else if (rand >= 1 && rand < 2) rb.AddForce(new Vector2(-20, -15) * speed);
        else if (rand >= 2 && rand < 3) rb.AddForce(new Vector2(-20, 15) * speed);
        else rb.AddForce(new Vector2(20, 15) * speed);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("GoBall", 2);
    }

    void Update()
    {
    }

    void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    public void RestartGame()
    {
        Reset();
        Invoke("GoBall", 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Audio.SetActive(false);
        if (collision.rigidbody)
        {
            Audio.SetActive(true);
            Vector2 vel;
            vel.x = rb.velocity.x;
            vel.y = (rb.velocity.y/ 2) + (collision.collider.attachedRigidbody.velocity.y/ 3);
            rb.velocity = vel;
        }
    }
    
}

