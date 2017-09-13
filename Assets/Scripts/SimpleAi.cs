using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SimpleAi : MonoBehaviour{
    private int status;

    public int Aiturn(Text[] buttonlist, string aimark, string opponentmark)
    {   //Check if you AI win
        status = CanPlayerWin(buttonlist, aimark);
        if(status == -1)
        {   //Check if opponent can win
            status = CanPlayerWin(buttonlist, opponentmark);
            if(status == -1)
            {   //Make two straight
                status = MakeTwoStraight(buttonlist, aimark);
                if(status == -1)
                {   //Make a random move
                   status = RandomMove(buttonlist);
                  
                }
                else { return status; }

            }
            else { return status; }
        }
        else{ return status; }

       return status;
    }

    private int CanPlayerWin( Text[] buttonlist, string aimark)
    {   //Checking if horizontal 2 straght rows
        for (int i = 0; i < 7; i = i+3)
        {
            if ((buttonlist[i].text == aimark && buttonlist[i+1].text == aimark && buttonlist[i+2].text == "")
                || (buttonlist[i].text == aimark && buttonlist[i+1].text == "" && buttonlist[i+2].text ==aimark)
                ||(buttonlist[i].text == "" && buttonlist[i + 1].text == aimark && buttonlist[i + 2].text == aimark))
            {
                for(int j = 0; j<3; j++)
                {
                    if(buttonlist[j+i].text == "")
                    {
                        return i + j;
                    }
                }
            }      
        }
        //Checking if vertical 2 straight rows
        for (int i = 0; i < 3; i++)
        {
            if ((buttonlist[i].text == aimark && buttonlist[i + 3].text == aimark && buttonlist[i + 6].text == "")
                || (buttonlist[i].text == aimark && buttonlist[i + 3].text == "" && buttonlist[i + 6].text == aimark)
                || (buttonlist[i].text == "" && buttonlist[i + 3].text == aimark && buttonlist[i + 6].text == aimark))
            {
                for (int j = 0; j < 7; j=j+3)
                {
                    if (buttonlist[j + i].text == "")
                    {
                        return i + j;
                    }
                }
            }
        }

        //checking if diagonal one straight row
     
            if ((buttonlist[0].text == aimark && buttonlist[4].text == aimark && buttonlist[8].text == "")
                || (buttonlist[0].text == aimark && buttonlist[4].text == "" && buttonlist[8].text == aimark)
                || (buttonlist[0].text == "" && buttonlist[4].text == aimark && buttonlist[8].text == aimark))
            {
                for (int j = 0; j < 9; j = j+4)
                {
                    if (buttonlist[j].text == "")
                    {
                        return j;
                    }
                }
            }
        //checking if diagonal other straight row
            if ((buttonlist[2].text == aimark && buttonlist[4].text == aimark && buttonlist[6].text == "")
                || (buttonlist[2].text == aimark && buttonlist[4].text == "" && buttonlist[6].text == aimark)
                || (buttonlist[2].text == "" && buttonlist[4].text == aimark && buttonlist[6].text == aimark))
            {
                for (int j = 2; j < 7; j = j + 2)
                {
                    if (buttonlist[j].text == "")
                    {
                        return j;
                    }
                }
            }

        return -1;
    }

   private int MakeTwoStraight(Text[] buttonlist, string aimark)
    {
       
        List<int> possiblechoices = new List<int>();
        for (int i = 0; i < 7; i = i + 3)
        {
            if ((buttonlist[i].text == aimark && buttonlist[i + 1].text == "" && buttonlist[i + 2].text == "")
                || (buttonlist[i].text == "" && buttonlist[i + 1].text == aimark && buttonlist[i + 2].text == "")
                || (buttonlist[i].text == "" && buttonlist[i + 1].text == "" && buttonlist[i + 2].text == aimark))
            {
                for (int j = 0; j < 3; j++)
                {
                    if (buttonlist[j + i].text == "")
                    {
                        possiblechoices.Add(j + i);
                    }
                }
            }
        }
        //Checking if vertical 2 straight rows
        for (int i = 0; i < 3; i++)
        {
            if ((buttonlist[i].text == aimark && buttonlist[i + 3].text == "" && buttonlist[i + 6].text == "")
                || (buttonlist[i].text == "" && buttonlist[i + 3].text == aimark && buttonlist[i + 6].text == "")
                || (buttonlist[i].text == "" && buttonlist[i + 3].text == "" && buttonlist[i + 6].text == aimark))
            {
                for (int j = 0; j < 7; j = j + 3)
                {
                    if (buttonlist[j + i].text == "")
                    {
                        possiblechoices.Add(j + i);
                    }
                }
            }
        }

        //checking if diagonal one straight row

        if ((buttonlist[0].text == aimark && buttonlist[4].text == "" && buttonlist[8].text == "")
            || (buttonlist[0].text == "" && buttonlist[4].text == aimark && buttonlist[8].text == "")
            || (buttonlist[0].text == "" && buttonlist[4].text == "" && buttonlist[8].text == aimark))
        {
            for (int j = 0; j < 9; j = j + 4)
            {
                if (buttonlist[j].text == "")
                {
                    possiblechoices.Add(j);
                }
            }
        }
        //checking if diagonal other straight row
        if ((buttonlist[2].text == aimark && buttonlist[4].text == "" && buttonlist[6].text == "")
            || (buttonlist[2].text == "" && buttonlist[4].text == aimark && buttonlist[6].text == "")
            || (buttonlist[2].text == "" && buttonlist[4].text == "" && buttonlist[6].text == aimark))
        {
            for (int j = 2; j < 7; j = j + 2)
            {
                if (buttonlist[j].text == "")
                {
                    possiblechoices.Add(j);
                }
            }
        }
        if (possiblechoices.Count >0) {

            int randomlistvalue = Random.Range(0, possiblechoices.Count);
            int selectedvalue = possiblechoices[Random.Range(0, possiblechoices.Count)];
            return selectedvalue;
        }
        return -1;
       
    }
    private int RandomMove(Text[] buttonlist)
    {
        List<int> possiblechoices = new List<int>();
        for(int i = 0; i< buttonlist.Length; i++)
        {
            if(buttonlist[i].GetComponentInParent<Button>().interactable == true)
            {
                possiblechoices.Add(i);
            }
        }
        if (buttonlist[4].GetComponentInParent<Button>().interactable == true)
        {
            return 4;
        }
       else if (buttonlist[0].GetComponentInParent<Button>().interactable == true) {

            return 0;
        }else if(buttonlist[2].GetComponentInParent<Button>().interactable == true)
        {
            return 2;
        }
        else if (buttonlist[6].GetComponentInParent<Button>().interactable == true) {
            return 6;
        }else if (buttonlist[8].GetComponentInParent<Button>().interactable == true)
        {
            return 8;
        }
        else {
            return possiblechoices[Random.Range(0, possiblechoices.Count)];
            
        }
            
        
      
    }





}
