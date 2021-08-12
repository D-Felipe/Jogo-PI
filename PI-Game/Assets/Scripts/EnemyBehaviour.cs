using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField]GameObject projectile;
    [SerializeField]float MaxHealth;
    public float currentHealth;
    [SerializeField]float damage;//que o inimigo toma
    NavMeshAgent nav;
    [SerializeField]Transform playerTarget;
    [SerializeField]float distance;
    [SerializeField]float howClose;
    [SerializeField]float timeBetweenAttacks = 2f;
     [SerializeField] Transform firePoint;
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
           attackPlayer();
        }
    }
    void TakeDamage(){
        currentHealth -= damage;
        Debug.Log("the enemy gets hurts:"+currentHealth+" is remaining!");
        if(currentHealth <=0)
        Destroy(this.gameObject);
    }
    void attackPlayer(){
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
    if(collider.gameObject.tag == "bullet")
    {
        TakeDamage();
    }
    }
}
