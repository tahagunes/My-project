using UnityEngine;
using UnityEngine.InputSystem;

public class BirdController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private float deathYPosition = -6f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (gameManager == null)
        {
            gameManager = FindAnyObjectByType<GameManager>();
        }
    }

    private void Update()
    {

        if (gameManager != null && gameManager.IsGameOver)
        {
            return; // Oyuncu öldüyse, inputları işleme
        }
        
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Jump();
        }

        if (transform.position.y < deathYPosition)
        {
            if (gameManager != null)
            {
                gameManager.GameOver();
            }
        } 
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameManager != null)
        {
            gameManager.GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ScoreZone"))
        {
            gameManager.AddScore();
        }
    }
}
