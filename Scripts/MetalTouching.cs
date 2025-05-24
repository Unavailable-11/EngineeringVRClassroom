using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalTouching : MonoBehaviour
{
    public GameObject MetalBox;

    public bool isTouching = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Entered by: " + other.gameObject.name);
        if (other.gameObject == MetalBox)
        {
            Debug.Log("MetalBox entered CNC Machine trigger");
            isTouching = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger Exited by: " + other.gameObject.name);
        if (other.gameObject == MetalBox)
        {
            Debug.Log("MetalBox exited CNC Machine trigger");
            isTouching = false;
        }
    }
}
