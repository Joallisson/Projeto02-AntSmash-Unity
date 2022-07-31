using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //biblioteca usada para trabalhar com a interface do usuário
using TMPro; ////biblioteca usada para trabalhar com a o Text Mesh Pro

public class UIController : MonoBehaviour
{
    private GameController gameController;
    public TMP_Text txtScore, txtHighScore, txtFinalScore; //variavel que guarda a pontuação
    public Image[] imageLifes; //criando array de vidas do jogador
    [SerializeField] private GameObject panelGame, panelPause, panelMainMenu, allLifes;
    public GameObject panelGameOver;
    // Start is called before the first frame update
    void Start()
    {
        Initialized();
    }

    private void Initialized() {
        panelMainMenu.gameObject.SetActive(true); //o jogo já começa com o painel principal do jogo ativado
        panelGameOver.gameObject.SetActive(false); //o painel do game over começa desativado
        panelGame.gameObject.SetActive(false); //ativando o painel do jogo
        panelPause.gameObject.SetActive(false); //desativando o painel de pause
        gameController = FindObjectOfType<GameController>();
        txtHighScore.text = "High Score: " + gameController.highScore.ToString();
    }

    public void UpdateScore(int score)
    {
        txtScore.text = score.ToString(); //converte a pontuação em string
    }

    public void ButtonStartGame() //iniciando o jogo
    {
        panelMainMenu.gameObject.SetActive(false);
        panelGame.gameObject.SetActive(true);
        gameController.StartGame();
    }

    public void ButtonExitGame() //saindo do jogo no android
    {
        AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.unityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
        activity.Call<bool>("moveTaskToBack", true);
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
        panelGameOver.gameObject.SetActive(false); //desativando o painel de game over
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
        panelGameOver.gameObject.SetActive(false);
        panelPause.gameObject.SetActive(false);
        panelMainMenu.gameObject.SetActive(true);
        gameController.BackMainMenu();
    }

}
