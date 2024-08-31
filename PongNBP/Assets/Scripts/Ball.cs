using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 30f;
    public AudioSource audioSource;
    public AudioClip ballHitPaddle;
    public AudioClip ballHitWall;
    public AudioClip ballMiss;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }

    private float HitObject(Vector2 ballPos, Vector2 schlaegerPos, float schlaegerHoehe)
    {
        return (ballPos.y - schlaegerPos.y) / schlaegerHoehe;
    }
}
