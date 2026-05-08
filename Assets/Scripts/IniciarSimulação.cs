using UnityEngine;

public class GerenciadorBriefing : MonoBehaviour
{
    // Arrastas o objeto do Painel (ou o Canvas) para aqui no Inspector
    public GameObject painelBriefing;

    public void ComeçarSimulacao()
    {
        // Esconde o painel
        painelBriefing.SetActive(false);

        // Aqui poderemos adicionar no futuro o código para ativar 
        // o paciente ou o cronómetro da sessão
        Debug.Log("Simulação Iniciada!");
    }
}