using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapDetector : MonoBehaviour
{
    private bool tapControl; //essa variavel é pra evitar toques desnecessários
    // Start is called before the first frame update
    void Start()
    {
        
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

    private void TapObject(RaycastHit2D hit)
    {
        if (hit.collider.gameObject.CompareTag("Enemy") && !tapControl) //Se tocarmos nas formigas
        {
            tapControl = true;
            Debug.Log(hit.transform.name); 
        }
    }
} 
