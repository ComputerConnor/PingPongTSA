using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{

    Vector3 initialPos;
    public string hitter;
    public Transform PlayerPaddle;
    //int rallyScore;

    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
        //rallyScore = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.position = initialPos;

            if (hitter == "bot")
            {
                PlayerPaddle.GetComponent<paddleController>().rallyScore = 0;
            }
        }

        if (collision.transform.CompareTag("Net"))
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.position = initialPos;
            PlayerPaddle.GetComponent<paddleController>().rallyScore = 0;
        }
    }

    /*
    void Update()
    {
        if (hitter == "player")
        {
            rallyScore++;
        }
    }
    */
}
