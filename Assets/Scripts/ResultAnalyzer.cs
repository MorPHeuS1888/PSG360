using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultAnalyzer : MonoBehaviour
{

    public TextMeshProUGUI Critics;
    public TextMeshProUGUI PercentageScore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string critics = "";
        int totalPoints = 0;

        // Analyze the GamePoints dictionary and calculate the total points
        foreach (var point in GameData.GamePoints)
        {
            totalPoints += point.Value;
            if (point.Value == 0)
            {
                switch (point.Key)
                {
                    case "CheckTemp":
                        critics += "You did not check the patient's temperature.\n";
                        break;
                    case "CheckPulse":
                        critics += "You did not use the stethoscope correctly.\n";
                        break;
                    case "CheckTablet":
                        critics += "You did not check the patient's clinical history.\n";
                        break;
                    case "CheckElevation":
                        critics += "You did not check if the AVF colapses.\n";
                        break;
                    case "CheckPalpation":
                        critics += "You did not check for a colateral circulation.\n";
                        break;
                    case "SkinRash":
                        critics += "'Skin Rash' in checklist is not correct.\n";
                        break;
                    case "SkinAstenose":
                        critics += "'Possible Stenosis' in checklist is not correct.\n";
                        break;
                    case "Temperature":
                        critics += "'Abnormal Temperature' in checklist is not correct.\n";
                        break;
                    case "Pulse":
                        critics += "'Abnormal Pulse' in checklist is not correct.\n";
                        break;
                    case "Elevation":
                        critics += "'Outflow Stenosis' in checklist is not correct.\n";
                        break;
                    case "Palpation":
                        critics += "'Hyperpulsatile Pulse' in checklist is not correct.\n";
                        break;
                    default:
                        break;
                }
            }
        }

        float percentage = (float)totalPoints / (GameData.GamePoints.Count * GameData.ActionPoints) * 100;
        //Display percentage with 0 decimal places
        PercentageScore.text = $"{percentage.ToString("F0")}%";
        //Set TMPproUGUI text to the critics
        if (critics == "")
        {
            critics = "Congratulations! You have completed the simulation successfully.";
        }
        Critics.text = critics;
    }

    public void EndResults()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
