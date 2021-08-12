using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] float damage = 100f;
    [SerializeField] float range = 100f;
    [SerializeField] GameObject firePoint;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        void Shoot()
        {
            RaycastHit hit;
            if (Physics.Raycast(firePoint.transform.position, firePoint.transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);
            }
        }
    }
}
