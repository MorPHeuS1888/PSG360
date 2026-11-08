using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    public int CurrentPage = 0;
    public GameObject Page1;
    public GameObject Page2;
    public GameObject Page3;
    public GameObject Page4;
    public Button NextButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        NextButton.onClick.AddListener(OnNextButtonClicked);
    }

    private void OnNextButtonClicked()
    {
        Debug.Log("Next button clicked");
        CurrentPage++;
        if (CurrentPage > 4) // Assuming there are 4 pages in the tutorial
        {
            CurrentPage = 1; // Loop back to the first page
        }

        // Desativa todas as páginas para garantir que apenas uma fica visível
        Page1.SetActive(false);
        Page2.SetActive(false);
        Page3.SetActive(false);
        Page4.SetActive(false);

        // Ativa a página correspondente ao valor de CurrentPage
        if (CurrentPage == 1) Page1.SetActive(true);
        else if (CurrentPage == 2) Page2.SetActive(true);
        else if (CurrentPage == 3) Page3.SetActive(true);
        else if (CurrentPage == 4) Page4.SetActive(true);
    }
}
