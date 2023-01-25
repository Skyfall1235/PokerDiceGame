//////////////////////////////////////////////////////
// Assignment/Lab/Project: PokerManager
//Name: Wyatt Murray
//Section: 2023SP.SGD.213.2172
//Instructor: Brian Sowers
// Date: 1/18/23
//////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PokerManager : MonoBehaviour
{
    [Header("Buttons")]
    private int[] playersArray = new int[5];
    private int[] computersArray = new int[5];
    int playerscore = 0;
    int computerscore = 0;
    private int playerRollCounter = 0;
    [SerializeField] private Button startButton;
    [SerializeField] private Button submitButton;
    [SerializeField] private Button RollButton;
    [SerializeField] private TextMeshProUGUI ResponseText;
    [SerializeField] private TextMeshProUGUI rollCounter;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckScore(int[] User, int WhosScore)
    {
        //sets a counter for how many times we
        int doubles = 0;
        int triples = 0;
        int quads = 0;
        int quints = 0;
        List<int> singlesList = new List<int>();
        List<int> doublesList = new List<int>();
        List<int> triplesList = new List<int>();
        List<int> quadsList = new List<int>();
        List<int> quintupleList = new List<int>();

        //use a foreach loop to iterate hrough each item
        foreach (int index in User)
        {
            if (!singlesList.Contains(index))
            {
                singlesList.Add(index);
            }
            else if (!doublesList.Contains(index) && singlesList.Contains(index))
            {
                doublesList.Add(index);
            }
            else if (!triplesList.Contains(index) && doublesList.Contains(index))
            {
                triplesList.Add(index);
            }
            else if (!quadsList.Contains(index) && triplesList.Contains(index))
            {
                quadsList.Add(index);
            }
            else if (!quintupleList.Contains(index) && quadsList.Contains(index))
            {
                quintupleList.Add(index);
            }

        }
        doubles = doublesList.Count;
        triples = triplesList.Count;
        quads = quadsList.Count;
        quints = quintupleList.Count;

        if (quints == 1)
        {
            //player has a 5 of a kind
            WhosScore = 6;
        }
        else if (triples == 1)
        {
            //player has a full house
            Debug.Log("full house");
            WhosScore = 5;
        }
        else if (triples == 1 && doubles == 1)
        {
            //player has a full house
            Debug.Log("full house");
            WhosScore = 4;
        }
        else if (triples == 1)
        {
            //player has triples but no full house
            Debug.Log("a triple");
            WhosScore = 3;
        }
        else if (doubles == 2)
        {
            //player has 2 doubles
            Debug.Log("2 doubles");
            WhosScore = 2;
        }
        else if (doubles == 1)
        {
            //player only has 1 double
            Debug.Log("a double");
            WhosScore = 1;
        }

        //check if the previous item is 1 lower, the same, or higher.
    }

    void RollDice(int[] User)
    {
        //loads up every index position with a new random numbert between(including) 1 and 6 every time its called
        for (int index = 0; index < User.Length; index++)
        {
            User[index] = UnityEngine.Random.Range(1, 7);
        }
        //sort the areay after you assign the roles

        Array.Sort(User);
        Debug.Log(string.Join(", ", User));
    }
    bool RollCounter()
    {
        //simply returns true or false based on the counter
        if (playerRollCounter < 3)
        {
            playerRollCounter++;
            return true;
            //set the text to playerroll counter
        }
        else
        {
            return false;
        }
    }
    void PlayerCPUScoreComparison()
    {
        //set the text of the response text to who won
        if (playerscore > computerscore)
        {
            Debug.Log("the player won");
        }
        else
        {
            Debug.Log("the computer won");
        }
    }
    public void PlayerRoll()
    {
        //roll the player hand and display the current top
        if (RollCounter())
        {
            RollDice(playersArray);
        }
        
    }
    public void Submit()
    {
        //rolls the nPC
        RollDice(computersArray);
        CheckScore(playersArray, playerscore);
        CheckScore(computersArray, computerscore);
        PlayerCPUScoreComparison();
    }
    public void Quit()
    {
        //Application.Quit();
    }
}
//The game should include a title and instructions on how to play the game.
//When the player clicks on a Play button, 5 dice are rolled for the player and the outcome is displayed. This includes the individual rolls and the type of hand. 
//The player has then the choice to either roll again or check for the winner.
//The player can only roll two more times after the first roll for a total of three rolls.
//Once the player’s turn ends, 5 dice are rolled for the computer and the outcome is displayed, to include the 5 rolls and the type of hand.
//The winner is displayed as well (tie when applicable).
//There should be a way to play the game again.
//Code should include functions and arrays to limit redundancies.
//All UI elements, variables, and methods must be named meaningfully and follow naming conventions discussed during the lecture.
//The project must be organized and named as dictated in the submission guidelines of the course.

