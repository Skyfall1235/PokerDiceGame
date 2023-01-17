//////////////////////////////////////////////////////
// Assignment/Lab/Project: Guess My Number
//Name: Wyatt Murray
//Section: 2023SP.SGD.213.2172
//Instructor: Brian Sowers
// Date: 1/13/23
//////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;
using TMPro;
//why do these keep generating??
using static System.Net.Mime.MediaTypeNames;
using Unity.VisualScripting;

public class GuessMyNumber : MonoBehaviour
{
    private int randomChosenNumber;
    [SerializeField] private int guessAttempts = 1;
    private int playerGuess;
    private string playerInputText;

    //serialized private becuase i need it available in the inspector, but i dont want it public in the code

    [SerializeField] private GameObject inputFieldObject;
    [SerializeField] private TMP_Text responseText;
    [SerializeField] private GameObject ResetButton;

    // Start is called before the first frame update
    void Start()
    {
        
        //Debug.Log(inputField);
        RandomNumber();
        responseText.SetText("Guess the number between 1 and 100!");
        Debug.Log(randomChosenNumber);
    }

    // Update is called once per frame
    void Update()
    {
        playerInputText = inputFieldObject.GetComponent<TMP_InputField>().text;
        //Debug.Log(inputField);
    }
//    The computer chooses a random number between 1 and 100 (inclusive)
    void RandomNumber()
    {
        randomChosenNumber = Random.Range(1, 101);
    }
    

    void GuessTracker()
    {
        guessAttempts++;
    }
    void PlayerGuess(string input)
    {
        int guessValue;
        //if the string can be counted, store it as an int.
        //wait til a player hits submit, then run the code.
        //take the feild, check if its a number, and if it is compare it to the random number
        //    Input entered by the player must be checked to ensure that a number between 1 and 100 is entered.
        if (int.TryParse(input, out guessValue))
        {
            if(!(guessValue < 0 || guessValue > 100))
            {
                playerGuess = guessValue;
                GuessResponse();
            }
            else
            {
                //If the player enters a number that is not within the given range, adequate feedback should be displayed.
                Debug.Log("Not within the range!");
                responseText.SetText("Not within the range!");
            }
        }
        else
        {
            responseText.SetText("Not an integer!");
            //If the player does not enter a number, adequate feedback should be displayed.
            Debug.Log("Not an int number!");
        }
        //if its not, return with a fail, and iterate up.
    }
    //    After each guess, a message is displayed to let the player know whether the guess was too high or too low.
    void GuessResponse()
    {
        if(playerGuess > randomChosenNumber)
        {
            //wrong! too high. guess lower next time
            Debug.Log("too high");
            responseText.SetText("wrong! too High. guess lower next time");
        }
        else if(playerGuess == randomChosenNumber)
        {
            //yay! you got it right! you win
            //display how many guesses it took
            Debug.Log("correct!");
            Debug.Log($"It took {guessAttempts} tries");
            responseText.SetText($"correct! It took {guessAttempts} tries");
            ResetButton.SetActive(true);
        }
        else
        {
            //wrong! too low. guess higher next time
            Debug.Log("too low");
            responseText.SetText("wrong! too low. guess higher next time");
        }
    }
//    Adequate feedback must be provided to the player after a victory (guess within the six tries) or a loss.The total number of guesses should be displayed when the player wins.If the player does not guess the number, it must be displayed.

    public void SubmitGuess()
    {
        //keep track of how many guesses
        //    The player is allowed 6 guesses.
        if (guessAttempts <= 5)
        {
            //run the code to see if the players guess is correct
            
            PlayerGuess(playerInputText);
            //increment the tracker up by 1
            GuessTracker();
        }
        else
        {
            responseText.SetText("max tries allowed reached");
            ResetButton.SetActive(true);
        }
        
    }
    //    After a victory or loss, the player can click a button to play again.
    public void OnClickReset()
    {
        //instead of resetting the scene, just reset the counter and the random number
        randomChosenNumber = Random.Range(1, 101);
        guessAttempts = 1;
        Debug.Log(randomChosenNumber);
        //empty the field
        responseText.SetText("Guess the number between 1 and 100!");
        ResetButton.SetActive(false);

    }

//    The project must be organized and named as dictated in the submission guidelines of the course.

}
