using UnityEngine;
using System.Collections;

public class BoomerangReturn : MonoBehaviour
{
    private Vector3 startPosition;
    private Quaternion startRotation;
    private bool isReturning = false;
    public float returnDelay = 5f;

    void Awake()
    {
        // Store the initial position and rotation
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    // Call this method to start the return process after delay
    public void StartReturnToStart()
    {
        if (!isReturning)
        {
            StartCoroutine(ReturnAfterDelay(returnDelay));
        }
    }

    private IEnumerator ReturnAfterDelay(float delay)
    {
        // Wait before starting return
        yield return new WaitForSeconds(delay);

        isReturning = true;

        // Instantly teleport back to start position and rotation
        transform.position = startPosition;
        transform.rotation = startRotation;
    }

    // Call this method from your second trigger to stop all rotation and movement when object is back
    public void StopMovementAndRotation()
    {
        // Stop any ongoing coroutine (in case)
        StopAllCoroutines();
        isReturning = false;

        // Freeze position and rotation by setting Rigidbody constraints or manually zero velocity and rotation if Rigidbody present
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Freeze all motion and rotation
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
        else
        {
            // If no Rigidbody, optionally disable script to prevent further changes
            enabled = false;
        }
    }
}
