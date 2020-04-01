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


    private PoleRotation _pr;
    public PoleRotation Pr { set { _pr = value; } }
    
    
    // Start is called before the first frame update
    void Start()
    {
        Vector3 unit = center.position - new Vector3(0, 0, 0);
        unit.Normalize();
        Camera.main.transform.position = center.position + new Vector3(0, 30, 0) + 25*unit;
        Camera.main.transform.LookAt((center.position- new Vector3(0, 0, 0))/2);
        SetDePoules.GetComponent<SetDePouleScript>().Player = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Lost()
    {
        _pr.LooseGame();
    }

    public void Restart()
    {
        SetDePoules.GetComponent<SetDePouleScript>().InitBack();
    }

}
