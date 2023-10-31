using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAnxiety : MonoBehaviour
{
    //setup state logic
    //public enum State { Chase }
    //public State activeState;

    //setup chase state logic
    //private float chaseDist = 2f;
    //private float lostDist = 15f;

    public Transform player;

    public NavMeshAgent agent;

    public AudioSource soundEffect;
    private AudioClip soundClip;

    public TimeController timeContScript;

    private void Start()
    {
        soundEffect.clip = soundClip;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //soundEffect.Play();
        if (collision.gameObject.CompareTag("Player"))
        {
            timeContScript.Countdown(-5);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        agent.SetDestination(player.position);
    }

    //public void UpdateState()
    //{
    //    switch (activeState)
    //    {
    //         case State.Chase:
    //            ChaseBehaviour();
    //            break;
    //    }
    //}

    //public void ChaseBehaviour()
    //{
    //    //float distanceToPlayer = Vector3.Distance(transform.position, player.position);

    //    agent.SetDestination(player.position);
    //}

    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawWireSphere(transform.position, chaseDist);
    //}

    //public void PlaySound()
    //{
    //    sound.Play();
    //    and stop other sound from play;
    //}
}
