using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpaceshipScript : MonoBehaviour
{
    public GameObject bala; // A ser preenchido via Inspector com o prefab bala
    public int speed = 10;
    public float tempoEntreOsTiros = 0.5f; // 0.5 segundos entre os tiros
    public Text vidasUI; // Arrastar vidas da hierarquia nesta variavel
    public AudioClip audioNaveColisao; // Arrastar o audio da bala
    public AudioClip audioNaveExplosion; // Arrastar o audio da bala 
    private int vidas = 3;
    private float tempoDesdeUltimoTiro = 0f;
    
    // Update is called once per frame
    void Update()
    {
        moveHorizontal();
        // moveVertical();
        fireBullet();
        PreventLeavingScreen();
        vidasUI.text = "Vidas: " + vidas;
        tempoDesdeUltimoTiro += Time.deltaTime;
    }

    void moveHorizontal()
    {
        // Move a nave horizontalmente com setas ou com as teclas A e D
        // Eixo X – na horizontal
        float horizontal = Input.GetAxis("Horizontal") * speed * 
        Time.deltaTime;
        transform.Translate(horizontal, 0, 0);// Aplicando as mudanças
    }

    void fireBullet()
    {
        // Quando a barra de espaços é pressionada ele atira
        if (Input.GetKeyDown("space") && tempoDesdeUltimoTiro >= tempoEntreOsTiros) {
            // Cria uma nova bala na posição atual da nave
            Instantiate(bala, transform.position, Quaternion.identity);

            // Reinicia o tempo desde o último tiro
            tempoDesdeUltimoTiro = 0f;
        }
    }

    void PreventLeavingScreen()
    {
        //Restringir o movimento entre dois valores
        if(transform.position.x <= -5.6f || transform.position.x >= 5.6f){
            // Criando o limite
            float xPos = Mathf.Clamp (transform.position.x,-5.6f,5.6f);
            // Limitando
            transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
        }
    }
    
    void OnTriggerEnter2D (Collider2D outro){
        if(outro.gameObject.tag == "balaEnimeTag")
        {            
            vidas --;
            AudioSource.PlayClipAtPoint(audioNaveColisao, transform.position);
            
            if (vidas <= 0)
            {
                AudioSource.PlayClipAtPoint(audioNaveExplosion, transform.position);
                Destroy(this.gameObject);
                SceneManager.LoadScene("fim");
            }
            Destroy(outro.gameObject);
        }
    }
}
