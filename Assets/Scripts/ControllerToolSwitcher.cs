using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerToolSwitcher : MonoBehaviour
{
    [Header("Objects")]
    public GameObject[] controllerObjects;

    [Header("Input")]
    public InputActionReference toggleAction;

    private int selectedTool = 0;

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
        selectedTool++;
        if (selectedTool >= controllerObjects.Length)
            selectedTool = 0;
        UpdateVisuals();
    }

    private void UpdateVisuals()
    {
        foreach (GameObject obj in controllerObjects)
        {
            obj.SetActive(false);
        }

        controllerObjects[selectedTool].SetActive(true);
        if (controllerObjects[selectedTool].name == "BriefingTablet")
        {
            GameData.GamePoints["CheckTablet"] = GameData.ActionPoints;
        }
    }
}