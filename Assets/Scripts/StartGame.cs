using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] GameObject platform;
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject startButton;
    [SerializeField] GameObject exitButton;
    [SerializeField] GameObject instructions;


    public void BeginGame()
    {
        platform.SetActive(true);
        mainMenu.SetActive(false);
        startButton.SetActive(false);
        exitButton.SetActive(false);
        instructions.SetActive(false);
    }
}
