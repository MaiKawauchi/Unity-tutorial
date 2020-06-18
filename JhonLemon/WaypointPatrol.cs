using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;
    int m_CurrentWaypointIndex;

    // Start is called before the first frame update
    void Start()
    {
        // Nav Mesh Agentの初期宛先
        navMeshAgent.SetDestination(waypoints[0].position);
    }

    // Update is called once per frame
    void Update()
    {
        // Nav Mesh Agentが宛先に到着した(停止距離よりも短い)かどうか
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            // 次のウェイポイントに移動
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
        }
    }
}
