using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SmartAi : MonoBehaviour
{

    public class Move
    {

        public int index { get; set; }
        public int score { get; set; }

    }

    string aimark = "O";
    string opponentmark = "X";
    int counter = 0;
    public int findBestMove(Text[] buttonlist)
    {
        counter = 0;
        Move bestmove = minimax(buttonlist, aimark, 0, int.MinValue + 1, int.MaxValue -1);
        Debug.Log(counter);
        Debug.Log("Score" + bestmove.score);
        Debug.Log("Index" + bestmove.index);
        return bestmove.index;
    }

    public Move minimax(Text[] buttonlist, string player, int depth, int alpha, int beta)
    {
        Move move = new Move();
        counter++;
        List<int> freespots = emptySpots(buttonlist);
        if (CheckWin(buttonlist, opponentmark))
        {
            move.score =  depth - 10;
            return move;
        }
        else if (CheckWin(buttonlist, aimark))
        {
            move.score = 10 -depth;
            return move;
        }
        else if (freespots.Count == 0)
        {
            move.score = 0;
            return move;
        }
        depth++;
        List<Move> moves = new List<Move>();
        for (int i = 0; i < freespots.Count; i++)
        {    
            buttonlist[freespots[i]].text = player;
            if (player == aimark)
            {
                int score = minimax(buttonlist, opponentmark, depth, alpha, beta).score;              
                if(score > alpha)
                {
                    alpha = score;
                    move.score = alpha;
                    move.index = freespots[i];
                }
            }
            else
            {      
                int score = minimax(buttonlist, aimark, depth, alpha, beta).score;
                if(score < beta)
                {
                    beta = score;
                    move.score = beta;
                    move.index = freespots[i];
                }     
            }
            buttonlist[freespots[i]].text = "";
            if (alpha >= beta) break;           
        }
        move.score = player == aimark ? alpha : beta;
        return move;
    }
    
    private List<int> emptySpots(Text[] buttonlist)
    {
        List<int> emptyspots = new List<int>();
        for (int i = 0; i < 9; i++)
        {
            if (buttonlist[i].text != "O" && buttonlist[i].text != "X")
            {
                emptyspots.Add(i);
            }
        }
        return emptyspots;
    }


    private Boolean CheckWin(Text[] board, string player)
    {
        if (
       (board[0].text == player && board[1].text == player && board[2].text == player) ||
       (board[3].text == player && board[4].text == player && board[5].text == player) ||
       (board[6].text == player && board[7].text == player && board[8].text == player) ||
       (board[0].text == player && board[3].text == player && board[6].text == player) ||
       (board[1].text == player && board[4].text == player && board[7].text == player) ||
       (board[2].text == player && board[5].text == player && board[8].text == player) ||
       (board[0].text == player && board[4].text == player && board[8].text == player) ||
       (board[2].text == player && board[4].text == player && board[6].text == player)
       )
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
