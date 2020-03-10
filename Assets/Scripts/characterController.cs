using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{

    public float speed = 10.0F;
    public Rigidbody rb;

    bool aiming;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            aiming = true;
        }

        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            aiming = false;
        }

        if (!aiming)
        {
            transform.Translate(straffe, 0, translation);
        }

        if (Input.GetKeyDown(KeyCode.Space))
            rb.AddForce(new Vector3(0, 3, 0), ForceMode.Impulse);

        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;

    }
}
