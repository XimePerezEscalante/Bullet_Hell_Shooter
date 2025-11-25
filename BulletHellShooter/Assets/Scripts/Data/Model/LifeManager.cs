using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public GameObject[] Life;
    private static Animator animator;
    public Mermaid mermaid;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //animator = Life.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (mermaid.health == 2.5) {
            animator = Life[2].GetComponent<Animator>();
            animator.SetTrigger("Half");
        }
        else if (mermaid.health == 2) {
            Destroy(Life[2].gameObject);
        }
        else if (mermaid.health == 1.5)
        {
            animator = Life[1].GetComponent<Animator>();
            animator.SetTrigger("Half");
        }
        else if (mermaid.health == 1) {
            Destroy(Life[1].gameObject);
        }
        else if (mermaid.health == 0.5)
        {
            animator = Life[0].GetComponent<Animator>();
            animator.SetTrigger("Half");
        }
        else if (mermaid.health == 0)
        {
            Destroy(Life[0].gameObject);
        }
    }

    public void DecreaseHealth(bool empty)
    {
        /*if (health == 2.5f)
        {
            animatorLife3.SetTrigger("Half");
        }
        else if (health == 2)
        {
            animatorLife3.SetTrigger("Empty");
            Destroy(gameObject.Life3);
        }
        else if (health == 1.5f)
        {
            animatorLife2.SetTrigger("Half");
        }
        else if (health == 1)
        {
            animatorLife2.SetTrigger("Empty");
            Destroy(gameObject.Life2);
        }
        else if (health == 0.5f)
        {
            animatorLife1.SetTrigger("Half");
        }
        else if (health == 0)
        {
            animatorLife1.SetTrigger("Empty");
            Destroy(gameObject.Life1);
        }*/
        /*if (!empty)
        {
            animator.SetTrigger("Half");
        }
        else
        {
            Debug.Log("Destroying game object");
            animator.SetTrigger("Empty");
            //Destroy(gameObject);
        }*/
    }
}
