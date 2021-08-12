using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField]GameObject projectile;
    [SerializeField]float MaxHealth;
    [SerializeField]float currentHealth;
    [SerializeField]float damage;
    NavMeshAgent nav;
    [SerializeField]Transform playerTarget;
    [SerializeField]float distance;
    [SerializeField]float howClose;
    [SerializeField]float timeBetweenAttacks = 1f;
     [SerializeField] Transform firePoint;
    bool alreadyAttacked;
    
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        currentHealth = MaxHealth;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        TakeDamage();
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
        Debug.Log("the enemie gets hurts:"+currentHealth+" is remaining!");
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
}
