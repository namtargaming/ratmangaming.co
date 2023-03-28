using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class score : MonoBehaviour
{
    private string scoreText;
    private string printText;
    public int playerScore;
    public TextMeshPro text;
    public TextMeshPro textGUI;
    // Start is called before the first frame update
    void Start()
    {
        GameObject i = GameObject.Find("newPlayer/Main Camera/GuiScore");
        textGUI = i.GetComponent<TextMeshPro>();
        playerScore = 0;
    }

    // Update is called once per frame
    void Update()
    {

        scoreText = playerScore.ToString();
        printText = "score: " + scoreText;
        text.text = printText;
        textGUI.text = printText;
    }
}
