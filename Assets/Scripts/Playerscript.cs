using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerscript : NetworkBehaviour
{

    [SerializeField]
    private GameObject SetDePoules;

    [SerializeField]
    private GameObject Catapult;

    [SerializeField]
    private Transform center;


    private PoleRotation _pr;
    public PoleRotation Pr { set { _pr = value; } }

    private Playerscript _player;
    public Playerscript Player { set { _player = value; } }


    GameManager GM;


    // Start is called before the first frame update
    void Start()
    {
        if (isLocalPlayer)
        {
            Vector3 unit = center.position - new Vector3(0, 0, 0);
            unit.Normalize();
            Camera.main.transform.position = center.position + new Vector3(0, 30, 0) + 25 * unit;
            Camera.main.transform.LookAt((center.position - new Vector3(0, 0, 0)) / 2);
            GameManager.GMInstance.Player = this;

            GM = GameManager.GMInstance;
        }

        SetDePoules.GetComponent<SetDePouleScript>().Player = this;
        Catapult.GetComponent<CatapultScript>().Player = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Lost()
    {
        //_pr.LooseGame();
    }

    public void Restart()
    {
        SetDePoules.GetComponent<SetDePouleScript>().InitBack();
    }


    public void StartGame()
    {
        CmdStart();
    }

    [Command]
    private void CmdStart()
    {
        GM.StartGame();
    }



}
