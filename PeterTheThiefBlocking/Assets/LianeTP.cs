using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LianeTP : MonoBehaviour
{

    public Transform teleportTarget; // position de la téléportation
    public GameObject player;


    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            player.gameObject.transform.position = teleportTarget.position;
        }
    }




}
