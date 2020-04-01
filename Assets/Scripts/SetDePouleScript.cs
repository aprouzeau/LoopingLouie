using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDePouleScript : MonoBehaviour
{

    [SerializeField]
    private GameObject[] poulesTab;

    int firstPouleAlive;

    bool pouleJustHit;

    private PoleRotation pr;
    
    
    // Start is called before the first frame update
    void Start()
    {
        firstPouleAlive = 0;
        pouleJustHit = false;
        foreach (GameObject go in poulesTab)
        {
            Poule p = go.GetComponent<Poule>();
            p.SetPoules = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pouleHit()
    {
        if (!pouleJustHit)
        {
            poulesTab[firstPouleAlive].SetActive(false);
            Vector3 previousPosition = poulesTab[firstPouleAlive].transform.localPosition;
            for (int i = firstPouleAlive + 1; i < poulesTab.Length; i++)
            {
                Vector3 previousPosTemp = poulesTab[i].transform.localPosition;
                //poulesTab[i].transform.localPosition = previousPosition;
                poulesTab[i].GetComponent<Poule>().ChangePosition(previousPosition);
                previousPosition = previousPosTemp;
            }
            firstPouleAlive++;
            //pouleJustHit = true;
        }
    }

    public void planeGone()
    {
        pouleJustHit = false;
    }
}
