using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //biblioteca usada para trabalhar com a interface do usuário
using TMPro; ////biblioteca usada para trabalhar com a o Text Mesh Pro

public class UIController : MonoBehaviour
{
    public TMP_Text txtScore; //variavel que guarda a pontuação
    public Image[] imageLifes; //criando array de vidas do jogador
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int score)
    {
        txtScore.text = score.ToString(); //converte a pontuação em string 
    }
}
