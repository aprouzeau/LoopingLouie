using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poule : MonoBehaviour
{

    private SetDePouleScript _setDePoule;

    public SetDePouleScript SetPoules { get { return _setDePoule; } set { _setDePoule = value; } }

    private bool isMoving;
    private Vector3 targetPosition;

    [SerializeField]
    private float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            Vector3 dir = targetPosition - this.transform.localPosition;
            dir.Normalize();
            this.transform.localPosition += dir * speed * Time.deltaTime;
            if(Vector3.Distance(targetPosition, this.transform.localPosition)< 0.05)
            {
                isMoving = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Poule Hit!!!!");
        _setDePoule.pouleHit();
    }

    private void OnTriggerExit(Collider other)
    {
        _setDePoule.planeGone();
    }

    public void ChangePosition(Vector3 target)
    {
        targetPosition = target;
        isMoving = true;
    }
}
