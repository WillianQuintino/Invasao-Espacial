using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaEmineScript : MonoBehaviour
{
    public float speed = 6;
    // É chamado apenas uma vez quando a bala é criada

    // Start is called before the first frame update
    void Start()
    {
        // Ajusta a velocidade Y para fazer a bala se mover para cima
        Rigidbody2D rb = GetComponent<Rigidbody2D> ();
        rb.velocity = new Vector2(0, -speed);
        
    }
    // Quando a bala ficar invisível será destruída
    void OnBecameInvisible()
    {
        // Destroi a bala quando já está fora da tela
        Destroy(gameObject);
    }
}
