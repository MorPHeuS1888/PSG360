using UnityEngine;
using UnityEngine.UI;

public class CheckListController : MonoBehaviour
{
    public Toggle[] checkListToggles; // Array of toggles for the checklist

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // watch for changes in the toggles and update the checklist accordingly
        foreach (Toggle toggle in checkListToggles)
        {
            toggle.onValueChanged.AddListener(delegate { UpdateChecklist(); });
        }
    }

    private void UpdateChecklist()
    {
        // Check if all toggles are checked
        foreach (Toggle toggle in checkListToggles)
        {
            // get toggle number from the toggle name (assuming the toggle names are like "Toggle01", "Toggle02", etc.)
            string toggleName = toggle.name;
            int toggleNumber = int.Parse(toggleName.Substring(toggleName.Length - 2)); // Get the last two characters and parse as int
            GameData.Checklist[toggleNumber] = toggle.isOn;
        }
    }
}
