using UnityEngine;
using System.Collections;

public class BMStage : MonoBehaviour
{
    // Objects from 2 to 6 in sequence
    public GameObject[] objects;
    private bool isSwitching = false;
    // Index of current active object in the sequence
    private int currentActiveIndex = 0;

    private void Start()
    {
        // Initialize: enable only the first object, disable others
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].SetActive(i == 0);
        }
    }

    private IEnumerator ReturnAfterDelay()
    {
        

        if (currentActiveIndex < objects.Length)
        {

            isSwitching = true;
            yield return new WaitForSeconds(2f); // Wait for 5 seconds

            // Disable current active object
            objects[currentActiveIndex].SetActive(false);

            // Move to next object if within range
            currentActiveIndex++;

            // Enable next object
            objects[currentActiveIndex].SetActive(true);
            isSwitching = false;
        }
        else
        {
            // Reached end of the sequence, no more objects to activate
            Debug.Log("Reached the last object in the sequence.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if collided with current active object
        if (other.gameObject == objects[currentActiveIndex] && isSwitching == false)
        {
            StartCoroutine(ReturnAfterDelay()); // Start the coroutine
        }
    }
}
