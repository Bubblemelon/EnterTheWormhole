// MoveTo.cs
using UnityEngine;
using System.Collections;

public class MoveTo : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent agent;
    public Transform goal;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = goal.position;
    }

    void Update()
    {
       agent.destination = goal.position;
    }
}