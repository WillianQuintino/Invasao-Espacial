using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceshipScript : MonoBehaviour
{
    public GameObject bala; // A ser preenchido via Inspector com o prefab bala
    public int speed = 10;
    private int vidas = 3;
    public Text vidasUI; // Arrastar vidas da hierarquia nesta variavel

    // Update is called once per frame
    void Update()
    {
        moveHorizontal();
        // moveVertical();
        fireBullet();
        PreventLeavingScreen();
        vidasUI.text = "Vidas: " + vidas;
    }

    void moveHorizontal()
    {
        // Move a nave horizontalmente com setas ou com as teclas A e D
        // Eixo X – na horizontal
        float horizontal = Input.GetAxis("Horizontal") * speed * 
        Time.deltaTime;
        transform.Translate(horizontal, 0, 0);// Aplicando as mudanças
    }

    void moveVertical()
    {
        // Move a nave verticalmente com setas ou com as teclas W e S
        // Eixo Y – na vertical
        float vertical = Input.GetAxis("Vertical") * speed * 
        Time.deltaTime;
        transform.Translate(0, vertical, 0);// Aplicando as mudanças
    }

    void fireBullet()
    {
        // Quando a barra de espaços é pressionada ele atira
        if (Input.GetKeyDown("space")) {
            // Cria uma nova bala na posiçao atual da nave para que siga a nave
            Instantiate(bala, transform.position, Quaternion.identity);
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
}
