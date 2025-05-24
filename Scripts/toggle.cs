using UnityEngine;

public class ButtonToggle : MonoBehaviour
{
    public GameObject consoleScreen; // Reference to the first object
    public GameObject consoleScreen1; // Reference to the second object

    private void Start()
    {
        // Ensure both objects are assigned
        if (consoleScreen == null || consoleScreen1 == null)
        {
            Debug.LogError("Please assign both console_screen and console_screen (1) in the inspector.");
            return;
        }

        // Start with console_screen active and console_screen (1) inactive
        consoleScreen.SetActive(true);
        consoleScreen1.SetActive(false);
    }

    // This method should be called when the button is pressed down
    public void OnButtonPressed()
    {
        ToggleScreens();
    }

    private void ToggleScreens()
    {
        // Toggle the active state of both objects
        bool isConsoleScreenActive = consoleScreen.activeSelf;
        consoleScreen.SetActive(!isConsoleScreenActive);
        consoleScreen1.SetActive(isConsoleScreenActive);
    }
}