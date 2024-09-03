using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public float speed = 30f;

    private int scoreSpieler1;
    private int scoreSpieler2;

    public Text txtSpieler1;
    public Text txtSpieler2;

    public AudioSource audioSource;
    public AudioClip ballHitPaddle;
    public AudioClip ballHitWall;
    public AudioClip ballMiss;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Spieler1")
        {
            // Aufprall mit Spieler
            float y = HitObject(transform.position, collision.transform.position,
                collision.collider.bounds.size.y);
            // Richtung berechnen
            Vector2 dir = new Vector2(1, y);
            // Richtungsvector auf die Physik anwenden
            GetComponent<Rigidbody2D>().velocity = dir * speed;
            // Audio
            audioSource.PlayOneShot(ballHitPaddle);
        }
        if (collision.gameObject.name == "Spieler2")
        {
            // Aufprall mit Spieler
            float y = HitObject(transform.position, collision.transform.position,
                collision.collider.bounds.size.y);
            // Richtung berechnen
            Vector2 dir = new Vector2(-1, y);
            // Richtungsvector auf die Physik anwenden
            GetComponent<Rigidbody2D>().velocity = dir * speed;
            // Audio
            audioSource.PlayOneShot(ballHitPaddle);
        }
        if (collision.gameObject.CompareTag("WallTopBottom"))
        {
            audioSource.PlayOneShot(ballHitWall);
        }
        if (collision.gameObject.name == "WandVertikalLinks")
        {
            audioSource.PlayOneShot(ballMiss);
            scoreSpieler1++;
            txtSpieler1.text = scoreSpieler1.ToString();
            Restart();
        }
        if (collision.gameObject.name == "WandVertikalRechts")
        {
            audioSource.PlayOneShot(ballMiss);
            scoreSpieler2++;
            txtSpieler2.text = scoreSpieler2.ToString();
            Restart();
        }
        Debug.Log(scoreSpieler1 + " : " + scoreSpieler2);
    }

    private float HitObject(Vector2 ballPos, Vector2 schlaegerPos, float schlaegerHoehe)
    {
        return (ballPos.y - schlaegerPos.y) / schlaegerHoehe;
    }

    private void Restart()
    {
        Vector2 startPosition = new Vector2(2f, 5f);
    }
}
