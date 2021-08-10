using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField]float MaxHealth;
    [SerializeField]float currentHealth;
    

    void Start()
    {
        currentHealth = MaxHealth;
    }
    void Update()
    {
        
    }
}
