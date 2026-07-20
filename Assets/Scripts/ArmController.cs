using UnityEngine;

public class ArmController : MonoBehaviour
{
    private bool isStetInside = false;
    private bool isRightHandInside = false;
    private bool isLeftHandInside = false;

    public bool IsForRightController = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Entered: " + other.gameObject.tag);
        if (other.CompareTag("Auscultador"))
        {
            if (!isStetInside)
            {
                isStetInside = true;
                Debug.Log("Playing Audio");
                PlayAudio();
                GameData.GamePoints["CheckPulse"] = GameData.ActionPoints;
            }
        }
        if (other.gameObject.name == "RightHand")
        {
            isRightHandInside = true;
            if (isLeftHandInside)
                StartControllerFeedback();
        }
        if (other.CompareTag("LeftHand"))
        {
            isLeftHandInside = true;
            if (isRightHandInside)
                StartControllerFeedback();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Auscultador"))
        {
            isStetInside = false;
            Debug.Log("Stopping Audio");
            StopAudio();
        }
        if (other.CompareTag("RightHand"))
            isRightHandInside = false;            
        if (other.CompareTag("LeftHand"))
            isLeftHandInside = false;
        StopControllerFeedback();
    }

    private void PlayAudio()
    {
        GameData.PatientController.PlayAudio();
    }

    private void StopAudio()
    {
        GameData.PatientController.StopAudio();
    }

    private void StartControllerFeedback()
    {
        GameData.PlayerController.StartControllerFeedback();        
    }

    private void StopControllerFeedback()
    {
        GameData.PlayerController.StopControllerFeedback();        
    }
}