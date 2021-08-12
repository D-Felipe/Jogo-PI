using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 32f, ForceMode.Impulse);

        Destroy(this.gameObject, 0.7f);
    }
    void OnTriggerEnter (Collider other) {
        Destroy(this.gameObject);
}
}
