using UnityEngine;

public class TemperatureController : MonoBehaviour
{
    public GameObject TemperatureCanvas;

    public void MeasureTemperature()
    {
        GameData.GamePoints["CheckTemp"] = GameData.ActionPoints;
        TemperatureCanvas.SetActive(true);
    }

    public void CloseTemperatureCanvas()
    {
        TemperatureCanvas.SetActive(false);
    }
}
