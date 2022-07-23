using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapDetector : MonoBehaviour
{
    private bool tapControl; //essa variavel é pra evitar toques desnecessários
    private Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>(); //Criando variavel do tipo da classe Enemy
    }

    // Update is called once per frame
    void Update()
    {
        DetectTap();
    }

    private void DetectTap() //DETECTAR TOQUE NA TELA
    {
        
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) //Se a quantidade de toques na tela for maior que zero e o tipo desse toque é do dedo tocando na tela
        { 
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint((Input.GetTouch(0).position)), Vector2.zero); //identificar a posição do toque //Informo a direção desse recast

            if (hit.collider != null) //se a variavel hit for nulo é por que estamos tocando alguma coisa
            {   
                TapObject(hit);
                tapControl = false;
            }
        }
    }

    private void TapObject(RaycastHit2D hit) //quando eu tocar na formiga na tela
    {
        if (hit.collider.gameObject.CompareTag("Enemy") && !tapControl) //Se tocarmos nas formigas
        {
            tapControl = true;
            hit.collider.gameObject.GetComponent<Enemy>().Dead(); //Essa faz com que apenas a formiga que eu toquei morra // esse ".GetComponent<Enemy>().Dead()" serve apenas para acessar a função Dead()
            hit.collider.gameObject.GetComponent<Enemy>().PlayAudio(tapControl); //tocando audio sempre uma formiga morre
            hit.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false; //desativando o collider da formiga para não causar bugs de toques nas formigas mortas
            //Debug.Log(hit.transform.name);
        }
    }
} 
