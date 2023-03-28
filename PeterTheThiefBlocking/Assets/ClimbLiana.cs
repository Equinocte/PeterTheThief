using UnityEngine;

public class ClimbLiana : MonoBehaviour
{
    public float climbSpeed = 5f;
    public float detachCooldown = 2f;

    private Transform lianaTransform;
    private bool isClimbing = false;
    private float lastDetachTime = -2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Liana") && Time.time - lastDetachTime > detachCooldown)
        {
            lianaTransform = other.transform;
            isClimbing = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == lianaTransform)
        {
            isClimbing = false;
            lastDetachTime = Time.time;
        }
    }

    private void Update()
    {
        if (isClimbing)
        {
            float climbInput = Input.GetAxisRaw("Vertical");
            if (climbInput > 0f)
            {
                transform.position += Vector3.up * climbSpeed * Time.deltaTime;
            }
        }
    }
}
