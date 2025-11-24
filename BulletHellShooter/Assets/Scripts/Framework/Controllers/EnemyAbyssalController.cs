using UnityEngine;
using System.Collections;

public class EnemyAbyssalController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
        if(TimeManager.Second == 10)
        {
            StartCoroutine(MoveTowardsPlayer());
        }
        
    }
    private IEnumerator MoveTowardsPlayer()
    {
        transform.position = new Vector3(10f,0f,0);
        Vector3 targetPos = new Vector3(-4,0f,0);

        Vector3 currentPos = transform.position;

        float timeElapsed = 0;
        float timeToMove = 3;

        while(timeElapsed < timeToMove){
            transform.position = Vector3.Lerp(currentPos, targetPos, timeElapsed/timeToMove);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

    }
}
