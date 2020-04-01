using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneRotation : MonoBehaviour
{
    [SerializeField]
    private bool jump;
    bool goingDown;


    [SerializeField]
    private float targetAngle;

    [SerializeField]
    private float UpSpeed;

    [SerializeField]
    private float downSpeed;

    [SerializeField]
    private float StartingAngle;
    float currentAngle; 


    [SerializeField]
    private GameObject pivot;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartGame()
    {
        currentAngle = StartingAngle;
        transform.RotateAround(pivot.transform.position, transform.TransformDirection(Vector3.forward), currentAngle);
        goingDown = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (jump)
        {
            float delta = UpSpeed * Time.deltaTime;
            currentAngle += delta; 
            transform.RotateAround(pivot.transform.position, transform.TransformDirection(Vector3.forward), delta);
            if(currentAngle > targetAngle)
            {
                jump = false;
                goingDown = true;
            }
        }
        if (goingDown)
        {
            float delta = -downSpeed * Time.deltaTime;
            currentAngle += delta;
            transform.RotateAround(pivot.transform.position, transform.TransformDirection(Vector3.forward), delta);
            if (currentAngle < 0)
            {
                goingDown = false;
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            jump = true;
        }
    }
}
