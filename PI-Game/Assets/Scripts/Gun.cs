using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] GameObject projectile;
    [SerializeField] Transform FirePoint;
    EnemyBehaviour EnemyBehaviour;
    
    bool isReloading = false;
    public int maxAmmo = 8;
    public int currentAmmo;
    public float reloadTime = 2f;


    float projectileForce = 20f;
   
   void Start(){
       currentAmmo = maxAmmo;
   }

    void Update()
    {
        if(isReloading)
        return;
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            
        }
        if(currentAmmo <= 0)
        {
           StartCoroutine(reload());
            return;
        }
   
     
    }
     IEnumerator reload(){
         isReloading=true;
         Debug.Log("reload");
         yield return new WaitForSeconds(reloadTime);
         currentAmmo = maxAmmo;
         isReloading = false;
     }
       void Shoot()
        {
             Instantiate(projectile, FirePoint.position, FirePoint.rotation);
             Rigidbody rb = projectile.GetComponent<Rigidbody>();
             rb.AddForce(FirePoint.right * projectileForce, ForceMode.Impulse);
             currentAmmo--;
             Debug.Log("Quantidade de tiros:"+currentAmmo);
            
        }

  
}
