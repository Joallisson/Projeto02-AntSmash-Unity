using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public AudioClip[] audioEnemies;
    [HideInInspector] public int totalScore; //Escondendo uma variével publica do inpector //pontuação total
    [HideInInspector] public int enemyCount;
    private UIController uIController;
    public Transform allEnemiesParent; //todos os inimigos presentes na tela quando o jogo é reiniciado
    // Start is called before the first frame update
    void Start()
    {
        totalScore = 0;
        enemyCount = 0;
        uIController = FindObjectOfType<UIController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        totalScore = 0;
        enemyCount = 0;
        uIController.txtScore.text = totalScore.ToString(); //zerando a pontução da tela do usuário

        foreach (Transform child in allEnemiesParent.transform) //percorre dentro do pai que contem todos os inimigos/formigas e destroi todas elas asim que o botão restart é pressionado
        {
            Destroy(child.gameObject);
        }

    }
}
