using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death : MonoBehaviour
{
    private Rigidbody rb;
    public bool onGround = false;

    // Start is called before the first frame update


    private void OnCollisionStay(Collision collision)
    {
        onGround = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        onGround = false;
    }

    private void startPlatform()
    {//помещение сосиски на стартовую позицию
        transform.position = new Vector3(0.0f, 3.0f, 0.0f);
        transform.rotation = Quaternion.LookRotation(new Vector3(20f, 215f, 0f));
        rb.angularVelocity = Vector3.zero;
        rb.velocity = Vector3.zero;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPlatform();
    }

    // Update is called once per frame
    void Update()
    {//проверка на падение
        if(transform.position.y < -1.0f)
        {
            startPlatform();
        }
    }
}
