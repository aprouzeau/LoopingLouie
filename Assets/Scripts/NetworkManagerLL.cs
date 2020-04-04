using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;


[AddComponentMenu("")]
public class NetworkManagerLL : NetworkManager
{
    [SerializeField]
    private Transform[] spawnPosition;


    [SerializeField]
    private GameManager gm;

    GameObject rotatingPole;

    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        //base.OnServerAddPlayer(conn);

        Transform start = spawnPosition[numPlayers];

        GameObject player = Instantiate(playerPrefab, start.position, start.rotation);

        NetworkServer.AddPlayerForConnection(conn, player);

        if(numPlayers == 1)
        {
            rotatingPole = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "RotatingBase"));
            NetworkServer.Spawn(rotatingPole);
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

    public void StartGame()
    {
        //float angleRandom = Random.Range(0, 359);
        //CmdStartGame();
    }

    

}
