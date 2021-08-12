using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    // //N sei fazer agr mas é basicamente pra ela ter a própria função de se jogar pra frente e se matar depois de um tempo
    // [SerializeField]float bulletForce;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
        rb.AddForce(transform.up * 8f, ForceMode.Impulse);
        Destroy(this.gameObject, 1.0f);
    }
}
