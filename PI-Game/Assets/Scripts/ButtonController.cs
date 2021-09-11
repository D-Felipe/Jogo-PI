using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    teste teste;
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
    public void adicionaDinheiro(){//adiciona 10 na grana
        teste.grana+=10;
    }
    
    public void menosDinheiro(){//tira 10 da desgraça em tese né 
        teste.grana-=10;
    }
    public void comprar(int valor){
        teste.grana -=valor;
    }
}
