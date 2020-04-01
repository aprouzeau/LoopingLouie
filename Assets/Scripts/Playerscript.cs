using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerscript : MonoBehaviour
{

    [SerializeField]
    private GameObject SetDePoules;

    [SerializeField]
    private GameObject Catapult;

    [SerializeField]
    private Transform center;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Vector3 unit = center.position - new Vector3(0, 0, 0);
        unit.Normalize();
        Camera.main.transform.position = center.position + new Vector3(0, 30, 0) + 25*unit;
        Camera.main.transform.LookAt((center.position- new Vector3(0, 0, 0))/2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
