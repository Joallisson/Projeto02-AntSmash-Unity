using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D target) { //Se a formiga passar da parte debaixo da tela e tocar no objeto destroyer

        if (target.gameObject.CompareTag("Enemy"))
        {
            Destroy(target.gameObject); //destrói a formiga
        }
    }
}
