using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
// Importar uma imagem para o background bg_menu, onde ficara o botão
// E associar este script ao objeto Fundo
public class menuScript : MonoBehaviour{
    void Update() {
// Teclando ESC saira do Jogo, mas somente no executavel e nao dentro do editor
        if (Input.GetKey ("escape")) {
            Application.Quit();
        }
    }
    public void OnClickStartGame(){
        SceneManager.LoadScene("fase1");
    }
    
    public void OnClickCredito(){
        SceneManager.LoadScene("credito");
    }
    
    public void OnClickMenu(){
        SceneManager.LoadScene("Menu");
    }
    
    public void OnClickExitGame(){
        Application.Quit();
    }
}