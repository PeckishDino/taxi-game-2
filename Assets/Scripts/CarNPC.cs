using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarNPC : MonoBehaviour
{
    public NavMeshAgent agent;

    public GameObject path;
    private Transform[] points;
    public int index = 0;
    public float minDistance = 1f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();


        points = new Transform[path.transform.childCount];
        for(int i = 0; i < points.Length; i++)
        {
            points[i] = path.transform.GetChild(i);
        }

    }

    void Update()
    {
        roam();
    }

    void roam()
    {
        if (Vector3.Distance(transform.position, points[index].position) < minDistance)
        {
            if (index + 1 != points.Length)
            {
            
                index += 1;
            }
            else
            {
                index = 0;
            }
        }
        agent.SetDestination(points[index].position);
    }
}
