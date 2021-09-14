using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] float MaxHealth;
    public float currentHealth;
    [SerializeField] float damage;//que o inimigo toma
    NavMeshAgent nav;
    [SerializeField] Transform playerTarget;
    [SerializeField] float distance;
    [SerializeField] float howClose;
    [SerializeField] float timeBetweenAttacks = 2f;
    [SerializeField] Transform firePoint;
    public int EnemyType; //1 = Fire, 2 = Leaf, 3 = Water;
    bool alreadyAttacked;
    
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        currentHealth = MaxHealth;
    }
    void Update()
    {
        distance = Vector3.Distance(playerTarget.position, transform.position);
        if(distance <= howClose){
            transform.LookAt(playerTarget);
            nav.SetDestination(playerTarget.position);
        }
        if(distance <=howClose){
           attackPlayerDistance();
        }
    }
    void TakeDamage(){
        currentHealth -= damage;
        Debug.Log("the enemy gets hurts:"+currentHealth+" is remaining!");
        if(currentHealth <=0)
        Destroy(this.gameObject);
    }
    void ReducedDamage()
    {
        currentHealth -= damage/2;
        Debug.Log("the enemy gets hurts:" + currentHealth + " is remaining!");
        if (currentHealth <= 0)
        Destroy(this.gameObject);
    }
    void DoubleDamage()
    {
        currentHealth -= damage*2;
        Debug.Log("the enemy gets hurts:" + currentHealth + " is remaining!");
        if (currentHealth <= 0)
        Destroy(this.gameObject);
    }

    void attackPlayerDistance(){
        if(!alreadyAttacked){
            Rigidbody rb = Instantiate(projectile, firePoint.position, firePoint.rotation).GetComponent<Rigidbody>();
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
     private void ResetAttack()
    {
        alreadyAttacked = false;
    }
    void OnTriggerEnter(Collider collider){
        if (collider.gameObject.tag == "bullet")
        {
            TakeDamage();

            if (EnemyType == Gun.AmmoType)
            {
                ReducedDamage();
                print("lowlow");
            }
            if (EnemyType != Gun.AmmoType)
            {
                DoubleDamage();
                print("double");
            }
        }
    }
}
