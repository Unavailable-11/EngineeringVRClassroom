using UnityEngine;

public class SwitchBoomerang : MonoBehaviour
{
    // Inspector variables
    public float throwSpeed = 10f;             // Speed of the object when thrown
    public float returnTime = 3f;               // Time before the object returns
    public float spinSpeed = 720f;              // Spin speed while flying
    public Transform player;                     // Reference to the player (camera or controller)

    private bool isThrown = false;
    private Vector3 targetPosition;
    private float throwStartTime;
    private Vector3 initialPosition;

    void Update()
    {
        if (isThrown)
        {
            // Calculate time since thrown
            float timeSinceThrow = Time.time - throwStartTime;

            // Move object towards target position while spinning
            if (timeSinceThrow < returnTime)
            {
                FlyAndSpin();
            }
            else
            {
                ReturnToPlayer();
            }
        }
    }

    public void Throw()
    {
        if (!isThrown) // Check if not already thrown
        {
            isThrown = true;
            throwStartTime = Time.time;
            initialPosition = transform.position;
            targetPosition = initialPosition + player.forward * throwSpeed;
        }
    }

    void FlyAndSpin()
    {
        // Calculate the position while flying
        transform.position = Vector3.Lerp(initialPosition, targetPosition, (Time.time - throwStartTime) / returnTime);

        // Spin the object
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
    }

    void ReturnToPlayer()
    {
        // Move towards the player's position
        transform.position = Vector3.MoveTowards(transform.position, player.position, throwSpeed * Time.deltaTime);

        // Spin while returning
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);

        // Check if object reached player
        if (Vector3.Distance(transform.position, player.position) < 0.1f)
        {
            isThrown = false; // Reset the state
            transform.position = player.position; // Reset position
        }
    }

    public void OnPickUp()
    {
        // Reset conditions when picked up
        isThrown = false;
    }

    public void OnPutDown()
    {
        // Reset conditions when put down
        isThrown = false;
        transform.position = player.position; // Optionally snap back
    }
}
