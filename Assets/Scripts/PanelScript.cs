using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelScript : MonoBehaviour
{

    [SerializeField]
    private GameObject textWinner;

    [SerializeField]
    private GameObject textLooser;

    [SerializeField]
    private GameObject startButton;

    [SerializeField]
    private GameObject stopButton;

    
    // Start is called before the first frame update
    void Start()
    {
        ShowStart();
        hideEverything();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void displayWinnerText()
    {
        textWinner.SetActive(true);
        textLooser.SetActive(false);
    }

    public void displayLooserText()
    {
        textLooser.SetActive(true);
        textWinner.SetActive(false);
    }

    public void hideEverything()
    {
        textLooser.SetActive(false);
        textWinner.SetActive(false);
    }

    public void ShowStart()
    {
        stopButton.SetActive(false);
        startButton.SetActive(true);
    }

    public void ShowStop()
    {
        stopButton.SetActive(true);
        startButton.SetActive(false);
    }

}
