using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour
{
    GameObject bullet;
    private Animator animator;
    public bool isLerping = false;
    public int move;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        Debug.Log("Hello");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnEnable()
    {
        TimeManager.OnSecondChanged += TimeCheck;
    }

    public void OnDisable()
    {
        TimeManager.OnMinuteChanged -= TimeCheck;
    }

    private void TimeCheck()
    {
        if(TimeManager.Second == move)//10)
        {
            isLerping = true;
            StartCoroutine(NormalAttackPlayer());
        }
        
    }

    public IEnumerator NormalAttackPlayer()
    {
        //transform.position = new Vector3(1.3f,5f,0);
        // targetPos debe ser la posicion actual de mermaid
        Vector3 targetPos = new Vector3(1.3f,-4.2f,0);

        Vector3 currentPos = transform.position;

        float timeElapsed = 0;
        float timeToMove = 3;

        while (isLerping && timeElapsed < timeToMove){
            transform.position = Vector3.Lerp(currentPos, targetPos, timeElapsed/timeToMove);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        DestroyBullet();
        //StartCoroutine(DestroyBullet());
    }

    /*private IEnumerator DestroyBullet()
    {
        isLerping = false;
        animator.SetTrigger("madeContact");
        yield return new WaitForSeconds(1);
        Debug.Log("Destroyed bullet");
        Destroy(gameObject);
    }
    */

    private void StopBullet()
    {
        Debug.Log("Stopping bullet");
        isLerping = false;
        animator.SetTrigger("madeContact");
    }

    private void DestroyBullet()
    {
        Debug.Log("Destroyed bullet");
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //StartCoroutine(DestroyBullet());
            StopBullet();
            Debug.Log("Shot Player");
            other.GetComponent<MermaidController>().ReceiveDamage();
        }
    }
}
