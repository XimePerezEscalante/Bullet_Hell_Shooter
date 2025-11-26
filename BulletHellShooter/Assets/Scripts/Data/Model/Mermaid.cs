using UnityEngine;
/// <summary>
/// This mermaid model class contains all the attributes for the player.
/// Standar coding documentation can be found in 
/// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments
/// </summary>
public class Mermaid : MonoBehaviour
{
    // Sistema de audio para reproducir SFX
    public AudioSystem audioSystem;
    // Prefab de bala para disparar
    public GameObject bullet;
    // Vida total
    public float health;
    // Sigue viva
    public bool IsAlive;
    // Input para movimiento
    public float horizontalInput;
    public float normalSpeed;
    public float slowSpeed;
}

