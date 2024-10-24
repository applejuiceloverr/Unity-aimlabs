using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShooting1 : MonoBehaviour
{
    public float fireRate = 0.5f; // Time between each shot
    public float range = 100f;    // Shooting range
    public Transform gunEnd;      // The end of the gun from where the bullet fires
    public float recoilAmount = 5f; // Amount of recoil
    public float recoilSpeed = 5f;  // Speed at which recoil happens

    private float nextFireTime;
    private Quaternion originalRotation;

    void Start()
    {
        originalRotation = transform.localRotation; // Store the original rotation
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            Shoot();
        }

        // Gradually return to the original rotation
        transform.localRotation = Quaternion.Lerp(transform.localRotation, originalRotation, Time.deltaTime * recoilSpeed);
    }

void Shoot()
{
    RaycastHit hit;
    if (Physics.Raycast(gunEnd.position, gunEnd.forward, out hit, range))
    {
        Debug.Log("Hit: " + hit.transform.name);

        // Check if the hit object has TargetBehavior1 script and call its Hit method
        TargetBehavior1 target = hit.collider.GetComponent<TargetBehavior1>();
        if (target != null)
        {
            target.Hit();
        }
    }

    // Recoil effect
    transform.localRotation = Quaternion.Euler(originalRotation.eulerAngles.x - recoilAmount, originalRotation.eulerAngles.y, originalRotation.eulerAngles.z);
}

}
