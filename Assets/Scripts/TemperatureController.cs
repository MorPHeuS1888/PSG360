using TMPro;
using UnityEngine;

public class TemperatureController : MonoBehaviour
{
    public GameObject TemperatureCanvas;
    public TextMeshProUGUI TemperatureText;

    public void MeasureTemperature()
    {
        GameData.GamePoints["CheckTemp"] = GameData.ActionPoints;
        // update TemperatureText.text with the selected temperature, rounded to 1 decimal place
        TemperatureText.text = $"Patient Body Temperature: {GameData.SelectedTemperature.ToString("F1")} ºC";
        TemperatureCanvas.SetActive(true);
    }

    public void CloseTemperatureCanvas()
    {
        TemperatureCanvas.SetActive(false);
    }
}
