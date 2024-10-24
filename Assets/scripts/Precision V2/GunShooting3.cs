using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShooting3 : MonoBehaviour
{
    public float fireRate = 0.5f;
    public float range = 100f;
    public Transform gunEnd;

    private float nextFireTime;
    
void Update()
{
    if (Input.GetButtonDown("Fire1") && Time.time > nextFireTime)
    {
        nextFireTime = Time.time + fireRate;
        Shoot();
        Debug.DrawRay(gunEnd.position, gunEnd.forward * range, Color.green, 2f); // Visualize the ray
    }
}


void Shoot()
{
    Vector3 raycastDirection = transform.TransformDirection(Vector3.forward);
    Debug.Log("Shooting raycast in direction: " + raycastDirection);

    RaycastHit hit;
    if (Physics.Raycast(gunEnd.position, raycastDirection, out hit, range))
    {
        Debug.DrawRay(gunEnd.position, raycastDirection * range, Color.green, 2f);
        Debug.Log("Raycast hit: " + hit.transform.name + ", Tag: " + hit.transform.tag);

        if (hit.transform.CompareTag("Target"))
        {
            ColorSizeController3 colorController = hit.transform.GetComponent<ColorSizeController3>();
            if (colorController != null)
            {
                TargetBehavior3 target = hit.transform.GetComponent<TargetBehavior3>();
                if (target != null)
                {
                    target.Hit(); // Call Hit regardless of the target's color
                }
            }
            else
            {
                Debug.Log("Hit object is not a target or is not tagged correctly");
            }
        }
    }
}




}
