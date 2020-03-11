using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{

    public float speed = 3.0F;
    float force = 6;
    Animator animator;
    public Transform Ball;
    public Transform AIScaling;
    public Transform PlayerPaddle;

    public Transform[] targets;

    Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        animator = AIScaling.GetComponent<Animator>();
        targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        targetPosition.x = Ball.position.x;
        targetPosition.z = Ball.position.z;
        targetPosition.y = Ball.position.y;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    Vector3 PickTarget()
    {
        int randomValue = Random.Range(0, targets.Length);
        return targets[randomValue].position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Vector3 dir = PickTarget() - transform.position;
            other.GetComponent<Rigidbody>().velocity = dir.normalized *  force + new Vector3(0, Random.Range(3.2f,3.7f), 0);
            Ball.GetComponent<ball>().hitter = "bot";
        }
    }
}
