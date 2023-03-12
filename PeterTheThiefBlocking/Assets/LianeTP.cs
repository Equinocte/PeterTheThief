using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LianeTP : MonoBehaviour
{

    public Transform teleportTarget; // position de la téléportation






    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Vérifie si l'objet en collision est le joueur
        {
            collision.gameObject.transform.position = teleportTarget.position; // Téléporte le joueur à la position spécifiée
        }
    }


}
