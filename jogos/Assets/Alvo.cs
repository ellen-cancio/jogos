using UnityEngine;

public class Alvo : MonoBehaviour
{
   
    private GameManager gameManager; 
    public int pontos = 10;

    void Start()
    {
        
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.GetComponent<Bala>() != null)
        {
            
            if (gameManager != null) 
            {
                gameManager.AdicionarScore(pontos);
            }
            
            Destroy(gameObject); 
        }
    }
}