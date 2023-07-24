using UnityEngine;

public class InputModule : MonoBehaviour
{
    public InputSystem InputSystem { get; private set; }

    private void Awake()
    {
        InputSystem = new InputSystem();
        InputSystem.Enable();
    }
}