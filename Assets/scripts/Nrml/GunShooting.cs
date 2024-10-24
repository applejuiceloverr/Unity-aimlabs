using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShooting : MonoBehaviour
{
    public float fireRate = 0.5f; 
    public float range = 100f;   
    public Transform gunEnd;     
    public float recoilAmount = 5f; 
    public float recoilSpeed = 5f;  

    private float nextFireTime;
    private Quaternion originalRotation;

    void Start()
    {
        originalRotation = transform.localRotation; 
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            Shoot();
        }
        transform.localRotation = Quaternion.Lerp(transform.localRotation, originalRotation, Time.deltaTime * recoilSpeed);
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(gunEnd.position, gunEnd.forward, out hit, range))
        {
            Debug.Log("Hit: " + hit.transform.name);
            
        }

        
        transform.localRotation = Quaternion.Euler(originalRotation.eulerAngles.x - recoilAmount, originalRotation.eulerAngles.y, originalRotation.eulerAngles.z);
    }
}
