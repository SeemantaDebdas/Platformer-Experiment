using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] bool canFly;
    [SerializeField] PathConfigSO path;
    [Header("Projectile")]
    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject projectile;
    [SerializeField] Vector3 projectileDirection;
    [SerializeField] float projectileSpeed;
    [SerializeField] float fireRate;
    [Header("Propeller")]
    [SerializeField] Transform properller;
    [SerializeField] float propellerRotationSpeed = 10f;

    List<Transform> waypoints;
    int waypointIdx = 0;
    int lastExtremeIdx = 0;
    float lastFired = 0;

    private void Start()
    {
        SetWayPoints();
        if (canFly) spawnPoint = transform;
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
        properller.Rotate(0, propellerRotationSpeed * Time.deltaTime, 0);
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
        Quaternion spawnRotation = (canFly) ? Quaternion.identity : Quaternion.Euler(0,0,90);
        GameObject projectilePrefabSpawn = Instantiate(projectile, spawnPoint.position,spawnRotation);
        projectilePrefabSpawn.GetComponent<Projectile>().ProjectileDirection = projectileDirection;
        projectilePrefabSpawn.GetComponent<Projectile>().ProjectionSpeed = projectileSpeed;
    }
}
