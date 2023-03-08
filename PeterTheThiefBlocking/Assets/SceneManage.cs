using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public string sceneName; // nom de la sc�ne � charger

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // V�rifie si l'objet en collision est le joueur
        {
            SceneManager.LoadScene(sceneName); // Charge la sc�ne sp�cifi�e
        }
    }
}
