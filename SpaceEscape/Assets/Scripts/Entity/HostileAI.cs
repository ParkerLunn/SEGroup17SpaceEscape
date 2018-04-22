using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof (Seeker))]
public class HostileAI : MonoBehaviour {

    public Transform target;

    public float updateRate = 2f;

    private Seeker seeker;
    private Rigidbody2D rb;
    private CircleCollider2D cc;
    private CircleCollider2D targetCollider;
    public Path path;

    public float speed = 2f;

    public ForceMode2D fMode;

    public bool isEndOfPath = false;

    public float nextWaypointDistance = 3;
    private int currentWaypoint = 0;
    public float maxSightRange = 5;

    private bool searchingForPlayer = false;

	void Start () {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        cc = GetComponent<CircleCollider2D>();
        targetCollider = target.GetComponent<CircleCollider2D>();
        if(target == null)
        {
            if(!searchingForPlayer)
            {
                searchingForPlayer = true;
                StartCoroutine(SearchForPlayer());
            }
            return;
        }

        seeker.StartPath(transform.position, target.position, OnPathComplete);

        StartCoroutine(UpdatePath());
    }

    IEnumerator SearchForPlayer()
    {
        GameObject result = GameObject.FindGameObjectWithTag("Player");
        if(result == null)
        {
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(SearchForPlayer());
        }
        else
        {
            target = result.transform;
            searchingForPlayer = false;
            StartCoroutine(UpdatePath());
        }
        
        yield return false;
    }

    IEnumerator UpdatePath()
    {
        if (target == null)
        {
            if (!searchingForPlayer)
            {
                searchingForPlayer = true;
                StartCoroutine(SearchForPlayer());
            }
            yield return false;
        }

        seeker.StartPath(transform.position, target.position, OnPathComplete);
        yield return new WaitForSeconds( 1f/updateRate );
        StartCoroutine(UpdatePath());
    }

    public void OnPathComplete (Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
	
	void FixedUpdate () {
        if (cc.IsTouching(targetCollider))
        {
           target.GetComponent<Entity>().Die();
        }
        if (target == null)
        {
            if (!searchingForPlayer)
            {
                searchingForPlayer = true;
                StartCoroutine(SearchForPlayer());
            }
            return;
        }

        if (path == null)
        {
            return;
        }

        if(currentWaypoint >= path.vectorPath.Count)
        {
            if(isEndOfPath)
            {
                return;
            }

            isEndOfPath = true;
            return;
        }
        isEndOfPath = false;

        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        dir *= speed * Time.fixedDeltaTime;

        rb.AddForce(dir, fMode);
        float dist = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);

        if(dist < nextWaypointDistance)
        {
            ++currentWaypoint;
            return;
        }

    }
}
