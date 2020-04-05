using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerscript : NetworkBehaviour
{

    [SerializeField]
    private GameObject SetDePoules;

    SetDePouleScript sdp;

    [SerializeField]
    private GameObject Catapult;

    [SerializeField]
    private Transform center;

    [SerializeField]
    private PoleRotation _pr;
    public PoleRotation Pr { set { _pr = value; } }

    private Playerscript _player;
    public Playerscript Player { set { _player = value; } }


    GameManager GM;

    bool lost;


    // Start is called before the first frame update
    void Start()
    {

        lost = false;
        if (isLocalPlayer)
        {
            Vector3 unit = center.position - new Vector3(0, 0, 0);
            unit.Normalize();
            Camera.main.transform.position = center.position + new Vector3(0, 30, 0) + 25 * unit;
            Camera.main.transform.LookAt((center.position - new Vector3(0, 0, 0)) / 2);
            GameManager.GMInstance.Player = this;

            
        }
        GM = GameManager.GMInstance;
        SetDePoules.GetComponent<SetDePouleScript>().Player = this;
        Catapult.GetComponent<CatapultScript>().Player = this;

        sdp = SetDePoules.GetComponent<SetDePouleScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Lost()
    {
        //_pr.LooseGame();
        lost = true;
        CmdEndGame();
    }

    [Command]
    private void CmdEndGame()
    {
        _pr.EndGame();
        RpcEndGame();
    }

    [ClientRpc]
    private void RpcEndGame()
    {
        if (!isLocalPlayer)
        {
            GM.WinGame();
        }
        else
        {
            GM.LooseGame();
        }
    }

    public void Restart()
    {
        SetDePoules.GetComponent<SetDePouleScript>().InitBack();
    }

    public void pouleHit()
    {
        if (isLocalPlayer)
        {
            CmdPouleJustHit();
        }
    }

    [Command]
    private void CmdPouleJustHit()
    {
        sendHitMessage();
    }

    [Server]
    private void sendHitMessage()
    {
        RpcPouleHit();
    }

    [ClientRpc]
    private void RpcPouleHit()
    {
        sdp.pouleHit();
    }

    public void StartGame()
    {
        if (isLocalPlayer)
        {
            Debug.Log("StartGame on Player");
            CmdStart();
        }
        else
        {
            Debug.Log("Not local Player...");
        }
    }

    [Command]
    private void CmdStart()
    {
        Debug.Log("PlayerScript sent a command to click on start...");
        startGameOnServer();
    }


    [Server]
    private void startGameOnServer()
    {
        //GM.StartGame();
        _pr.StartGame();
    }

    public void Hit()
    {
        if (isLocalPlayer)
        {
            CmdJump();
        }
    }

    [Command]
    private void CmdJump()
    {
        //GM.PlaneJump();
        PlaneJump();
    }

    [Server]
    private void PlaneJump()
    {
        _pr.Jump();
    }



}
