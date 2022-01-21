using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Path Config",menuName ="New Path Config")]
public class PathConfigSO : ScriptableObject
{
    [SerializeField] Transform waypointPrefab;
    [SerializeField] float enemySpeed;

    public float EnemySpeed { get { return enemySpeed; } }

    public Transform GetFirstWayPoint()
    {
        return waypointPrefab.GetChild(0);
    }

    public List<Transform> GetAllWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach(Transform waypoint in waypointPrefab)
        {
            waypoints.Add(waypoint);
        }
        return waypoints;
    }
}
