using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoleRotation : MonoBehaviour
{

    [SerializeField]
    private bool started;

    [SerializeField]
    private float speed;

    [SerializeField]
    private Plane plane;

    [SerializeField]
    private PlaneRotation pr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            transform.Rotate(0, -speed * Time.deltaTime, 0, Space.World);
        }
    }

    public void StartGame()
    {
        started = true;
        plane.engenOn = true;
        float angleRandom = Random.Range(0, 359);
        transform.Rotate(0, angleRandom, 0, Space.World);
        pr.StartGame();
    }
}
