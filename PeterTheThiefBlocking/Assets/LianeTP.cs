using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LianeTP : MonoBehaviour
{

    public Transform teleportTarget; // position de la t�l�portation






    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // V�rifie si l'objet en collision est le joueur
        {
            collision.gameObject.transform.position = teleportTarget.position; // T�l�porte le joueur � la position sp�cifi�e
        }
    }


}
