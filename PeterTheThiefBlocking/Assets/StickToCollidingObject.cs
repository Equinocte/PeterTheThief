using UnityEngine;

public class StickToCollidingObject : MonoBehaviour
{
    private FixedJoint joint;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Ajouter une jointure FixedJoint pour lier le joueur � l'objet
            joint = collision.gameObject.AddComponent<FixedJoint>();
            joint.connectedBody = GetComponent<Rigidbody>();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // D�truire la jointure FixedJoint lorsque le joueur quitte l'objet
            Destroy(joint);
        }
    }
}
