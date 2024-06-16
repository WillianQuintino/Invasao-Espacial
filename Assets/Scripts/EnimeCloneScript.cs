using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnimeCloneScript : MonoBehaviour
{
    // Contem a velocidade do asteroide
    public int speed = -5;
    public AudioClip audioShot; // Arrastar o audio da bala
    // Start is called before the first frame update
    void Start()
    {
        // Adicionar speed à velocidade do asteroide
        Rigidbody2D rb = GetComponent<Rigidbody2D> ();
        rb.velocity = new Vector2(speed, 0);
        // Destroi o asteroide após 3s de ter sido lançado
        Destroy(gameObject, 6);
    }
    
    void OnTriggerEnter2D (Collider2D outro){
        AudioSource.PlayClipAtPoint(audioShot, transform.position);
        if(outro.gameObject.tag == "balaTag")
        {
            Destroy(outro.gameObject);
        }
        if(outro.gameObject.tag == "balaEnimeTag")
        {
            Destroy(outro.gameObject);
        }
    }
}
