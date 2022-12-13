using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] GameObject fakeHead;

    [SerializeField] float cooldown;

    [SerializeField] float tempo;
    [SerializeField] float maxDistance;
    [SerializeField] float followDistance;

    bool onView;
    Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        tempo = cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        tempo = (tempo <= 0) ? 0 : tempo - Time.deltaTime;

        target = GameManager.Instance.GetPlayerPos() - transform.position;

        Move();
    }

    private void FixedUpdate()
    {
        Ray ray = new Ray(fakeHead.transform.position, target.normalized);        
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            Debug.DrawRay(fakeHead.transform.position, ray.direction * hit.distance, Color.green);

            onView = (hit.transform.tag == "Player") ? true : false;
        }
    }

    private void Move()
    {
        if ((tempo <= 0 && onView))
        {
            if (Vector3.Distance(transform.position, GameManager.Instance.GetPlayerPos()) > followDistance)
            {
                if (agent.isStopped) agent.isStopped = false;
                agent.SetDestination(GameManager.Instance.GetPlayerPos());
                tempo = cooldown;
            }
            else if (!agent.isStopped) agent.isStopped = true;
        }
    }
}
