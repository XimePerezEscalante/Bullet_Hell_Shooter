using UnityEngine;
using System.Collections;

public class MermaidBulletController : MonoBehaviour
{
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Attack(Vector3 currentPosition, Vector3 targetPosition)
    {
        transform.position = new Vector3(currentPosition.x,currentPosition.y + 2f, currentPosition.z);

        float timeElapsed = 0;
        float timeToMove = 3;

        while (timeElapsed < timeToMove){
            transform.position = Vector3.Lerp(currentPosition, targetPosition, timeElapsed/timeToMove);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        
        DestroyMermaidBullet();
    }

    private void DestroyMermaidBullet()
    {
        animator.SetTrigger("madeContact");
        Debug.Log("Destroyed bullet");
        Destroy(gameObject);
    }

    public void TriggerAttack(Vector3 currentPosition, Vector3 targetPosition)
    {
        StartCoroutine(Attack(currentPosition, targetPosition));
    }
}
