using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadorNavegacao : MonoBehaviour
{

    public GameObject painelDeSelecaoDeNiveis;
    public GameObject MenuInicial;

    // No Menu Inicial, o botão PLAY chama esta:
    public void AbrirSelecaoDeNiveis()
    {
        painelDeSelecaoDeNiveis.SetActive(true);
        MenuInicial.SetActive(false);
    }

    public void VoltarMenuInicial() 
    {
        painelDeSelecaoDeNiveis.SetActive(false);
        MenuInicial.SetActive(true);
    }

    // Na Seleção de Níveis, o botão AVF Care chama esta:
    public void AbrirModuloAVF()
    {
        GameData.SelectRoom(); // Seleciona aleatoriamente um quarto
        SceneManager.LoadScene($"Quarto{GameData.SelectedRoom}");
    }

    public void QuitGame()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }
}