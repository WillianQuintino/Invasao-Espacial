using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    public GameObject grupoInimigos; // Armazenará o prefab Asteroide
    // Start is called before the first frame update
    void Update()
    {
        // Encontra todos os objetos com a tag "inimigosTag"
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("inimigosTag");

        // Percorre cada objeto e conta a quantidade de filhos
        foreach (GameObject obj in objectsWithTag)
        {
            int childCount = obj.transform.childCount;
            // Debug.Log($"Objeto com a tag 'inimigosTag' tem {childCount} filhos.");
            if (childCount < 1)
            {
                DestroyObjectsWithTag();
                Instantiate(grupoInimigos, transform.position, Quaternion.identity, transform);
            }
        }
        
        // Imprime a quantidade de componentes filhos
        
    }
    
    public void DestroyObjectsWithTag()
    {
        // Encontra todos os objetos com a tag "MyTag"
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("inimigosTag");

        // Destrói cada objeto com a tag "MyTag"
        foreach (GameObject obj in objectsWithTag)
        {
            Destroy(obj);
        }
    }
}
