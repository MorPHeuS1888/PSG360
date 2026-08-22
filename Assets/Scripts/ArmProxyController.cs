using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

// Este script deve ir no target_L_proxy
public class ArmProxyController : MonoBehaviour
{
    [Header("O braço restrito (para onde voltar)")]
    public Transform alvoRestrito;

    private XRGrabInteractable grabInteractable;

    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    void OnEnable()
    {
        if (grabInteractable != null)
        {
            grabInteractable.selectExited.AddListener(OnGrabRelease);
        }
    }

    void OnDisable()
    {
        if (grabInteractable != null)
        {
            grabInteractable.selectExited.RemoveListener(OnGrabRelease);
        }
    }

    private void OnGrabRelease(SelectExitEventArgs args)
    {
        if (alvoRestrito != null)
        {
            transform.position = alvoRestrito.position;
            transform.rotation = alvoRestrito.rotation;
        }
    }
}