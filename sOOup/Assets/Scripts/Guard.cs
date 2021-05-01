using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    // Start is called before the first frame update
  

    public enum BehaviorState {idle,Chase};

    public LayerMask targetMask;
    public LayerMask obstacleMask;
    public bool seePlayer;

    public List<Transform> visableTargets = new List<Transform>();

    public float viewRadius;
    [Range(0,360)]
    public float viewAngle;
    public BehaviorState currentBehaviorState;
    public Transform playerTransform;
    public float speed;
    Rigidbody2D rb;

    void Start()
    {
        StartCoroutine("FindTargetsWithDelay",0.2f);
        currentBehaviorState = BehaviorState.idle;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        seePlayer = false; 

    }
    IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisableTargets();
        }
    }

    void FindVisableTargets()
    {
        visableTargets.Clear();
        Collider2D[] targetsInViewRadius = Physics2D.OverlapCircleAll(transform.position, viewRadius, targetMask);
        for(int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if (Vector3.Angle(transform.right,dirToTarget) < viewAngle / 2)
            {
                float dstToTarget = Vector3.Distance(transform.position, target.position);
                if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
                {
                    visableTargets.Add(target);
                    seePlayer = true;
                }

            }
        }

    }

    public Vector2 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees -= transform.eulerAngles.z;
        }
        return new Vector2(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }




    // Update is called once per frame
    void Update()
    {

        if(StealSoup.GuardIsPissed == true)
        {
            currentBehaviorState = BehaviorState.Chase;
        }

        switch (currentBehaviorState)
        {
            case BehaviorState.idle:
                
                if(seePlayer == true)
                {
                    currentBehaviorState = BehaviorState.Chase;
                }

            break;

            case BehaviorState.Chase:

                Vector2 PlayerMove = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);


                Vector3 vectorToTarget = playerTransform.position - transform.position;
                float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
                Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);

                rb.MovePosition(PlayerMove);


              break;


        }
    }
}
