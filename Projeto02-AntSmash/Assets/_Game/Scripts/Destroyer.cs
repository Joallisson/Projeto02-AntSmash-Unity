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
            gameController.DestroyEnemy(target);
        }
    }
}
