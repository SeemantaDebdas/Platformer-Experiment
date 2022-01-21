using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] bool canFly;
    [SerializeField] PathConfigSO path;
    [SerializeField] GameObject projectile;
    [SerializeField] Vector3 projectileDirection;
    [SerializeField] float projectileSpeed;
    [SerializeField] float fireRate;

    List<Transform> waypoints;
    int waypointIdx = 0;
    int lastExtremeIdx = 0;
    float lastFired = 0;

    private void Start()
    {
        SetWayPoints();
    }

    void SetWayPoints()
    {
        if (!canFly) return;
        transform.position = path.GetFirstWayPoint().position;
        waypoints = path.GetAllWaypoints();
    }

    private void Update()
    {
        if(canFly)
            ProcessMovement();

        if (lastFired + fireRate < Time.time)
        {
            Shoot();
            lastFired = fireRate + Time.time;
        }
        
    }

    private void ProcessMovement()
    {
        if (transform.position == waypoints[waypointIdx].position)
        {
            //waypointIdx = (waypointIdx == waypoints.Count - 1) ? 0 : waypointIdx + 1;
            if (waypointIdx == 0)
            {
                waypointIdx++;
                lastExtremeIdx = 0;
            }
            else if (waypointIdx == waypoints.Count - 1)
            {
                waypointIdx--;
                lastExtremeIdx = waypoints.Count - 1;
            }
            else
            {
                waypointIdx = (lastExtremeIdx == 0) ? waypointIdx + 1 : waypointIdx - 1;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIdx].position, path.EnemySpeed * Time.deltaTime);
    }

    void Shoot()
    {
        GameObject projectilePrefabSpawn = Instantiate(projectile, transform.position,Quaternion.identity);
        projectilePrefabSpawn.GetComponent<Projectile>().ProjectileDirection = projectileDirection;
        projectilePrefabSpawn.GetComponent<Projectile>().ProjectionSpeed = projectileSpeed;
    }
}
