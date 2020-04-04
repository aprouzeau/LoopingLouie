using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapultScript : NetworkBehaviour
{

    [SerializeField]
    private GameObject pivot;

    bool jump;
    bool goingDown;

    [SerializeField]
    private float currentAngle;


    [SerializeField]
    private float targetAngle;

    [SerializeField]
    private float UpSpeed;

    private Playerscript _player;
    public Playerscript Player { set { _player = value; } }


    // Start is called before the first frame update
    void Start()
    {
        jump = false;
        goingDown = false;
        currentAngle = 0;
    }

    // Update is called once per frame
    [Client]
    void Update()
    {




        if (jump)
        {
            float delta = UpSpeed * Time.deltaTime;
            currentAngle += delta;
            transform.RotateAround(pivot.transform.position, transform.TransformDirection(Vector3.up), delta);
            if (currentAngle > targetAngle)
            {
                jump = false;
                goingDown = true;
            }
        }
        if (goingDown)
        {
            float delta = -UpSpeed * Time.deltaTime;
            currentAngle += delta;
            transform.RotateAround(pivot.transform.position, transform.TransformDirection(Vector3.up), delta);
            if (currentAngle < 0)
            {
                goingDown = false;
            }
        }



        if (_player.isLocalPlayer && Input.GetKey(KeyCode.Space))
        {
            jump = true;
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Plane Hit...");
        PlaneRotation pr = other.GetComponent<WheelScript>().Pr;
        pr.Jump();
    }

}
