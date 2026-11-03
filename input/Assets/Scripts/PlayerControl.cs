using UnityEngine;
using UnityEngine.InputSystem;

public class Playercontrol : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is create
    [Header("Input Actions")]
    [SerializeField] private InputActionProperty moveAction;
    [SerializeField] private InputActionProperty jumpAction;
    [SerializeField] private InputActionProperty fireAction;

    private void OnEnable()
    {
        // Activamos las acciones al habilitar el script
        moveAction.action.Enable();
        jumpAction.action.Enable();
        fireAction.action.Enable();

        // Suscribir eventos para saltar y disparar (se ejecutan igual sea teclado o mando)
        jumpAction.action.performed += OnJump;
        fireAction.action.performed += OnFire;
    }

    private void OnDisable()
    {
        jumpAction.action.Disable();
        fireAction.action.Disable();
        moveAction.action.Disable();

        jumpAction.action.performed -= OnJump;
        fireAction.action.performed -= OnFire;
    }

    private void Update()
    {
        // Leemos el movimiento (Vector2) sin importar si viene de WASD o del Joystick
        Vector2 moveInput = moveAction.action.ReadValue<Vector2>();

        if (moveInput != Vector2.zero)
        {
            Debug.Log("Moviéndose: " + moveInput);
        }
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        Debug.Log("¡Salto ejecutado!");
    }

    private void OnFire(InputAction.CallbackContext context)
    {
        Debug.Log("¡Disparo ejecutado!");
    }
}