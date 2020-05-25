using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Seeker))]
public class ArtificialIntelligence : MonoBehaviour
{
    public Transform player; /// it is path target

    public float updateClock = 2f; ///time to update path how much per second
    public float moveDistance = 3; ///distance to next waypoint
    int currentPoint = 0; ///Waypoint where we currently moving

    ///AI speed
    public float speed = 300f;
    ///Force or impulse force
    public ForceMode2D forceMode;

    Seeker enemy;
    Rigidbody2D body;

    ///Calculated path
    public Path path;

    ///Check if paths is ended
    [HideInInspector]
    public bool pathIsEnded = false;

    ///Check if player is on scene
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

        ///Start a new path to the target and return result to the OnPathComplete
        enemy.StartPath(transform.position,player.position, OnPathComplete);

        StartCoroutine(UpdatePath());
    }

    ///searching player object to set end point of path and start updating path
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

    ///Check if we have problem in path
    public void OnPathComplete(Path pathP)
    {
        Debug.Log("Any errors tp path" + pathP.error);

        if (!pathP.error)
        {
            path = pathP;
            /// Reset the waypoint counter so that we start to move towards the first point in the path
            currentPoint = 0;
        }
    }


    IEnumerator UpdatePath()
    {
        if (player == null)
        {
            if (!noPlayer)
            {
                noPlayer = true;
                StartCoroutine(PlayerSearch());
            }
        }
        else
        {
            /// Start a new path to the targetPosition, call the OnPathComplete function
            /// when the path has been calculated (which may take a few frames depending on the complexity)
            enemy.StartPath(transform.position, player.position, OnPathComplete);
            yield return new WaitForSeconds(1f / updateClock);
            StartCoroutine(UpdatePath());
        }
    }

    void FixedUpdate()
    {
        if (player == null)
        {
            if (!noPlayer)
            {
                noPlayer = true;
                StartCoroutine(PlayerSearch());
            }
            return;
        }

        if(path == null)
        {
            /// We have no path to follow yet, so don't do anything
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

        ///Add force to body in direction where is target

        /// Direction to the next waypoint
        /// Normalize it so that it has a length of 1 world unit
        Vector3 direction = (path.vectorPath[currentPoint] - transform.position).normalized;

        /// Multiply the direction by our desired speed to get a velocity
        direction *= speed * Time.fixedDeltaTime;


        body.AddForce(direction, forceMode);


        if(Vector3.Distance(transform.position, path.vectorPath[currentPoint]) < moveDistance)
        {
            currentPoint++;
        }
    }
}
