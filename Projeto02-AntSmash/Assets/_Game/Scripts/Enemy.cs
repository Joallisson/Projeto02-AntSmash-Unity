using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    private Animator myAnimator;
    [SerializeField] private GameObject[] sprites; //variavel que vai conter os sprites/objetos filhos das formigas
    private GameController gameController;
    [SerializeField] private int score; //pontuação individual de cada inimigo
    private UIController uIController;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>(); //Pega um componente de Enemy do tipo Animator
        gameController = FindObjectOfType<GameController>(); //Pega o primeiro GameObject que ele encontrar na hierarquia que tenha o script GameController
        uIController = FindObjectOfType<UIController>();//Pega o primeiro GameObject que ele encontrar na hierarquia que tenha o script UIController
        //pegando os sprites de vivo e morto das formigas
        sprites[0] = this.transform.GetChild(0).gameObject; //pegando filho/sprite do objeto da formiga andando
        sprites[1] = this.transform.GetChild(1).gameObject; //pegando filho/sprite do objeto da formiga morta
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        AnimationSpeed();
    }

    private void Movement()
    {
        transform.Translate(Vector2.down * (speed * Time.deltaTime));
    }

    private void AnimationSpeed(){
        myAnimator.SetFloat("Speed", speed); //alterando o valor da variavel definida na janela do animator
    }

    public void Dead() //Método que faz as formigas morrerem
    {
        speed = 0f; //as formigas param de andar
        gameController.totalScore += score; //atualizando a pontução individual das formigas a pontuação total do game
        uIController.UpdateScore(gameController.totalScore);
        sprites[0].gameObject.SetActive(false); //desativa o sprite filho da formiga andando
        sprites[1].gameObject.SetActive(true); //ativa o sprite filho da formiga morta
        Destroy(this.gameObject, Random.Range(2.5f, 5f));
    }

    public void PlayAudio(bool isDead)
    {
        if(isDead)
        {
            AudioSource audioSource = this.gameObject.GetComponent<AudioSource>(); //pegando o componete AudioSource das formigas
            audioSource.clip = gameController.audioEnemies[Random.Range(0, gameController.audioEnemies.Length)]; //selecionado o audio aleatoriamente das formigas
            audioSource.Play(); //tocando o audio das formigas
        }
    }
}
