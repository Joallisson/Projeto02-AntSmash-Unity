using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //======= INICIO PARA AJUSTAR O BACKGROUND AO TAMANHO DA TELA ====================
        SpriteRenderer sprite = GetComponentInChildren<SpriteRenderer>();
        Vector3 scaleTemp = GetComponentInChildren<Transform>().transform.localScale; //pegando o tamanho do sprite do background

        float width = sprite.bounds.size.x; //tamanho do sprite do background 
        float height = sprite.bounds.size.y; //tamanho do sprite do background
        float heightCamera = Camera.main.orthographicSize * 2.0f; // 10
        float widthWorld = heightCamera / Screen.height * Screen.width; // 0,2 depois tirar isso

        scaleTemp.x = widthWorld / width;
        scaleTemp.y = heightCamera / height;

        transform.localScale = scaleTemp;
        //======= FIM PARA AJUSTAR O BACKGROUND AO TAMANHO DA TELA ====================
    }

}
