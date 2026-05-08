using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadorNavegacao : MonoBehaviour
{
    // No Menu Inicial, o botão PLAY chama esta:
    public void AbrirSelecaoDeNiveis()
    {
        SceneManager.LoadScene("Selecaodeniveis");
    }

    // Na Seleção de Níveis, o botão AVF Care chama esta:
    public void AbrirModuloAVF()
    {
        SceneManager.LoadScene("Quarto");
    }

    // Para o botão LEAVE
    public void SairDoJogo()
    {
        Application.Quit();
        Debug.Log("O jogo fechou.");
    }

    // Para o botão Back, em qualquer cena, chama esta função:
    public void VoltarMenuInicial()
    {
        SceneManager.LoadScene("MainMenu");
    }
}