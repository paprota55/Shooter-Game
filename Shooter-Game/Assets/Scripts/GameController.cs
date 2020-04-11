using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController gm;


    private void Start()
    {
        if(gm == null)
        {;
            gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        }
    }

    public static void kill(Player player)
    {
        Destroy(player.gameObject);
        gm.respawnPlayer();
    }

    public Transform spawnPoint;
    public Transform playerObject;


    public void respawnPlayer()
    {
        Instantiate(playerObject, spawnPoint.position, spawnPoint.rotation);
        Debug.Log("Spawn player");
    }

}
