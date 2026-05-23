using UnityEngine;

public class StetAudioController : MonoBehaviour
{
    private bool isInside = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Entered: " + other.gameObject.tag);
        if (other.CompareTag("Auscultador"))
        {
            if (!isInside)
            {
                isInside = true;
                Debug.Log("Playing Audio");
                PlayAudio();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Auscultador"))
        {
            isInside = false;
            Debug.Log("Stopping Audio");
            StopAudio();
        }
    }

    private void PlayAudio()
    {
        GameData.PatientController.PlayAudio();
    }

    private void StopAudio()
    {
        GameData.PatientController.StopAudio();
    }
}