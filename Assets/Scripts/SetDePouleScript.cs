using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDePouleScript : MonoBehaviour
{

    [SerializeField]
    private GameObject[] poulesTab;

    Vector3[] InitPos;

    int firstPouleAlive;

    bool pouleJustHit;

    private PoleRotation pr;

    private Playerscript _player;
    public Playerscript Player { set { _player = value; } }
    
    // Start is called before the first frame update
    void Start()
    {
        firstPouleAlive = 0;
        pouleJustHit = false;
        InitPos = new Vector3[poulesTab.Length];
        int i = 0;
        foreach (GameObject go in poulesTab)
        {
            Poule p = go.GetComponent<Poule>();
            p.SetPoules = this;
            InitPos[i] = go.transform.position;
            i++;
        }


        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pouleHitCollider()
    {
        if (!pouleJustHit)
        {
            _player.pouleHit();
        }
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

        if(firstPouleAlive == poulesTab.Length)
        {
            _player.Lost();
        }
    }

    public void planeGone()
    {
        pouleJustHit = false;
    }

    public void InitBack()
    {
        for (int i=0; i<poulesTab.Length; i++)
        {
            poulesTab[i].SetActive(true);
            poulesTab[i].transform.position = InitPos[i];
        }

        firstPouleAlive = 0;

    }

}
