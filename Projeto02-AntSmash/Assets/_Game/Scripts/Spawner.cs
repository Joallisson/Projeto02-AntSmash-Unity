using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float minX, maxX, nextSpawn;
    [SerializeField] private float minDistance, maxDistance, spawnTime; //Distancia maxima e minima que as formigas serão spawnadas
    [SerializeField] private GameObject[] enemies; //Criando o array das formigas
    private GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        nextSpawn = Time.time; //pega o tempo do frame inicial
        gameController = FindObjectOfType<GameController>();
        SetMinAndMaxX();
    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
    }

    private void SetMinAndMaxX()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.safeArea.width, 0f, 0f)); //Com isso estamos pegando a largura da tela
        minX = -bounds.x + minDistance; //essa variável vai conter o valor em X da posição mínima do lado esquerdo
        maxX = bounds.x + maxDistance; //essa variável vai conter o valor em X da posição máxima do lado direito
        //Debug.Log("minX = " + minX + " maxX = " + maxX);
    }

    private void Spawn()
    {
        if(Time.time > nextSpawn) //Se o tempo atual for maior que nextSpawn
        {
            Vector2 position = new Vector2(Random.Range(minX, maxX), transform.position.y); //definindo a posição aleatória de onde as formigas vão surgir
            //criando variável do tipo GameObject para armazenar todas as formigas instanciadas
            GameObject tempEnemy = Instantiate(enemies[Random.Range(0, enemies.Length)], new Vector2(position.x, position.y), Quaternion.Euler(0f, 0f, 0f)); //gerando os tipos de formigas aleatoriamente, depois definido a posição de origem das formigas que serão instanciadas e depois a rotação delas
            tempEnemy.transform.parent = gameController.allEnemiesParent; //Transformando o atributo allEnemiesParent da classe GameController em Pai de todas as formigas instanciadas
            nextSpawn = Time.time + spawnTime; //tempo que as formigas serão instanciadas
        }
    }
}
