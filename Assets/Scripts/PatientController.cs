using System.Collections;
using UnityEngine;

public class PatientController : MonoBehaviour
{
    public GameObject PatientNeck;
    public GameObject PatientLashesL;
    public GameObject PatientLashesR;
    public GameObject PatientLeftHand;
    public GameObject LeftArmWithAudio;
    public GameObject LeftArmWithRenderer;
    public GameObject Bump;

    private float headUpdateInterval = 1f;
    private float rotationSpeedDegPerSec = 8f;
    private float targetAngle = 0f;
    private float currentAngle = 0f;
    private float maxAngle = 3.5f;
    private float lashTargetAngle = -50f;
    private float lashCurrentAngle = -50f;
    private float rotationSpeedLashes = 300f;
    private Vector3 leftHandRestPosition;
    private AudioSource leftArmAudioSource;
    private SkinnedMeshRenderer leftArmRenderer;

    private enum BlinkState { Open, Closing, Opening }
    private BlinkState blinkState = BlinkState.Open;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameData.PatientController = this;
        leftArmAudioSource = LeftArmWithAudio.GetComponent<AudioSource>();
        leftArmRenderer = LeftArmWithRenderer.GetComponent<SkinnedMeshRenderer>();
        leftHandRestPosition = PatientLeftHand.transform.position;

        StartCoroutine(Blink());
        StartCoroutine(MoveHead());
    }

    // Update is called once per frame
    void Update()
    {
        CheckHandHeight();
        RotateHead();
        HandleBlinking();        
    }

    #region patient head management

    private IEnumerator Blink()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(1f, 3f));
        blinkState = BlinkState.Closing;
        lashTargetAngle = -150f;
    }

    private IEnumerator MoveHead()
    {
        while (true)
        {
            yield return new WaitForSeconds(headUpdateInterval);

            float diffX = PatientNeck.transform.position.x - GameData.PlayerCamera.transform.position.x;
            diffX = GetCurveValue(diffX);
            targetAngle = diffX * 10f;
        }
    }

    private void RotateHead() // smoothly rotate head toward player
    {
        float newAngle = Mathf.MoveTowards(currentAngle, targetAngle, rotationSpeedDegPerSec * Time.deltaTime);
        currentAngle = newAngle;
        if (newAngle < 0)
            newAngle = 360 + newAngle;
        PatientNeck.transform.localRotation = Quaternion.Euler(newAngle, PatientNeck.transform.localEulerAngles.y, PatientNeck.transform.localEulerAngles.z);
    }

    private void HandleBlinking()
    {
        switch (blinkState)
        {
            case BlinkState.Closing:
            case BlinkState.Opening:
                float newLashAngle1 = Mathf.MoveTowards(lashCurrentAngle, lashTargetAngle, rotationSpeedLashes * Time.deltaTime);
                lashCurrentAngle = newLashAngle1;
                PatientLashesL.transform.localRotation = Quaternion.Euler(PatientLashesL.transform.localEulerAngles.x, PatientLashesL.transform.localEulerAngles.y, newLashAngle1);
                PatientLashesR.transform.localRotation = Quaternion.Euler(PatientLashesR.transform.localEulerAngles.x, PatientLashesR.transform.localEulerAngles.y, newLashAngle1);
                if (Mathf.Approximately(newLashAngle1, lashTargetAngle))
                {
                    if (blinkState == BlinkState.Closing)
                    {
                        blinkState = BlinkState.Opening;
                        lashTargetAngle = -50f;
                    }
                    else if (blinkState == BlinkState.Opening)
                    {
                        blinkState = BlinkState.Open;
                        StartCoroutine(Blink());
                    }
                }
                break;
            default:
                break;
        }
    }

    private float GetCurveValue(float diffX)
    {
        float sign = Mathf.Sign(diffX);
        float absX = Mathf.Abs(diffX);
        absX = Mathf.Clamp(absX, 0f, maxAngle);
        float t = absX / maxAngle;
        // Aplicar curva de Ease-Out: f(t) = 1 - (1 - t)^2
        float curvedT = 1f - Mathf.Pow(1f - t, 2f);
        return curvedT * maxAngle * sign;
    }

    #endregion

    #region audio management

    public void SetAudioClip()
    {
        // loading audio clip based on selected audio in GameData using 2 digit formatting for the number (e.g., AVF01, AVF02, etc.)
        string audioClipName = $"AVF{GameData.SelectedAudio:D2}";
        AudioClip clip = Resources.Load<AudioClip>($"Audio/{audioClipName}");
        Debug.Log($"Setting audio clip: {audioClipName}");
        leftArmAudioSource.clip = clip;
    }

    public void StopAudio()
    {
        leftArmAudioSource.Stop();
    }

    public void PlayAudio()
    {
        leftArmAudioSource.Play();
    }

    #endregion

    #region skin management

    public void SetSkin()
    {
        string skinName = $"bodyskin{GameData.SelectedSkin:D2}";
        Material skin = Resources.Load<Material>($"Skins/{skinName}");
        Debug.Log($"Setting skin: {skinName}");

        var mats = leftArmRenderer.materials;
        mats[0] = skin;
        leftArmRenderer.materials = mats;
    }

    private void CheckHandHeight()
    {
        float handHeight = PatientLeftHand.transform.position.y;
        float heightDifference = handHeight - leftHandRestPosition.y;
        if (heightDifference > 0.1f)
        {
            Debug.Log($"Hand height: {heightDifference}");
            GameData.GamePoints["CheckElevation"] = GameData.ActionPoints;

            if (GameData.SelectedBump == 1)
                Bump.SetActive(false);
            else
                Bump.SetActive(true);
        }
        else
        {            
            Bump.SetActive(true); 
        }
    }

    #endregion
}
