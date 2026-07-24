using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI; // Necessário para ler os botões do Quest

public class MenuNoComando : MonoBehaviour
{
    [Header("Configuração do Menu")]
    public GameObject painelDoMenu; // Arrasta o teu Canvas para aqui
    public InputActionReference botaoDeMenu; // Vamos definir qual é o botão no Unity
    public GameObject checklist;

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
            GameObject toggleObj = GameObject.Find("Toggle0" + i);
            Toggle toggle = toggleObj.GetComponent<Toggle>();
            switch (i)
            {
                case 1:
                    bool isSelectedSkinRash = GameData.SelectedSkin == 2 || GameData.SelectedSkin == 3;
                    GameData.GamePoints["SkinRash"] = toggle.isOn && isSelectedSkinRash ? 5 : 0;
                    break;
                case 2:
                    bool isSelectedSkinAstenose = GameData.SelectedSkin == 4;
                    GameData.GamePoints["SkinAstenose"] = toggle.isOn && isSelectedSkinAstenose ? 5 : 0;
                    break;
                case 3:
                    bool isHighTemperature = GameData.SelectedTemperature >= 38.0f;
                    GameData.GamePoints["Temperature"] = toggle.isOn && isHighTemperature ? 5 : 0;
                    break;
                case 4:
                    bool isAbnormalPulse = GameData.SelectedAudio > 1;
                    GameData.GamePoints["Pulse"] = toggle.isOn && isAbnormalPulse ? 5 : 0;
                    break;
                case 5:
                    bool isNotAVFCollapsible = GameData.SelectedBump > 1;
                    GameData.GamePoints["Elevation"] = toggle.isOn && isNotAVFCollapsible ? 5 : 0;
                    break;
                case 6:
                    bool isHyperpulsatilePulse = GameData.SelectedAVFPulse > 1;
                    GameData.GamePoints["Palpation"] = toggle.isOn && isHyperpulsatilePulse ? 5 : 0;
                    break;
                default:
                    break;
            }
        }
    }
}