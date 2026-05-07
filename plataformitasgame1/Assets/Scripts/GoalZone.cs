using UnityEngine;
using UnityEngine.SceneManagement;


public class GoalZone : MonoBehaviour
{
    
    private int playersInGoal = 0;
    public float velocidad = 2f;  
    public float altura = 0.5f;    

    private Vector3 posicionInicial;

    private void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        float nuevaY = posicionInicial.y + Mathf.Sin(Time.time * velocidad) * altura;
        transform.position = new Vector3(posicionInicial.x, nuevaY, posicionInicial.z);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        playersInGoal++;
        Debug.Log($"[GoalZone] Jugadores en meta: {playersInGoal}/2");

        // Victoria
        if (playersInGoal >= 2)
        {
            WinGame();
        }
    }

    
    void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        playersInGoal = Mathf.Max(0, playersInGoal - 1);
        Debug.Log($"[GoalZone] Un jugador salió de la meta. Jugadores en meta: {playersInGoal}/2");
    }

    //  LÓGICA DE VICTORIA
    void WinGame()
    {
        Debug.Log("[GoalZone] ¡Los dos jugadores llegaron! ¡Victoria!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
