using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnimeScript : MonoBehaviour
{
    // Contem a velocidade do asteroide
    // public int speed = -5;
    private PointsScript ptScript; // Para se comunicar com o scriptNave
    // Start is called before the first frame update
    void Start()
    {
        ptScript = GameObject.Find ("Pontuacao").GetComponent<PointsScript> ();
        // Adicionar speed à velocidade do asteroide
        Rigidbody2D rb = GetComponent<Rigidbody2D> ();
        // rb.velocity = new Vector2(0, speed);
        // Faz o asteroide rodar em si mesmo aleatoriamentre entre -200 e 200 graus
        // rb.angularVelocity = Random.Range(-200, 200);
        // Destroi o asteroide após 3s de ter sido lançado
        // Destroy(gameObject, 3);
    }
    
    void OnTriggerEnter2D (Collider2D outro){
        if(outro.gameObject.tag == "balaTag")
        {
            Destroy(this.gameObject);
            ptScript.pontos ++;
        }
    }
}
