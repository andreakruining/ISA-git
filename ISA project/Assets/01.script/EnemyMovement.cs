using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public enum State { Patrol, Chase }
    public State activeState;
    public NavMeshAgent agent;

    public Transform[] wayPoints;
    public int speed; 
    private int waypointIndex;
    private float dist;

    public float chaseDistance = 5f;
    public Transform Player;


    // Start is called before the first frame update
    void Start()
    {
       waypointIndex = 0;
       transform.LookAt(wayPoints[waypointIndex].position); 
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(transform.position, wayPoints[waypointIndex].position);
        if(dist < 1f)
        {
            IncreaseIndex();
        }
        UpdateState();
    }

    public void UpdateState()
    {
        switch (activeState)
        {
            case State.Patrol:
                PatrolBehaviour();
                break;
            case State.Chase:
                ChaseBehaviour();
                break;
        }
    }

    void PatrolBehaviour()
    {
        transform.Translate(Vector3.forward * speed *Time.deltaTime);

        float distanceToPlayer = Vector3.Distance(transform.position, Player.position);
        if (distanceToPlayer <= chaseDistance)
        {
            activeState = State.Chase;
            return;
        }

    }

    void IncreaseIndex()
    {
        waypointIndex ++;
        if(waypointIndex >= wayPoints.Length)
        {
            waypointIndex= 0;
        }
        transform.LookAt(wayPoints[waypointIndex].position);
    }

     public void ChaseBehaviour()
    {
        agent.SetDestination(Player.position);

    }
}