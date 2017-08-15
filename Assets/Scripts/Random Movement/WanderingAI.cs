using UnityEngine;
using UnityEngine.AI; // this is needed for NavmeshHit
using System.Collections;

/*
 * Makes object move randomly
 */

public class WanderingAI : MonoBehaviour
{

    public float wanderRadius;
    public float wanderTimer;
    public Vector3 newPos; 

    private Transform target;
    private UnityEngine.AI.NavMeshAgent agent;
    private float timer;

    /*
     * https://docs.unity3d.com/540/Documentation/ScriptReference/NavMesh.SamplePosition.html 
     * 
     */
    public float range = 10.0f;


    // Use this for initialization
    void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
    }

    // Update is called once per frame
    void Update()
    {
     
        timer += Time.deltaTime;

        if (timer >= wanderTimer)
        {
            newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);

           // Debug.Log("New Pos");
            
            timer = 0;
        }
  


       /*
        * https://docs.unity3d.com/540/Documentation/ScriptReference/NavMesh.SamplePosition.html 
        * 
     
        Vector3 point;
        if (RandomPoint(transform.position, range, out point))
        {
            Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
        }
          
     
        */

        }
    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        UnityEngine.AI.NavMeshHit navHit;

        UnityEngine.AI.NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }

    /*
     * https://docs.unity3d.com/540/Documentation/ScriptReference/NavMesh.SamplePosition.html 
     * 
     */

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit; 
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }
}