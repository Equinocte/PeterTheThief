using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interact : MonoBehaviour
{
    public GameObject cube;
    public GameObject successText;
    public GameObject noSuccessText;
    public GameObject interactText;
    public GameObject player;
    public Transform teleportTarget;

    public string interactibleObjectName = "Cube";

    public float maxDistance = 5f;

    public float successMessageDuration = 2.0f;


    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance)) // Vérifie si vous regardez l'objet et êtes suffisamment proche
        {
            Debug.Log(hit.collider.gameObject.name);
            Debug.DrawLine(transform.position, transform.position + transform.forward * maxDistance, Color.red);
            if (hit.collider.gameObject.name == interactibleObjectName) // Vérifie si l'objet touché est bien l'objet attaché à ce script
            {
                interactText.gameObject.SetActive(true); // Affiche le texte UI "Press E"
                if (Input.GetKeyDown(KeyCode.E)) // Vérifie si vous appuyez sur la touche "e"
                {
                    // Faites disparaître l'objet et affichez le message de réussite
                    player.gameObject.transform.position = teleportTarget.position;
                }
            }
            else
            {
                interactText.gameObject.SetActive(false); // Masque le texte UI si vous ne regardez plus l'objet ou êtes trop loin
            }
        }
        else
        {
            interactText.gameObject.SetActive(false); // Masque le texte UI si vous ne regardez plus l'objet ou êtes trop loin
        }
    }
}
