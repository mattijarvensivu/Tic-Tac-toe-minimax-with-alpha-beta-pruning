using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    private string playerSide;
    private string opponentSide;
    private string currentturn;
    //private SimpleAi Ai;
    private SmartAi Ai;
    public Text[] buttonlist;
    public Text WinText;
    public Text XCounter;
    public Text OCounter;
    public Text TieCounter;
    public Button restartButton;
    // int number = 0;
    public int xcounter;
    public int ocounter;
    public int tiecounter;
    void Start()
    {
         //SimpleAi Ai_ = new SimpleAi();
        SmartAi Ai_ = new SmartAi();
        Ai = Ai_;

        restartButton.onClick.AddListener(RestartClick);

       // AiTurn();

    }
    void RestartClick()
    {
        for (int i = 0; i < buttonlist.Length; i++)
        {
            buttonlist[i].GetComponentInParent<Button>().interactable = true;
            buttonlist[i].text = "";  
        }
        WinText.text = "";
        currentturn = "X";
    }
    public void SetGameControllerReferenceButtons()
    {
        for(int i=0; i<buttonlist.Length; i++)
        {
            buttonlist[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
           
        }
    }
    void Awake()
    {
        
        SetGameControllerReferenceButtons();
        currentturn = "X";
        playerSide = "X";
        opponentSide = "O";



}


    public string GetPlayerSide()
    {
        return currentturn;
    }
    public void EndTurn()
    {
        if (buttonlist[0].text == playerSide && buttonlist[1].text == playerSide && buttonlist[2].text == playerSide)
        {
            xcounter++;
            ocounter++;
            WinText.text = playerSide + " Wins";
            XCounter.text = xcounter.ToString();
            
            GameOver();
            
        }else if (buttonlist[0].text == opponentSide && buttonlist[1].text == opponentSide && buttonlist[2].text == opponentSide)
        {
            ocounter++;
            WinText.text = opponentSide + " Wins";
           
            OCounter.text = ocounter.ToString();
            GameOver();
        }
        if (buttonlist[3].text == playerSide && buttonlist[4].text == playerSide && buttonlist[5].text == playerSide)
        {
            xcounter++;
            XCounter.text = xcounter.ToString();
            
            WinText.text = playerSide + " Wins";
            GameOver();

        }else if (buttonlist[3].text == opponentSide && buttonlist[4].text == opponentSide && buttonlist[5].text == opponentSide)
        {
            ocounter++;
            OCounter.text = ocounter.ToString();
            WinText.text = opponentSide + " Wins";
            GameOver();
        }

            if (buttonlist[6].text == playerSide && buttonlist[7].text == playerSide && buttonlist[8].text == playerSide)
        {
            xcounter++;
            XCounter.text = xcounter.ToString();
           
            WinText.text = playerSide + " Wins";
            GameOver();
        }
            else if (buttonlist[6].text == opponentSide && buttonlist[7].text == opponentSide && buttonlist[8].text == opponentSide)
        {
            ocounter++;
            OCounter.text = ocounter.ToString();
            WinText.text = opponentSide + " Wins";
            GameOver();
        }

        if (buttonlist[0].text == playerSide && buttonlist[3].text == playerSide && buttonlist[6].text == playerSide)
        {
            xcounter++;
            XCounter.text = xcounter.ToString();
            WinText.text = playerSide + " Wins";
            GameOver();

        }else if (buttonlist[0].text == opponentSide && buttonlist[3].text == opponentSide && buttonlist[6].text == opponentSide)
        {
            ocounter++;
            OCounter.text = ocounter.ToString();
            WinText.text = opponentSide + " Wins";
            GameOver();
        }

        if (buttonlist[1].text == playerSide && buttonlist[4].text == playerSide && buttonlist[7].text == playerSide)

        {
            xcounter++;
            XCounter.text = xcounter.ToString();
            WinText.text = playerSide + " Wins";
            GameOver();
        }else if (buttonlist[1].text == opponentSide && buttonlist[4].text == opponentSide && buttonlist[7].text == opponentSide)
        {
            ocounter++;
            OCounter.text = ocounter.ToString();
            WinText.text = opponentSide + " Wins";
            GameOver();
        }

            if (buttonlist[2].text == playerSide && buttonlist[5].text == playerSide && buttonlist[8].text == playerSide )

        {
            xcounter++;
            XCounter.text = xcounter.ToString();
            WinText.text = playerSide + " Wins";
            GameOver();
        }else if (buttonlist[2].text == opponentSide && buttonlist[5].text == opponentSide && buttonlist[8].text == opponentSide)
        {
            ocounter++;
            OCounter.text = ocounter.ToString();
            WinText.text = opponentSide + " Wins";
            GameOver();
        }

       if (buttonlist[0].text == playerSide && buttonlist[4].text == playerSide && buttonlist[8].text == playerSide)

        {
            xcounter++;
            XCounter.text = xcounter.ToString();
            WinText.text = playerSide + " Wins";
            GameOver();
        }else if (buttonlist[0].text == opponentSide && buttonlist[4].text == opponentSide && buttonlist[8].text == opponentSide)
        {
            ocounter++;
            OCounter.text = ocounter.ToString();
            WinText.text = opponentSide + " Wins";
            GameOver();
        }

            if (buttonlist[2].text == playerSide && buttonlist[4].text == playerSide && buttonlist[6].text == playerSide)
        {
            xcounter++;
            XCounter.text = xcounter.ToString();
            WinText.text = playerSide + " Wins";
            GameOver();

        }else if (buttonlist[2].text == opponentSide && buttonlist[4].text == opponentSide && buttonlist[6].text == opponentSide)
        {

            ocounter++;
            OCounter.text = ocounter.ToString();
            WinText.text = opponentSide + " Wins";
            GameOver();
        }

          else  if (buttonlist[0].text != "" && buttonlist[1].text != ""&& buttonlist[2].text != "" && buttonlist[3].text != ""&& buttonlist[4].text != "" && buttonlist[5].text != ""&& buttonlist[6].text != "" && buttonlist[7].text != "" && buttonlist[8].text != "")
        {
            GameOver();
            tiecounter++;
            WinText.text = "Tie!";
            TieCounter.text = tiecounter.ToString();
          
        }
        else { ChangeSides(); }
       
    }
    void ChangeSides()
    {
        currentturn = (currentturn == "X") ? "O" : "X";
        if(currentturn == "O")
        {
            AiTurn();
        }
      
    }
    public void AiTurn()
    {
        //int aichoice = Ai.Aiturn(buttonlist, "O", "X");
            int aichoice = Ai.findBestMove(buttonlist);
            // Debug.Log(aichoice);
            buttonlist[aichoice].GetComponentInParent<Button>().interactable = false;
            buttonlist[aichoice].text = "O";

        
        EndTurn();
       
    }
    public void GameOver()
    {
        for(int i = 0; i < buttonlist.Length; i++)
        {
            buttonlist[i].GetComponentInParent<Button>().interactable = false;
        }
        Application.Quit();
    }
}
