using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Seeker))]
public class ArtificialIntelligence : MonoBehaviour
{
    public Transform player;

    public float updateClock = 2f;
    public float moveDistance = 3;
    int currentPoint = 0;

    public float speed = 300f;
    public ForceMode2D forceMode;

    Seeker enemy;
    Rigidbody2D body;

    public Path path;

    [HideInInspector]
    public bool pathIsEnded = false;

    bool noPlayer = false;

    void Start()
    {
        enemy = GetComponent<Seeker>();
        body = GetComponent<Rigidbody2D>();

        if(player == null)
        {
            if(!noPlayer)
            {
                noPlayer = true;
                StartCoroutine(PlayerSearch());
            }
            return;
        }

        enemy.StartPath(transform.position,player.position, OnPathComplete);

        StartCoroutine(UpdatePath());
    }

    IEnumerator PlayerSearch()
    {
        GameObject newPlayer = GameObject.FindGameObjectWithTag("Player");
        if (newPlayer == null)
        {
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(PlayerSearch());
        }
        else
        {
            player = newPlayer.transform;
            noPlayer = false;
            StartCoroutine(UpdatePath());
        }
    }

    public void OnPathComplete(Path pathP)
    {
        Debug.Log("Any errors tp path" + pathP.error);

        if (!pathP.error)
        {
            path = pathP;
            currentPoint = 0;
        }
    }

    IEnumerator UpdatePath()
    {
        if (player == null)
        {
            if (!noPlayer)
            {
                noPlayer = !noPlayer;
                StartCoroutine(PlayerSearch());
            }
        }
        enemy.StartPath(transform.position, player.position, OnPathComplete);
        yield return new WaitForSeconds(1f / updateClock);
        StartCoroutine(UpdatePath());
    }

    void FixedUpdate()
    {
        if (player == null)
        {
            if (!noPlayer)
            {
                noPlayer = !noPlayer;
                StartCoroutine(PlayerSearch());
            }
            return;
        }

        if(path == null)
        {
            return;
        }

        if (currentPoint >= path.vectorPath.Count)
        {
            if(pathIsEnded)
            {
                return;
            }

            Debug.Log("End of path");
            pathIsEnded = true;
            return;
        }

        pathIsEnded = false;

        Vector3 direction = (path.vectorPath[currentPoint] - transform.position).normalized;
        direction *= speed * Time.fixedDeltaTime;

        body.AddForce(direction, forceMode);

        if(Vector3.Distance(transform.position, path.vectorPath[currentPoint]) < moveDistance)
        {
            currentPoint++;
        }
    }
}
