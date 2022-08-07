using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public AudioClip[] audioEnemies;
    [HideInInspector] public int totalScore, enemyCount, highScore; //Escondendo uma variével publica do inpector //pontuação total
    private UIController uIController;
    public Transform allEnemiesParent; //todos os inimigos presentes na tela quando o jogo é reiniciado
    private Spawner spawer; //para ativar e desativar a criação das formigas
    private Destroyer destroyer;
    [SerializeField] private AudioSource music; //musica do jogo
    public float incrementSpeed; //eu vou colocar o valor de incremento no inspector
    [HideInInspector] public float countSpeed; //armazena a velocidade de cada formiga
    private Enemy enemy; //cada formiga
    private GameObject enemyObject;

    private void Awake() {
        uIController = FindObjectOfType<UIController>();
        spawer = FindObjectOfType<Spawner>();
        destroyer = FindObjectOfType<Destroyer>();
        highScore = GetScore();
    }

    // Start is called before the first frame update
    void Start()
    {
        totalScore = 0;
        enemyCount = 0;
        spawer.gameObject.GetComponent<Spawner>().enabled = false; //no começo do jogo o GameObject Spawer começa desativado
        music.volume = 0.5f;

        countSpeed = 1f;
        InvokeRepeating("IncrementSpeed", .01f, 1f);
    }

    private void IncrementSpeed()
    {
        countSpeed += incrementSpeed;
    }

    public void GameOver() //Quando o jogador perder a partida
    {
        spawer.gameObject.GetComponent<Spawner>().enabled = false; //desativa o script que faz as formigas aparecerem
        destroyer.gameObject.GetComponent<BoxCollider2D>().enabled = false; //desativa o script que faz as formigas morrerem
        uIController.txtFinalScore.text = "Score: " + totalScore.ToString(); //quando terminar o jogo, mostrar os pontos totais

        //destroi todas as formigas no gameover
        foreach (Transform child in allEnemiesParent.transform) //percorre dentro do pai que contem todos os inimigos/formigas e destroi todas elas asim que o botão restart é pressionado
        {
            Destroy(child.gameObject);
        }
    }

    public void DestroyEnemy(Collider2D target)
    {
        enemyCount++; //quando o inimigo for destruido pelo GameObject Destroyer incrementa mais um na varável enemyCount

        if (enemyCount < 5) //Se a vida do usuário não tiver acabado
        {
            uIController.imageLifes[enemyCount - 1].gameObject.SetActive(false); //quando o inimigo for destruido pelo Destroyer desaparece uma vida dele na interface de usuário
        }
        else //se a vida do usuário acabar
        {
            uIController.imageLifes[enemyCount - 1].gameObject.SetActive(false); //quando o inimigo for destruido pelo Destroyer desaparece uma vida dele na interface de usuário
            uIController.panelGameOver.gameObject.SetActive(true);
            GameOver();
            SaveScore(); //se as vidas acabarem setar a maior pontuação para o highScore no script GameController
        }

        Destroy(target.gameObject); //destrói a formiga
    }

    public void StartGame() //qunado o jogo começar tudo vai estar zerado
    {
        totalScore = 0;
        enemyCount = 0;
        uIController.txtScore.text = totalScore.ToString();
        spawer.gameObject.GetComponent<Spawner>().enabled = true;
        music.volume = 0.25f;

        countSpeed = 1f;
    }

    public void BackMainMenu() //quando voltar pro menu principal aumenta volume do jogo
    {
        music.volume = 0.5f;
        totalScore = 0;
        enemyCount = 0;
        uIController.txtScore.text = totalScore.ToString(); //zerando a pontução da tela do usuário
        destroyer.gameObject.GetComponent<BoxCollider2D>().enabled = true; //desativa o script que faz as formigas morrerem
        spawer.gameObject.GetComponent<Spawner>().enabled = false; //desativando a criação das formigas

        spawer.BackValueSpawnTime();

        //ativar todas as imagens da vida do jogador
        for (int i = 0; i < uIController.imageLifes.Length; i++)
        {
            uIController.imageLifes[i].gameObject.SetActive(true);
        }

        //destrói todos os inimigos quando volta pro menu principal
        foreach (Transform child in allEnemiesParent.transform) //percorre dentro do pai que contem todos os inimigos/formigas e destroi todas elas asim que o botão restart é pressionado
        {
            Destroy(child.gameObject);
        }
    }

    public void Restart()
    {
        totalScore = 0;
        enemyCount = 0;
        uIController.txtScore.text = totalScore.ToString(); //zerando a pontução da tela do usuário
        spawer.gameObject.GetComponent<Spawner>().enabled = true; //desativa o script que faz as formigas aparecerem
        destroyer.gameObject.GetComponent<BoxCollider2D>().enabled = true; //desativa o script que faz as formigas morrerem

        countSpeed = 1f;
        spawer.BackValueSpawnTime();

        foreach (Transform child in allEnemiesParent.transform) //percorre dentro do pai que contem todos os inimigos/formigas e destroi todas elas asim que o botão restart é pressionado
        {
            Destroy(child.gameObject);
        }
    }

    public void SaveScore()
    {
        if (totalScore > highScore) //se a pontuação atual for maior que a maior pontuação, então guarda essa puntuação atual na chave "highscore"
        {
            PlayerPrefs.SetInt("highscore", totalScore); //setando a maior pontuação
            uIController.txtHighScore.text = "High Score: " + totalScore.ToString();
        }
    }

    public int GetScore() //recuperando amaior pontuação setada no SaveScore()
    {
        highScore = PlayerPrefs.GetInt("highscore");
        return highScore;
    }
}
