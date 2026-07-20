using UnityEngine;

public class GerenciadorBriefing : MonoBehaviour
{
    public GameObject painelBriefing;
    public GameObject painelLeftBriefing;

    public void StartSimulation()
    {
        GameData.SelectAudio();  // Seleciona um áudio aleatório
        GameData.SelectSkin();   // Seleciona uma skin aleatória
        GameData.SelectBump();   // Seleciona um bump aleatório
        GameData.SelectAVFPulse(); // Seleciona um pulso AVF aleatório
        GameData.InitializeGamePoints(); // Inicializa os pontos do jogo
        painelBriefing.SetActive(false);   // Esconde o painel
        painelLeftBriefing.SetActive(false); // Esconde o painel esquerdo
        Debug.Log($"Simulação Iniciada com os seguintes parâmetros:" +
                  $"Sala {GameData.SelectedRoom} Áudio {GameData.SelectedAudio} Skin {GameData.SelectedSkin} Bump {GameData.SelectedBump}");
    }
}