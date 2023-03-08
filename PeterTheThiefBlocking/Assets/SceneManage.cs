using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public string sceneName; // nom de la scène à charger

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Vérifie si l'objet en collision est le joueur
        {
            SceneManager.LoadScene(sceneName); // Charge la scène spécifiée
        }
    }
}
