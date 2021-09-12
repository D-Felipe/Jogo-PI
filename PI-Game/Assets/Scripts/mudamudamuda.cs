using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mudamudamuda : MonoBehaviour
{
    [SerializeField]int numeroCena;
    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.tag=="Player"){
        Debug.Log("colidiu ocm o colisor q colide o coletor");}
        SceneManager.LoadScene(numeroCena);
    }
}
