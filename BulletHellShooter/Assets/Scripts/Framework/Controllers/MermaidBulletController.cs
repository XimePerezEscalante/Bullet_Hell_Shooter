using UnityEngine;
using System.Collections;

public class MermaidBulletController : MonoBehaviour
{
    private Animator animator;
    /// <summary>
    /// This method is called before the first frame update
    /// </summary>
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
        BulletManager.ChangeMermaidBulletCount(true);
        //BulletManager.mermaidBulletCount += 1;
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
        BulletManager.ChangeMermaidBulletCount(false);
        //BulletManager.mermaidBulletCount -= 1;
        animator.SetTrigger("madeContact");
        Debug.Log("Destroyed bullet");
        Destroy(gameObject);
    }

    public void TriggerAttack(Vector3 currentPosition, Vector3 targetPosition)
    {
        StartCoroutine(Attack(currentPosition, targetPosition));
    }
}
