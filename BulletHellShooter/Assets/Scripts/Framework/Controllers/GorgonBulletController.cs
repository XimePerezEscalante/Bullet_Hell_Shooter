using UnityEngine;
using System.Collections;
/// <summary>
/// This gorogn bullet controller class will update the bullet's position and detect collisions.
/// Standar coding documentation can be found in 
/// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments
/// </summary>
public class GorgonBulletController : MonoBehaviour
{
    // Objeto de bala para acceder a sus atributos
    [SerializeField] Bullet bullet;
    
    /// <summary>
    /// This method is called before the first frame update
    /// </summary>
    void Start()
    {
        bullet.isAttacking = true;
        StartCoroutine(LinearAttack());
        /*if (TimeManager.Minute == 0 && TimeManager.Second >= 6 && TimeManager.Second <= 36)
        {
            if (bullet.Type == 0) {
                StartCoroutine(LinearAttack());
            }
        }
        if (TimeManager.Minute == 0 && TimeManager.Second >= 37 && TimeManager.Second <= 59)
        {
            if (bullet.Type == 1) {
                StartCoroutine(CircularAttack());
            }
        }*/
    }

    void Update()
    {
    }

    /// <summary>
    /// This method is called when the bullet spawns if the time is between 6 and 36 seconds in game.
    /// </summary>
    public IEnumerator LinearAttack()
    {
        Debug.Log("Attacking");

        // Movimiento continuo basado en el area de juego
        while (transform.position.x < 5.2 && transform.position.x > -1.9 && transform.position.y < 6 && transform.position.y > -4.5)
        {
            // Mover bala horizontalmente
            transform.Translate(Vector3.right * Time.deltaTime * bullet.speed);
             // Angulo Euler actual
            Vector3 currentEuler = transform.rotation.eulerAngles;

            // Modificar eje z
            currentEuler.z += 10 * Time.deltaTime;

            // Modificar rotación
            transform.rotation = Quaternion.Euler(currentEuler);
            yield return null;
        }

        // Se puede volver a disparar
        bullet.isAttacking = false;
        // Destruir bala
        Destroy(gameObject);
        // Disminuir contador de balas del jefe
        BulletManager.ChangeGorgonBulletCount(false);
    }
    /// <summary>
    /// This method is called when the bullet type equals 1.
    /// </summary>
    public IEnumerator CircularAttack()
    {
        float currentAngle = 0f;
        float timer = 8;
        float radius = 2f;


        // Movimiento continuo basado en el area de juego
        while (timer > 0)
        {
            currentAngle += 5f * Time.deltaTime;

            float x = Mathf.Cos(currentAngle * Mathf.Deg2Rad) * radius;
            float y = Mathf.Sin(currentAngle * Mathf.Deg2Rad) * radius;

            transform.position = new Vector3(transform.position.x + x, transform.position.y + y, 0);
            timer -= 1;
            yield return null;
        }

        // Se puede volver a disparar
        bullet.isAttacking = false;
        // Destruir bala
        Destroy(gameObject);
        // Disminuir contador de balas del jefe
        BulletManager.ChangeGorgonBulletCount(false);
    }
    /// <summary>
    /// This method is called when the bullet collides with the player or a player's bullet.
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        // Si colisiona con el jugador
        if (other.CompareTag("Player"))
        {
            Debug.Log("Shot Player");
            // Jugador recibe daño
            other.GetComponent<MermaidController>().ReceiveDamage();
            // Se destruye la bala
            Destroy(gameObject);
        }
        // Si colisiona con una bala del jugador
        else if (other.CompareTag("MermaidBullet"))
        {
            Debug.Log("Player Destroyed Bullet");
            // Se destruye la bala
            Destroy(gameObject);
        }
    }
}
