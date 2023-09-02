using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    public bool right, left;
    public float moveSpeed = 5f; // Speed at which the object moves.
    public UI_Manager UI;

    public GameObject objectToSpawn; // The object you want to instantiate.
    public Transform spawnPoint1, spawnPoint2;     // The position where the object should be spawned.
    public float spawnInterval = 2f; // Time interval between spawns in seconds.

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    void Update()
    {
        // Iterate through all active touches.
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);

            // Get the screen width to determine the center.
            float screenWidth = Screen.width;

            // Check if the touch is on the left or right side of the screen.
            if (touch.position.x < screenWidth / 2)
            {
                // Touch on the left side, move left.
                Move(-1);
            }
            else
            {
                // Touch on the right side, move right.
                Move(1);
            }
        }

    }

    IEnumerator SpawnObjects()
    {
        while (true)
        {
            // Wait for the specified spawnInterval.
            yield return new WaitForSeconds(spawnInterval);

            // Instantiate the object at the spawnPoint's position and rotation.
            Instantiate(objectToSpawn, spawnPoint1.position, spawnPoint1.rotation);
            Instantiate(objectToSpawn, spawnPoint2.position, spawnPoint2.rotation);
        }
    }

    void Move(float direction)
    {
        if (UI.isPause)
            return;
        
        // Calculate the new position based on the direction and moveSpeed.
        Vector3 newPosition = transform.position + new Vector3(direction * moveSpeed * Time.deltaTime, 0, 0);

        // Move the object to the new position.
        transform.position = newPosition;
    }
}
