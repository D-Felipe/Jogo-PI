using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// // public class GameData{
// // public int money;
// // public int owned;
// // }
public class teste : MonoBehaviour
{
    public Text dinheiro;//texto
    public static float preco = 99;
    public static float grana;//inicia em zero
    void Update(){
        dinheiro.text="Na mão: "+grana;//mostra o texto com a variavel
        if(preco > grana){
            return;
        }
    }


















// // public Text moneyText;
// // public GameObject buyBtn;
// // public int price;

// // GameData gameData = new GameData();

// // void start(){
    
// // }


//     // public Text highscoretxt;
//     // public Text scoretxt;
//     // public float scorenum = 0;
//     // public float highscorenum;
//     // void Start()
//     // {
//     //     highscorenum=PlayerPrefs.GetFloat("high");
//     // }

//     // void Update()
//     // {
//     //     scoretxt.text = "Num:"+scorenum;
//     //     highscoretxt.text= highscorenum+"";
//     //     if(scorenum>highscorenum){
//     //         PlayerPrefs.SetFloat("high", scorenum); 
//     //     }
//     //     Debug.Log(scorenum);
//     // }
//     // public void addScore(){
//     //     scorenum+=10;
//     // }
//     // public void removeScore(){
//     //     scorenum-=10;
//     // }
}
