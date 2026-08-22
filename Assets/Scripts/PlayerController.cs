using System;
using System.Collections;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerController : MonoBehaviour
{
    private bool isVibrating = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameData.PlayerCamera = Camera.main;
        GameData.PlayerController = this;
    }

    public void StartControllerFeedback()
    {
        isVibrating = true;
        GameData.GamePoints["CheckPalpation"] = GameData.ActionPoints;
        Debug.Log("Starting Controller Feedback");
        StartCoroutine(ControllerFeedbackCoroutine());        
    }

    private IEnumerator ControllerFeedbackCoroutine()
    {
        while (isVibrating)
        {
            if (GameData.SelectedAVFPulse == 1)
                VibrateController(1f, 0.5f);
            else
                VibrateController(1f, 0.5f);
            yield return new WaitForSeconds(1f);
        }
    }

    public void StopControllerFeedback()
    {
        Debug.Log("Stopping Controller Feedback");
        isVibrating = false;
    }

    public void VibrateController(float amplitude, float duration)
    {
        InputDevice deviceLeft = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        InputDevice deviceRight = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);

        deviceLeft.SendHapticImpulse(0, amplitude, duration);
        deviceRight.SendHapticImpulse(0, amplitude, duration);
    }
}
