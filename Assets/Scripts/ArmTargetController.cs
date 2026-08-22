using UnityEngine;

public class ArmTargetController : MonoBehaviour
{
    [Header("O objeto o jogador agarra")]
    public Transform proxyGrab;

    [Header("Limites")]
    public float yMinimo = 0f;
    public float yMaximo = 0.5f;
    public float xMinimo = 0f;
    public float xMaximo = 0.5f;

    // Guarda as posições que não queremos mexer
    private float posicaoZFixa;

    void Start()
    {
        posicaoZFixa = transform.localPosition.z;
    }

    void Update()
    {
        if (proxyGrab != null && transform.parent != null)
        {
            // 1. Descobre onde está o Proxy (a mão do jogador) em relação ao corpo do paciente
            Vector3 posLocalDoProxy = transform.parent.InverseTransformPoint(proxyGrab.position);

            // 2. Prepara a nova posição do braço
            Vector3 novaPosicao = transform.localPosition;

            novaPosicao.z = posicaoZFixa;
            novaPosicao.y = Mathf.Clamp(posLocalDoProxy.y, yMinimo, yMaximo);
            novaPosicao.x = Mathf.Clamp(posLocalDoProxy.x, xMinimo, xMaximo);

            // 5. Aplica a posição final ao IK Target
            transform.localPosition = novaPosicao;
        }
    }
}