using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class paddleController : MonoBehaviour
{
    public Transform Scaling;
    public Transform AIPaddle;
    public Transform aimTarget;
    public Transform Player;
    public Transform Ball;
    float force = 6;
    Animator animator;
    public int rallyScore;
    [SerializeField] Text rallyScoreText;

    bool aiming;
    Vector3 initialPos;

    private void Start()
    {
        animator = Scaling.GetComponent<Animator>();
        initialPos = aimTarget.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            animator.Play("forehand");
        }

        
        float h = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            aiming = true;
        }

        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            aiming = false;
        }

        if (aiming) 
        {
            aimTarget.Translate(new Vector3(0, 0, h) * 5f * Time.deltaTime);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Vector3 dir = aimTarget.position - transform.position;
            other.GetComponent<Rigidbody>().velocity = dir.normalized * force + new Vector3(0, Random.Range(3.0f, 3.3f),0);
            Ball.GetComponent<ball>().hitter = "player";
            aimTarget.position = initialPos;
            rallyScore++;
            rallyScoreText.text = "" + rallyScore;
        }
    }

}
