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
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance)) // V�rifie si vous regardez l'objet et �tes suffisamment proche
        {
            Debug.Log(hit.collider.gameObject.name);
            Debug.DrawLine(transform.position, transform.position + transform.forward * maxDistance, Color.red);
            if (hit.collider.gameObject.name == interactibleObjectName) // V�rifie si l'objet touch� est bien l'objet attach� � ce script
            {
                interactText.gameObject.SetActive(true); // Affiche le texte UI "Press E"
                if (Input.GetKeyDown(KeyCode.E)) // V�rifie si vous appuyez sur la touche "e"
                {
                    // Faites dispara�tre l'objet et affichez le message de r�ussite
                    player.gameObject.transform.position = teleportTarget.position;
                }
            }
            else
            {
                interactText.gameObject.SetActive(false); // Masque le texte UI si vous ne regardez plus l'objet ou �tes trop loin
            }
        }
        else
        {
            interactText.gameObject.SetActive(false); // Masque le texte UI si vous ne regardez plus l'objet ou �tes trop loin
        }
    }
}
