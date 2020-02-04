using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game state
    int level;
    enum Screen { MainMenu, Password, Win }
    Screen currentScreen;
    string correctPassword;

    // Game configuration data
    const string menuHint = "You may type menu at any time.";
    string playAgain = "Play again for a greater challenge!";
    string[] easyPasswords = { "Table", "Fruit", "Style", "Blunt", "Erase" };
    string[] mediumPasswords = { "Pumpkin", "Strawberry", "Thankful", "External", "Insight" };
    string[] hardPasswords = { "Thoughtfulness", "Cardiovascular", "Antidepressant", "Warmongering", "Liquidity" };


    void Start()
    {
        ShowMainMenu();

    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("How much of a hacker are you?");
        Terminal.WriteLine("1. Noob");
        Terminal.WriteLine("2. Perty good");
        Terminal.WriteLine("3. Pr0 h4XX0r!");
        Terminal.WriteLine("Enter your level:");
    }

    void OnUserInput(string input)
    {
        if (input.ToLower() == "menu")
        {
            ShowMainMenu();
        }
        else if(input.ToLower() == "quit" || input.ToLower() == "exit" || input.ToLower() == "close")
        {
            Terminal.WriteLine("If on the web, close the tab.");
            Application.Quit();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else if (input == "007")
        {
            Terminal.WriteLine("Please select a difficulty, Mr Bond");
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level");
            Terminal.WriteLine(menuHint);
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine(menuHint);
        Terminal.WriteLine("Enter password, hint: " + correctPassword.Anagram().ToLower());
    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                correctPassword = easyPasswords[Random.Range(0, easyPasswords.Length)];
                break;
            case 2:
                correctPassword = mediumPasswords[Random.Range(0, mediumPasswords.Length)];
                break;
            case 3:
                correctPassword = hardPasswords[Random.Range(0, hardPasswords.Length)];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if (input.ToLower() == correctPassword.ToLower())
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        Terminal.WriteLine(menuHint);
        ShowLevelReward();
    }

    void ShowLevelReward()
    {
        if (level == 1)
        {
            switch (correctPassword)
            {
                case "Table":
                    Terminal.WriteLine("Correct! Table for one!");
                    Terminal.WriteLine(@"
_________________
|_______________|
  / /     / /
 / /     / /
/_/     /_/
"
                    );
                    break;
                case "Fruit":
                    Terminal.WriteLine("Correct! Have a pear!");
                    Terminal.WriteLine(@"
 ,(.
(   )
 `''
"
    );
                    break;
                case "Style":
                    Terminal.WriteLine("Correct! Hacking with style!");
                    Terminal.WriteLine(@"
  _________ __          .__          
 /   _____//  |_ ___.__.|  |   ____  
 \_____  \\   __<   |  ||  | _/ __ \ 
 /        \|  |  \___  ||  |_\  ___/ 
/_______  /|__|  / ____||____/\___  >
        \/       \/               \/ 
"
    );
                    break;
                case "Blunt":
                    Terminal.WriteLine("Correct! Blunt hacking!");
                    Terminal.WriteLine(@"
  ____   _      __ __  ____   ______ 
|    \ | |    |  |  ||    \ |      |
|  o  )| |    |  |  ||  _  ||      |
|     || |___ |  |  ||  |  ||_|  |_|
|  O  ||     ||  :  ||  |  |  |  |  
|     ||     ||     ||  |  |  |  |  
|_____||_____| \__,_||__|__|  |__|                                 
"
    );
                    break;
                case "Erase":
                    Terminal.WriteLine("Correct! Erase ftw!");
                    break;
                default:
                    Debug.LogError("Error");
                    break;
            }
            Terminal.WriteLine(playAgain);
        }
        else if (level == 2)
        {
            switch (correctPassword)
            {
                case "Pumpkin":
                    Terminal.WriteLine("Correct! Halloweeeen?!");
                    Terminal.WriteLine(@"
                  ___
               ___)__|_
          .-*'          '*-,
         /      /|   |\     \
        ;      /_|   |_\     ;
        ;   |\           /|  ;
        ;   | ''--...--'' |  ;
         \  ''---.....--''  /
          ''*-.,_______,.-*'   
"
                    );
                    break;
                case "Strawberry":
                    Terminal.WriteLine("Correct! Have a strawberry!");
                    Terminal.WriteLine(@"
         \VW/
       .::::::.
       ::::::::
       '::::::'
        '::::'
         `'`
"
    );
                    break;
                case "Thankful":
                    Terminal.WriteLine("Correct! Hacking with style!");
                    break;
                case "External":
                    Terminal.WriteLine("Correct! Did you have external help?");
                    break;
                case "Insight":
                    Terminal.WriteLine("Correct! You must have alot of insight!");
                    Terminal.WriteLine(@"
   _   _   _   _   _   _   _  
  / \ / \ / \ / \ / \ / \ / \ 
 ( I | n | s | i | g | h | t )
  \_/ \_/ \_/ \_/ \_/ \_/ \_/                           
"
    );
                    break;
                default:
                    Debug.LogError("Error");
                    break;

            }
            Terminal.WriteLine(playAgain);
        }
        else if (level == 3)
        {
                    switch (correctPassword)
                    {
                        case "Thoughtfulness":
                            Terminal.WriteLine("Correct! Nice thoughtfulness!");
                            break;
                        case "Cardiovascular":
                            Terminal.WriteLine("Correct! Take care of your heart!");
                            break;
                        case "Antidepressant":
                            Terminal.WriteLine("Correct! Take your pills!");
                            Terminal.WriteLine(@"
      ,.----.   ,.----.    
     //  \   \ //  \   \   
     \\   \  / \\   \  /
      `'----'   `'----'    
"
            );
                            break;
                        case "Warmongering":
                            Terminal.WriteLine("Correct! Have some axes!");
                            Terminal.WriteLine(@"
(Y) (X) (=) (>+<) /`-'\
 |   |   |    |   \,T./
 |   |   |    |     |
                    |                              
"
            );
                            break;
                        case "Liquidity":
                            Terminal.WriteLine("Correct! Cash flows!!");
                            Terminal.WriteLine(@"
|#######====================#######|
|#(1)*UNITED STATES OF AMERICA*(1)#|
|#**          /===\   ********  **#|
|*# {G}      | (') |             #*|
|#*  ******  | /v\ |    O N E    *#|
|#(1)         \===/            (1)#|
|##=========ONE DOLLAR===========##|
------------------------------------
"
            );
                            break;
                        default:
                            Debug.LogError("Error");
                            break;
                    }
        }

    }
}
