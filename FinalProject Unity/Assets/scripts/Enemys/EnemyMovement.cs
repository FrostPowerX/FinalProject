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
        if ((tempo > 0 || onView))
        {
            if (Vector3.Distance(transform.position, GameManager.Instance.GetPlayerPos()) > followDistance)
            {
                if (agent.isStopped) agent.isStopped = false;
                agent.SetDestination(GameManager.Instance.GetPlayerPos());
                Transform playerTrans = GameManager.Instance.Player.transform;
                if (onView)
                {
                    transform.LookAt(playerTrans);
                    tempo = cooldown;
                }
            }
            else if (!agent.isStopped) agent.isStopped = true;
        }
    }

    public void OnView(bool value) => onView = value;
    public void FollowDistance(float value) => followDistance = value;
}
