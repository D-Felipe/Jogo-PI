using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] GameObject projectile;
    [SerializeField] Transform FirePoint;
    EnemyBehaviour EnemyBehaviour;
    public float reloadTime = 0.2f;
    bool isReloading = false;
    public int maxAmmo = 8;
    public int currentAmmo;

    float projectileForce = 20f;
   
   void Start(){
       currentAmmo = maxAmmo;
   }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            
        }
        if(currentAmmo <= 0)
        {
            // StartCoroutine(Reload());
            return;
        }
        // if(isReloading)
        // return;     
     
    }
     
       void Shoot()
        {
             Instantiate(projectile, FirePoint.position, FirePoint.rotation);
             Rigidbody rb = projectile.GetComponent<Rigidbody>();
             rb.AddForce(FirePoint.right * projectileForce, ForceMode.Impulse);
             currentAmmo--;
             Debug.Log("Quantidade de tiros:"+currentAmmo);
            //  currentAmmo--;
        }

        // IEnumerator Reload() 
        // {
        //     if(Input.GetKeyDown(KeyCode.Space))
        //     {
        //         isReloading=true;
        //         Debug.Log("Reloading");
        //         yield return new WaitForSeconds(reloadTime);
        //         currentAmmo = maxAmmo;
        //         isReloading = false;
        //     }
        // }
  
}
