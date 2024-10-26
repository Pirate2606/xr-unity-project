using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] GameObject platform;
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject startButton;
    [SerializeField] GameObject exitButton;


    public void BeginGame()
    {
        platform.SetActive(true);
        mainMenu.SetActive(false);
        startButton.SetActive(false);
        exitButton.SetActive(false);
    }
}
