using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aiming : MonoBehaviour
{

    public Transform aimTarget;
    float rightBound = 1.6f;
    float leftBound = -1.6f;
    Vector3 initialPos;

    // Start is called before the first frame update
    void Start()
    {
        initialPos = aimTarget.position;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = transform.position + Camera.main.transform.forward * distance * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.A)) {

            if (transform.localPosition.z <= leftBound)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, leftBound);
            }

            else
            {
                transform.localPosition += Vector3.left * 5.0f * Time.deltaTime;
            }
        }

        else if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.D)) {

            if (transform.localPosition.z >= rightBound)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, rightBound);
            }

            else
            {
                transform.localPosition += Vector3.right * 5.0f * Time.deltaTime;
            }
        }
    }
}
