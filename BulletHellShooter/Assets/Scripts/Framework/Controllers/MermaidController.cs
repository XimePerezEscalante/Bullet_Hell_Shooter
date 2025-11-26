using UnityEngine;
/// <summary>
/// This mermaid controller class will update the player's position, shoot, and receive damage.
/// Standar coding documentation can be found in 
/// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments
/// </summary>
public class MermaidController : MonoBehaviour
{
    public Mermaid mermaid;
    
    /// <summary>
    /// This method is called before the first frame update
    /// </summary>
    void Start()
    {
        mermaid.IsAlive = true;
        mermaid.audioSystem = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSystem>();
    }

    /// <summary>
    /// This method is called once per frame
    /// </summary>
    void Update()
    {
        mermaid.horizontalInput = Input.GetAxis("Horizontal");
        // Obtener velocidad actual dependiendo si la tecla left shift esta siendo presionada 
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? mermaid.slowSpeed : mermaid.normalSpeed;
        // Mover jugador
        transform.Translate(Vector3.right * Time.deltaTime * mermaid.horizontalInput * currentSpeed);

        // Disparar si el jugador presiona la tecla c
        if (Input.GetKeyDown(KeyCode.C))
        {
            Shoot();
        }
        
    }
    /// <summary>
    /// This method is called when the player presses "C" key
    /// </summary>
    public void Shoot()
    {
        // Posicion donde va a spawnear la bala
        Vector3 spawnPosition = transform.position;
        // Rotacion de la bala
        Quaternion spawnRotation = Quaternion.Euler(0, 0, 90);
        // Instancia de la bala
        GameObject bulletInstance = Instantiate(mermaid.bullet, spawnPosition, spawnRotation);
        //mermaid.audioSystem.PlaySFX(mermaid.audioSystem.shoot);
        // Ejecutar el metodo que mandara llamar el ataque
        bulletInstance.GetComponent<MermaidBulletController>().TriggerAttack(spawnPosition, new Vector3(spawnPosition.x, 6.3f, 0));
    }
    /// <summary>
    /// This method is called when the player collides with the boss' bullet's
    /// </summary>
    public void ReceiveDamage()
    {
        // Reproducir SFX "Ouch"
        mermaid.audioSystem.PlaySFX(mermaid.audioSystem.damage);

        // Si la vida es mayor a cero, se sigue restando
        if (mermaid.health > 0)
        {
            mermaid.health -= 0.5f;
        }
        // El personaje muere
        else
        {
            mermaid.IsAlive = false;
            Debug.Log("Game Over");
        }
    }
}
