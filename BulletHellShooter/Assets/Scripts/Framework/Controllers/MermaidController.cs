using UnityEngine;

public class MermaidController : MonoBehaviour
{
    public Mermaid mermaid;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mermaid.audioSystem = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        mermaid.horizontalInput = Input.GetAxis("Horizontal");
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? mermaid.slowSpeed : mermaid.normalSpeed;
        transform.Translate(Vector3.right * Time.deltaTime * mermaid.horizontalInput * currentSpeed);

        if (Input.GetKey(KeyCode.C))
        {
            Shoot();
        }
        
    }

    public void Shoot()
    {
        Vector3 spawnPosition = transform.position;
        Quaternion spawnRotation = Quaternion.Euler(0, 0, 90);
        GameObject bulletInstance = Instantiate(mermaid.bullet, spawnPosition, spawnRotation);
        //mermaid.audioSystem.PlaySFX(mermaid.audioSystem.shoot);
        bulletInstance.GetComponent<MermaidBulletController>().TriggerAttack(spawnPosition, new Vector3(spawnPosition.x, 6.3f, 0));
    }

    public void ReceiveDamage()
    {
        mermaid.audioSystem.PlaySFX(mermaid.audioSystem.damage);
        if (mermaid.health > 0)
        {
            mermaid.health -= 0.5f;
        }
        else
        {
            mermaid.isAlive = false;
            Debug.Log("Game Over");
        }
    }
}
