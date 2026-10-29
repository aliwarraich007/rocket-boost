using UnityEngine;
using UnityEngine.InputSystem;

public class ApplicationQuit : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.escapeKey.isPressed)
        {
            Debug.Log("Closing Application");
            Application.Quit();
        }
    }
}
