using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI; // Necessário para ler os botões do Quest

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
        Debug.Log("Simulação finalizada pelo usuário.");
        // Verify checklist to set final score
        ComputeChecklistScore();
        // Carrega a scene de resultados 
        UnityEngine.SceneManagement.SceneManager.LoadScene("Results");
    }

    private void ComputeChecklistScore()
    {
        // get checklist toggle components with name "ToggleXX" 
        for (int i = 1; i <= 6; i++)
        {
            bool isOn = GameData.Checklist[i];
            switch (i)
            {
                case 1:
                    bool isSelectedSkinRash = GameData.SelectedSkin == 2 || GameData.SelectedSkin == 3;
                    GameData.GamePoints["SkinRash"] = (isOn && isSelectedSkinRash || !isOn && !isSelectedSkinRash) ? GameData.ActionPoints : 0;
                    break;
                case 2:
                    bool isSelectedSkinAstenose = GameData.SelectedSkin == 4;
                    GameData.GamePoints["SkinAstenose"] = (isOn && isSelectedSkinAstenose || !isOn && !isSelectedSkinAstenose) ? GameData.ActionPoints : 0;
                    break;
                case 3:
                    bool isHighTemperature = GameData.SelectedTemperature >= 38.0f;
                    GameData.GamePoints["Temperature"] = (isOn && isHighTemperature || !isOn && !isHighTemperature) ? GameData.ActionPoints : 0;
                    break;
                case 4:
                    bool isAbnormalPulse = GameData.SelectedAudio > 1;
                    GameData.GamePoints["Pulse"] = (isOn && isAbnormalPulse || !isOn && !isAbnormalPulse) ? GameData.ActionPoints : 0;
                    break;
                case 5:
                    bool isNotAVFCollapsible = GameData.SelectedBump > 1;
                    GameData.GamePoints["Elevation"] = (isOn && isNotAVFCollapsible || !isOn && !isNotAVFCollapsible) ? GameData.ActionPoints : 0;
                    break;
                case 6:
                    bool isHyperpulsatilePulse = GameData.SelectedAVFPulse > 1;
                    GameData.GamePoints["Palpation"] = (isOn && isHyperpulsatilePulse || !isOn && !isHyperpulsatilePulse) ? GameData.ActionPoints : 0;
                    break;
                default:
                    break;
            }
        }
    }
}