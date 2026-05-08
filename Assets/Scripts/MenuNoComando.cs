using UnityEngine;
using UnityEngine.InputSystem; // Necessário para ler os botões do Quest

public class MenuNoComando : MonoBehaviour
{
    [Header("Configuração do Menu")]
    public GameObject painelDoMenu; // Arrasta o teu Canvas para aqui
    public InputActionReference botaoDeMenu; // Vamos definir qual é o botão no Unity

    void OnEnable()
    {
        // Começa a ouvir o clique do botão
        botaoDeMenu.action.started += AlternarMenu;
    }

    void OnDisable()
    {
        // Para de ouvir quando o objeto é destruído (boas práticas)
        botaoDeMenu.action.started -= AlternarMenu;
    }

    private void AlternarMenu(InputAction.CallbackContext context)
    {
        // Se o menu está ligado, desliga. Se está desligado, liga.
        bool estadoAtual = painelDoMenu.activeSelf;
        painelDoMenu.SetActive(!estadoAtual);
    }

    // Esta função será chamada pelo botão "Finalizar Simulação" que criaste na UI
    public void FinalizarSimulacao()
    {
        // Carrega a scene de resultados (certifica-te que o nome está igual ao que criaste)
        UnityEngine.SceneManagement.SceneManager.LoadScene("Resultados");
    }
}