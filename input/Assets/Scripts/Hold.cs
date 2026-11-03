using UnityEngine;
using UnityEngine.InputSystem;

public class Hold : MonoBehaviour
{
    [SerializeField] private InputActionProperty superAttackAction;

    private void OnEnable()
    {
        superAttackAction.action.Enable();

        // Nos suscribimos a las fases de la acción
        superAttackAction.action.started += OnSuperAttackStarted;
        superAttackAction.action.performed += OnSuperAttackPerformed;
    }

    private void OnDisable()
    {
        superAttackAction.action.started -= OnSuperAttackStarted;
        superAttackAction.action.performed -= OnSuperAttackPerformed;

        superAttackAction.action.Disable();
    }

    private void OnSuperAttackStarted(InputAction.CallbackContext context)
    {
        // Se ejecuta justo al empezar a mantener presionada la tecla 'E' o el botón 'Y'
        Debug.Log("Cargando superataque...");
    }

    private void OnSuperAttackPerformed(InputAction.CallbackContext context)
    {
        // Se ejecuta cuando se completa el tiempo de Hold (1.0 segundo)
        Debug.Log("¡SUPERATAQUE EJECUTADO!");
    }
}
