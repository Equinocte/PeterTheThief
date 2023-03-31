using UnityEngine;

public class StickToMovingObject : MonoBehaviour
{
    private Transform movingObject;
    private bool isAttached = false;
    private Vector3 offset;
    private float lastDetachTime = -2.0f; // Initialiser � un temps ant�rieur de 2 secondes


    [SerializeField] private float detachCooldown = 2.0f; // Temps de refroidissement en secondes
    [SerializeField] private float detachOffsetZ = 2.0f; // Offset de la position Z lors du d�tachement



    private void Start()
    {
        // R�cup�rer le script PlayerMovement et l'Animator attach�s au joueur
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MovingObject") && Time.time - lastDetachTime > detachCooldown)
        {
            // D�sactiver le script PlayerMovement et l'Animator lorsque le joueur est coll� � l'objet

            // Parenter le joueur � l'objet
            movingObject = collision.gameObject.transform;
            transform.SetParent(movingObject);
            transform.localScale = Vector3.one;
            isAttached = true;
        }
    }

    private void Update()
    {
        if (isAttached && Input.GetKeyDown(KeyCode.Z))
        {
            // R�activer le script PlayerMovement et l'Animator lorsque le joueur se d�tache de l'objet

            // D�tacher le joueur de l'objet
            transform.SetParent(null);
            transform.localScale = Vector3.one;
            isAttached = false;
            lastDetachTime = Time.time;
            transform.position += Vector3.forward * detachOffsetZ;


        }
    }
    private void LateUpdate()
    {
        if (isAttached)
        {
            // D�placer le joueur en fonction de l'objet parent
            transform.position = movingObject.position + offset;

            // Ajuster la rotation du joueur en fonction de l'objet parent
            transform.rotation = movingObject.rotation;

            // Ne pas copier le scale de l'objet parent
            transform.localScale = Vector3.one;
        }
    }

}