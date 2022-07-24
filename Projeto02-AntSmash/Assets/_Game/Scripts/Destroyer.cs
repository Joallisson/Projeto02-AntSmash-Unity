using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private GameController gameController;
    private UIController uIController;

    private void Start()
    {
        gameController = FindObjectOfType<GameController>();
        uIController = FindObjectOfType<UIController>();
    }
    private void OnTriggerEnter2D(Collider2D target) { //Se a formiga passar da parte debaixo da tela e tocar no objeto destroyer

        if (target.gameObject.CompareTag("Enemy"))
        {
            gameController.enemyCount++; //quando o inimigo for destruido pelo GameObject Destroyer incrementa mais um na varável enemyCount

            if (gameController.enemyCount < 5) //Se a vida do usuário não tiver acabado
            {
                uIController.imageLifes[gameController.enemyCount - 1].gameObject.SetActive(false); //quando o inimigo for destruido pelo Destroyer desaparece uma vida dele na interface de usuário
            }
            else
            {
                uIController.imageLifes[gameController.enemyCount - 1].gameObject.SetActive(false); //quando o inimigo for destruido pelo Destroyer desaparece uma vida dele na interface de usuário
                Debug.Log("Game Over");
            }

            
            Destroy(target.gameObject); //destrói a formiga
        }
    }
}
