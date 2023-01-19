using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Animator animator;

    [SerializeField] float cooldown;

    [SerializeField] float tempo;
    [SerializeField] float followDistance;

    bool moving;
    bool onView;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.isStopped = true;
    }

    // Update is called once per frame
    void Update()
    {
        tempo = (tempo <= 0) ? 0 : tempo - Time.deltaTime;

        moving = (agent.isStopped) ? false : true;

        animator.SetBool("Moving", moving);
        
        Move();
    }

    private void Move()
    {
        float distance = Vector3.Distance(transform.position, GameManager.Instance.GetPlayerPos());
        if ((tempo > 0 || onView))
        {
            if (onView && distance < followDistance)
            {
                Transform playerTrans = GameManager.Instance.Player.transform;

                agent.isStopped = true; 
                transform.LookAt(playerTrans);
                tempo = cooldown;
            }
            if (!onView && tempo <= 0) agent.isStopped = true;

            if (distance > followDistance)
            {
                if (agent.isStopped) agent.isStopped = false;
                agent.SetDestination(GameManager.Instance.GetPlayerPos());
            }
        }
    }

    public void OnView(bool value) => onView = value;
    public void FollowDistance(float value) => followDistance = value;
}
