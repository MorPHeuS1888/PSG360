using UnityEngine;

public class TabManager : MonoBehaviour
{
    [Header("Arrasta os Painéis das tuas páginas para aqui")]
    [Tooltip("A ordem aqui é importante. O elemento 0 será aberto com o botão configurado com o número 0.")]
    public GameObject[] paginas;

    void Start()
    {
        // Opcional: Quando o jogo começa, garante que apenas a primeira página (índice 0) está visível.
        AbrirPagina(0);
    }

    // Esta é a função que os teus botões vão chamar no evento On Click ()
    public void AbrirPagina(int indexDaPagina)
    {
        // Percorre todas as páginas que configuraste no array
        for (int i = 0; i < paginas.Length; i++)
        {
            // Se o índice atual for igual ao botão que clicaste, ativa a página. 
            // Caso contrário, desativa-a.
            if (i == indexDaPagina)
            {
                paginas[i].SetActive(true);
            }
            else
            {
                paginas[i].SetActive(false);
            }

            // Uma forma mais avançada e curta de escrever o bloco "if/else" acima é:
            // paginas[i].SetActive(i == indexDaPagina);
        }
    }
}