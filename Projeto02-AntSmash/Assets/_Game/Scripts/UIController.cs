using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //biblioteca usada para trabalhar com a interface do usuário
using TMPro; ////biblioteca usada para trabalhar com a o Text Mesh Pro

public class UIController : MonoBehaviour
{
    private GameController gameController;
    public TMP_Text txtScore; //variavel que guarda a pontuação
    public Image[] imageLifes; //criando array de vidas do jogador
    public GameObject panelGame, panelPause, allLifes;
    // Start is called before the first frame update
    void Start()
    {
        panelGame.gameObject.SetActive(true); //ativando o painel do jogo
        panelPause.gameObject.SetActive(false); //desativando o painel de pause
        gameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int score)
    {
        txtScore.text = score.ToString(); //converte a pontuação em string
    }

    public void ButtonPause()
    {
        Time.timeScale = 0f; //pausando o game
        panelGame.gameObject.SetActive(false); //desativando o painel do jogo
        panelPause.gameObject.SetActive(true); //ativando o painel de pause
    }

    public void ButtonResume()
    {
        Time.timeScale = 1f; //Saindo do pause
        panelGame.gameObject.SetActive(true);  //ativando o painel do jogo 
        panelPause.gameObject.SetActive(false); //desativando o painel de pause
    }

    public void ButtonRestart()
    {
        Time.timeScale = 1f; //Saindo do pause
        panelGame.gameObject.SetActive(true);  //ativando o painel do jogo 
        panelPause.gameObject.SetActive(false); //desativando o painel de pause
        gameController.Restart();

        foreach(Transform child in allLifes.transform) //percorre o pai de todas as imagens de vida e ativa cada uma delas para aprecerem na tela do jogo
        {
           child.gameObject.SetActive(true);
        }
    }

    public void ButtonBackMainMenu() //voltando para o menu principal
    {
        Time.timeScale = 1f; //Saindo do pause
        panelGame.gameObject.SetActive(false);
        panelPause.gameObject.SetActive(false);
    }

}
