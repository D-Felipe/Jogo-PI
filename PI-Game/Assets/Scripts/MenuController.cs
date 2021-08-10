using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] int nomeCena;
    public Image credits;
    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape))
         sair();
    }
    public void trocarCena(){
        Time.timeScale=1f;
        SceneManager.LoadScene(nomeCena);
    }
    public void creditos(){
            credits.gameObject.SetActive(true);
    }
    void sair(){
            Application.Quit();
    }
}
