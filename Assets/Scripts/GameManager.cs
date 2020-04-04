using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    [SerializeField]
    private Playerscript player;
    public Playerscript Player { set { player = value; } }
    

    [SerializeField]
    private PoleRotation pr;
    public PoleRotation Pr { set { pr = value; } }

    [SerializeField]
    private PanelScript ps;

    private static GameManager _instance;

    public static GameManager GMInstance { get { return _instance; } }

    [SerializeField]
    private NetworkManagerLL nm;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickOnStart()
    {
        Debug.Log("ClickOnStart");
        player.StartGame();
        
    }

    /*public void StartGame()
    {

        //float angleRandom = Random.Range(0, 359);
        //transform.Rotate(0, angleRandom, 0, Space.World);
        //nm.StartGame();
        if (hasAuthority)
        {
            CmdStartGame();
        }
        else
        {
            Debug.Log("Does not have authority...");
        }
        ps.ShowStop();
    }*/

    public void StartAgain()
    {
        player.Restart();
        ps.hideEverything();
        //ps.gameObject.SetActive(false);
        //StartGame();
    }

    public void StopGame()
    {
        //started = false;
        //plane.engenOn = false;
        ps.ShowStart();
    }

    public void LooseGame()
    {
        ps.displayLooserText();
        ps.gameObject.SetActive(true);
        StopGame();
    }

    /*[Server]
    public void StartGame()
    {
        Debug.Log("Start Game");
        pr.StartGame();
    }

    [Server]
    public void PlaneJump()
    {
        pr.Jump();
    }*/
}
