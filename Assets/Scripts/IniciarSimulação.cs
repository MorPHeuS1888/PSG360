using UnityEngine;

public class GerenciadorBriefing : MonoBehaviour
{
    // Arrastas o objeto do Painel (ou o Canvas) para aqui no Inspector
    public GameObject painelBriefing;

    public void ComeçarSimulacao()
    {
        GameData.SelectAudio();  // Seleciona um áudio aleatório
        GameData.SelectSkin();   // Seleciona uma skin aleatória
        GameData.SelectBump();   // Seleciona um bump aleatório
        painelBriefing.SetActive(false);   // Esconde o painel
        Debug.Log($"Simulação Iniciada com os seguintes parâmetros:" +
                  $"Sala {GameData.SelectedRoom} Áudio {GameData.SelectedAudio} Skin {GameData.SelectedSkin} Bump {GameData.SelectedBump}");
    }
}