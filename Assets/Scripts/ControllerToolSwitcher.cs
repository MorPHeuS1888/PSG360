using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerToolSwitcher : MonoBehaviour
{
    [Header("Objects")]
    public GameObject stethoscope;
    public GameObject universalController;

    [Header("Input")]
    public InputActionReference toggleAction;

    private bool usingStethoscope = false;

    private void OnEnable()
    {
        toggleAction.action.performed += OnTogglePressed;
        toggleAction.action.Enable();
    }

    private void OnDisable()
    {
        toggleAction.action.performed -= OnTogglePressed;
        toggleAction.action.Disable();
    }

    private void Start()
    {
        UpdateVisuals();
    }

    private void OnTogglePressed(InputAction.CallbackContext ctx)
    {
        usingStethoscope = !usingStethoscope;
        UpdateVisuals();
    }

    private void UpdateVisuals()
    {
        stethoscope.SetActive(usingStethoscope);
        universalController.SetActive(!usingStethoscope);
    }
}