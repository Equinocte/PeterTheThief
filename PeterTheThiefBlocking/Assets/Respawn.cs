using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    public string sceneName; // nom de la scène à charger
    public float coneAngle = 70f; // définir l'angle du cône (en degrés)
    public float maxDistance = 10f; // la distance maximale à laquelle les raycasts peuvent atteindre
    public LayerMask layerMask; // les layers à considérer pour les collisions avec le raycast

    void Update()
    {
        Vector3 origin = transform.position; // définir l'origine du cône comme étant la position de l'objet
        float sphereRadius = maxDistance * Mathf.Tan(Mathf.Deg2Rad * coneAngle / 2f); // calculer le rayon de la sphère

        // dessiner le cone raycast
        Debug.DrawRay(origin, transform.forward * maxDistance, Color.green);
        Debug.DrawRay(origin, Quaternion.Euler(0f, coneAngle / 2f, 0f) * transform.forward * maxDistance, Color.green);
        Debug.DrawRay(origin, Quaternion.Euler(0f, -coneAngle / 2f, 0f) * transform.forward * maxDistance, Color.green);
        Debug.DrawRay(origin, Quaternion.Euler(coneAngle / 2f, 0f, 0f) * transform.forward * maxDistance, Color.green);
        Debug.DrawRay(origin, Quaternion.Euler(-coneAngle / 2f, 0f, 0f) * transform.forward * maxDistance, Color.green);

        RaycastHit hit;
        if (Physics.Raycast(origin, transform.forward, out hit, maxDistance, layerMask)) // lancer le raycast en forme de cone
        {
            if (hit.collider.CompareTag("Player")) // vérifier si le joueur est touché
            {
                SceneManager.LoadScene(sceneName); // recharger la scène actuelle
            }
        }
    }
}
