using UnityEngine;

/// Gestor global del juego. Se encarga de:
///   - Guarda referencias a los dos jugadores.
///   - Provee una función de reinicio que limpia las plataformas activas.

public class GameManager : MonoBehaviour
{

    /// Instancia estática del GameManager para acceso global desde otros scripts.
    public static GameManager Instance { get; private set; }


    //  REFERENCIAS


    [Header("Jugadores")]
    [Tooltip("Arrastra aquí el GameObject del Jugador 1")]
    public PlayerController player1;

    [Tooltip("Arrastra aquí el GameObject del Jugador 2")]
    public PlayerController player2;

    [Header("Posición de spawn")]
    [Tooltip("Punto donde ambos jugadores reaparecen al reiniciar. " +
             "Si se deja vacío, se usan las posiciones iniciales de los jugadores.")]
    public Transform spawnPoint;


    //  POSICIONES INICIALES (se guardan al arrancar)


    private Vector3 player1StartPos;
    private Vector3 player2StartPos;

    void Start()
    {
        // Guarda las posiciones iniciales para poder resetear el nivel
        if (player1 != null) player1StartPos = player1.transform.position;
        if (player2 != null) player2StartPos = player2.transform.position;
    }

    //  RESET DEL NIVEL
    public void ResetGame()
    {
        ResetPlayer(player1, player1StartPos);
        ResetPlayer(player2, player2StartPos);

        Debug.Log("[GameManager] Juego reiniciado.");
    }

  
    void ResetPlayer(PlayerController player, Vector3 originalPosition)
    {
        if (player == null) return;

        // 1. Eliminar plataforma activa del jugador
        player.DestroyActivePlatform();

        // 2. Mover al punto de spawn o posición original
        Vector3 targetPos = spawnPoint != null ? spawnPoint.position : originalPosition;
        player.transform.position = targetPos;

        // 3. Detener física residual
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        if (rb != null) rb.velocity = Vector2.zero;
    }
}
