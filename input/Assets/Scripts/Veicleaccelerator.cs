using UnityEngine;
using UnityEngine.InputSystem;

public class Veicleaccelerator : MonoBehaviour
{
    [SerializeField] private InputActionProperty accelerateAction;

    private void OnEnable()
    {
        accelerateAction.action.Enable();
    }

    private void OnDisable()
    {
        accelerateAction.action.Disable();
    }

    private void Update()
    {
        // Lee el valor analógico/digital de la acción (0.0 a 1.0)
        float accelerationValue = accelerateAction.action.ReadValue<float>();

        // Si pulsas la W (teclado), pasa instantáneamente a 1.0.
        // Si pulsas el Gatillo Derecho (mando), varía progresivamente según la presión (0.1, 0.5, 1.0...)
        if (accelerationValue > 0f)
        {
            Debug.Log("Acelerando al: " + (accelerationValue * 100f).ToString("F0") + "%");
        }
    }
}