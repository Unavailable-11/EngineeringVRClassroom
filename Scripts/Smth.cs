using UnityEngine;

/// <summary>
/// Attach this script to the first object that should disappear upon contact.
/// When this object collides with the specified "targetObject",
/// it will deactivate itself and activate or instantiate the "spawnObject".
/// </summary>
public class DisappearAndSpawn : MonoBehaviour
{
    [Tooltip("The object to detect collision with.")]
    public GameObject targetObject;

    [Tooltip("If assigned, this object will be enabled on collision.")]
    public GameObject spawnObjectToEnable;

    [Tooltip("If assigned, this prefab will be instantiated on collision.")]
    public GameObject spawnPrefabToInstantiate;

    [Tooltip("Position offset for instantiating the prefab relative to this object.")]
    public Vector3 spawnPositionOffset = Vector3.zero;

    [Tooltip("Rotation offset (Euler angles) for instantiating the prefab.")]
    public Vector3 spawnRotationOffset = Vector3.zero;

    // Flag to prevent multiple triggers
    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        // Check if already triggered
        if (hasTriggered)
            return;

        if (other.gameObject == targetObject)
        {
            hasTriggered = true;

            // Deactivate this object
            gameObject.SetActive(false);

            // Activate the spawn object in scene if set
            if (spawnObjectToEnable != null)
            {
                spawnObjectToEnable.SetActive(true);
            }

            // Instantiate spawn prefab if set
            if (spawnPrefabToInstantiate != null)
            {
                Quaternion spawnRotation = Quaternion.Euler(spawnRotationOffset);
                Vector3 spawnPosition = transform.position + spawnPositionOffset;
                Instantiate(spawnPrefabToInstantiate, spawnPosition, spawnRotation);
            }
        }
    }

    // Optional: If you want to use collision instead of trigger, uncomment below
    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (hasTriggered)
            return;

        if (collision.gameObject == targetObject)
        {
            hasTriggered = true;

            // Deactivate this object
            gameObject.SetActive(false);

            // Activate the spawn object in scene if set
            if (spawnObjectToEnable != null)
            {
                spawnObjectToEnable.SetActive(true);
            }

            // Instantiate spawn prefab if set
            if (spawnPrefabToInstantiate != null)
            {
                Quaternion spawnRotation = Quaternion.Euler(spawnRotationOffset);
                Vector3 spawnPosition = transform.position + spawnPositionOffset;
                Instantiate(spawnPrefabToInstantiate, spawnPosition, spawnRotation);
            }
        }
    }
    */
}
