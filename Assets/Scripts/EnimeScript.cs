using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnimeScript : MonoBehaviour
{
    // Contem a velocidade do asteroide
    // public int speed = -5;
    public GameObject bala; // A ser preenchido via Inspector com o prefab bala
    public int ChanceEmUm = 10;
    public float timeLimitBullet = 1.0f; // Tempo limite em segundos
    public AudioClip audioExplosion; // Arrastar o audio da bala 
    private Animator animator;
    private PointsScript ptScript; // Para se comunicar com o scriptNave
    private float timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        ptScript = GameObject.Find ("Pontuacao").GetComponent<PointsScript> ();
        // Adicionar speed à velocidade do asteroide
        Rigidbody2D rb = GetComponent<Rigidbody2D> ();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeLimitBullet)
        {
            FireBullet();
            timer = 0.0f;
        }
        
    }

    void OnTriggerEnter2D (Collider2D outro){
        if(outro.gameObject.tag == "balaTag")
        {            
            ptScript.pontos ++;
            AudioSource.PlayClipAtPoint(audioExplosion, transform.position);
            Destroy(outro.gameObject);
            Destroy(this.gameObject);
        }
    }
    
    // ReSharper disable Unity.PerformanceAnalysis
    void FireBullet()
        {
            int randomIndex = Random.Range(0, ChanceEmUm);
            
            if (randomIndex == 1) {
                // Ativa o trigger "Ataque" do animator
                animator.SetTrigger("Ataque");
                Invoke(nameof(Bullet), 1.7f);
            }
            
        }

    void Bullet()
    {
        Instantiate(bala, transform.position, Quaternion.identity);
    }
}
