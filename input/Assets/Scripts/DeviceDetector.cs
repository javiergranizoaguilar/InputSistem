using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class DeviceDetector : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI displayText;
    [SerializeField] private InputActionProperty anyAction; // Puedes usar cualquier acción general

    private void OnEnable()
    {
        anyAction.action.Enable();
        // Nos suscribimos al evento performed global de la acción
        anyAction.action.performed += OnControlInteracted;
    }

    private void OnDisable()
    {
        anyAction.action.performed -= OnControlInteracted;
        anyAction.action.Disable();
    }

    private void OnControlInteracted(InputAction.CallbackContext context)
    {
        // Obtenemos el dispositivo que originó la señal
        InputDevice device = context.control.device;

        // Comprobamos si pertenece a un Gamepad o a Teclado/Ratón
        if (device is Gamepad)
        {
            displayText.text = "Control activo: GAMEPAD";
        }
        else if (device is Keyboard || device is Mouse)
        {
            displayText.text = "Control activo: TECLADO Y RATÓN";
        }
    }
}

