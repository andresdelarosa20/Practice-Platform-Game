using UnityEngine;

public class PlayerPlatform : MonoBehaviour
{
    [Header("Propietario")]
    [Tooltip("Número del jugador que creó esta plataforma (1 o 2). " +
             "Se asigna automáticamente desde PlayerController.HandlePlatformCreation().")]
    public int ownerPlayerNumber = 0;

}

