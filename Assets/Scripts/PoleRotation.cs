using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoleRotation : NetworkBehaviour
{

    //[SyncVar]
    public bool started;

    [SerializeField]
    private float speed;

    [SerializeField]
    private Plane plane;

    [SerializeField]
    private PlaneRotation pr;

    [SerializeField]
    private PanelScript ps;

    [SerializeField]
    private Playerscript player;

    // Start is called before the first frame update
    void Start()
    {
        //player.Pr = this;
        GameManager.GMInstance.Pr = this;
    }

    // Update is called once per frame
    //[Server]
    void Update()
    {
        if (started)
        {
            transform.Rotate(0, -speed * Time.deltaTime, 0, Space.World);
        }
    }

    [Server]
    public void StartGame()
    {
        Debug.Log("I start the game...");
        
        started = true;
        plane.engenOn = true;
        RpcEngineOn();
        float angleRandom = Random.Range(0, 359);
        transform.Rotate(0, angleRandom, 0, Space.World);
        pr.StartGame();
    }


    [ClientRpc]
    private void RpcEngineOn()
    {
        plane.engenOn = true;
    }

    [ClientRpc]
    private void RpcEngineOff()
    {
        plane.engenOn = false;
    }

    [Server]
    public void Jump()
    {
        pr.Jump();
    }

    [Server]
    public void EndGame()
    {
        started = false;
        plane.engenOn = false;
        RpcEngineOff();
    }
}
