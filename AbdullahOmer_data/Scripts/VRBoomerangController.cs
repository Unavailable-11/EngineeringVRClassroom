using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRBoomerangController : MonoBehaviour
{
    [Header("Boomerang References")]
    [SerializeField] private GameObject boomerangObject;        // Reference to the boomerang object
    public Transform boomerangLocation;        // Where the boomerang sits when not thrown
    private Vector3 originalBoomerangPosition;
    private Quaternion originalBoomerangRotation;

    [Header("Throw Settings")]
    public float boomerangDistance = 10f;      // How far the boomerang can travel
    public float throwSpeed = 15f;             // Speed of the boomerang
    public LayerMask environmentLayer;         // Layer mask for environment detection

    [Header("Component References")]
    public Rotator rotatorScript;              // Reference to rotation script

    // State variables
    private bool isThrown = false;
    private bool isReturning = false;
    private Vector3 throwPosition;
    private MeshCollider boomerangCollider;

    void Start()
    {
        if (boomerangObject != null)
        {
            originalBoomerangPosition = boomerangObject.transform.localPosition;
            originalBoomerangRotation = boomerangObject.transform.localRotation;
            boomerangCollider = boomerangObject.GetComponent<MeshCollider>();

            if (boomerangCollider != null)
            {
                boomerangCollider.enabled = false;
            }

            // Get references to scripts if not set in inspector
            if (rotatorScript == null)
            {
                rotatorScript = boomerangObject.GetComponent<Rotator>();
            }

            // Disable rotator initially
            if (rotatorScript != null)
            {
                rotatorScript.enabled = false;
            }
        }
    }

    void Update()
    {
        // Check for left mouse button input (as requested)
        if (Input.GetMouseButtonDown(0) && !isThrown && !isReturning)
        {
            CheckDistance();
        }

        // Handle boomerang movement
        if (isThrown)
        {
            MoveBoomerangToTarget();
        }
        else if (isReturning)
        {
            ReturnBoomerangToPlayer();
        }
    }

    void CheckDistance()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward,
            out hit, boomerangDistance, environmentLayer))
        {
            // Set throw position to hit point
            throwPosition = hit.point;
        }
        else
        {
            // If raycast didn't hit anything, throw to maximum distance
            throwPosition = Camera.main.transform.position +
                Camera.main.transform.forward * boomerangDistance;
        }

        // Set parent to null (detach from player)
        boomerangObject.transform.parent = null;

        // Enable rotator
        if (rotatorScript != null)
        {
            rotatorScript.enabled = true;
        }

        // Set state flag
        isThrown = true;
    }

    void MoveBoomerangToTarget()
    {
        // Move boomerang towards target position
        Vector3 newPosition = Vector3.MoveTowards(boomerangObject.transform.position,
            throwPosition, throwSpeed * Time.deltaTime);
        boomerangObject.transform.position = newPosition;

        // Enable collider after a delay
        if (!boomerangCollider.enabled &&
            Vector3.Distance(boomerangObject.transform.position, boomerangLocation.position) > 1.0f)
        {
            boomerangCollider.enabled = true;
        }

        // Check if boomerang reached target
        if (Vector3.Distance(boomerangObject.transform.position, throwPosition) < 0.1f)
        {
            // Change state to returning
            isThrown = false;
            isReturning = true;
        }
    }

    void ReturnBoomerangToPlayer()
    {
        // Move boomerang back to player's current position (important!)
        Vector3 newPosition = Vector3.MoveTowards(boomerangObject.transform.position,
            boomerangLocation.position, throwSpeed * Time.deltaTime);
        boomerangObject.transform.position = newPosition;

        // Check if boomerang returned to player
        if (Vector3.Distance(boomerangObject.transform.position, boomerangLocation.position) < 0.1f)
        {
            ResetBoomerang();
        }
    }

    void ResetBoomerang()
    {
        // Reset boomerang state
        isReturning = false;

        // Disable rotator
        if (rotatorScript != null)
        {
            rotatorScript.enabled = false;
        }

        // Disable collider
        if (boomerangCollider != null)
        {
            boomerangCollider.enabled = false;
        }

        // Reset position and rotation
        boomerangObject.transform.parent = boomerangLocation;
        boomerangObject.transform.localPosition = originalBoomerangPosition;
        boomerangObject.transform.localRotation = originalBoomerangRotation;
    }
}
