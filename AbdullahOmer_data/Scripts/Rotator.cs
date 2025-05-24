using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float speedX = 0;
    public float speedY = 0;
    public float speedZ = 300;

    void Update()
    {
        transform.Rotate(speedX * Time.deltaTime, speedY * Time.deltaTime, speedZ * Time.deltaTime);
    }
}
