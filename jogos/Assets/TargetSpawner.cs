using UnityEngine;

public class Alvo : MonoBehaviour
{
    [HideInInspector]
    public TargetSpawner.SpawnPoint spawnPoint;

    [HideInInspector]
    public bool moveHorizontal = false;
    [HideInInspector]
    public bool moveVertical = false;
    [HideInInspector]
    public float moveSpeed = 3f;
    [HideInInspector]
    public float moveRange = 5f;
    [HideInInspector]
    public int health = 1;
    [HideInInspector]
    public int pointsValue = 10;

    private Vector3 startPosition;
    private float directionX = 1f;
    private float directionY = 1f;
    private FPSAimController playerShooter; 

    void Start()
    {
        startPosition = transform.position;
        // Procura o script de controle de tiro do jogador para somar pontos
        playerShooter = FindObjectOfType<FPSAimController>();
    }

    void Update()
    {
        // Controle de Movimento
        Vector3 newPos = transform.position;

        if (moveHorizontal)
        {
            newPos.x += directionX * moveSpeed * Time.deltaTime;
            if (Mathf.Abs(newPos.x - startPosition.x) >= moveRange)
                directionX *= -1;
        }

        if (moveVertical)
        {
            newPos.y += directionY * moveSpeed * Time.deltaTime;
            if (Mathf.Abs(newPos.y - startPosition.y) >= moveRange)
                directionY *= -1;
        }

        transform.position = newPos;

        // Controle de Rotação
        transform.Rotate(Vector3.up, 180 * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        // DICA: Como vi na sua hierarquia que o prefab se chama "Bala", 
        // certifique-se de que a Tag do objeto bala na Unity também seja "Bullet" (ou altere o nome abaixo para "Bala")
        if (other.CompareTag("Bala")) 
        {
            health--;

            if (health <= 0)
            {
                if (playerShooter != null)
                    playerShooter.AddScore(pointsValue);

                Destroy(other.gameObject);
                Destroy(gameObject);
            }
            else
            {
                Destroy(other.gameObject);
            }
        }
    }
}