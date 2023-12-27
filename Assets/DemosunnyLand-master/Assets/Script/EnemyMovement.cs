using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject pointa;
    public GameObject pointb;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentPoint;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
       anim = GetComponent<Animator>();
       currentPoint = pointb.transform;
       anim.SetBool("Run", true);
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position + transform.position;
        if(currentPoint == pointb.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else{
            rb.velocity = new Vector2(-speed, 0);
        }
       if(Vector2.Distance(transform.position, currentPoint.position)< 0.5f && currentPoint == pointb.transform)
       {
        flip();
        currentPoint = pointa.transform;
       }
       if(Vector2.Distance(transform.position, currentPoint.position)< 0.5f && currentPoint == pointa.transform)
       {
        flip();
        currentPoint = pointb.transform;
       }
       

    }
    private void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointa.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointb.transform.position, 0.5f);
        Gizmos.DrawLine(pointa.transform.position, pointb.transform.position);
    }
}
