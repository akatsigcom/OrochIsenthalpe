using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ANQ_TextWords : MonoBehaviour
{
    public static Dictionary<string, string> dict = new Dictionary<string, string>  // creation of a morse dictionary
        {
            { "A", ". _ " },
            { "B", "_ . . . " },
            { "C", "_ . _ . " },
            { "D", "_ . . " },
            { "E", ". " },
            { "F", ". . _ . " },
            { "G", "_ _ . " },
            { "H", ". . . . " },
            { "I", ". . " },
            { "J", ". _ _ _ " },
            { "K", "_ . _ " },
            { "L", ". _ . . " },
            { "M", "_ _ " },
            { "N", "_ . " },
            { "O", "_ _ _ " },
            { "P", ". _ _ . " },
            { "Q", "_ _ . _ " },
            { "R", ". _ . " },
            { "S", ". . . " },
            { "T", "_ " },
            { "U", ". . _ " },
            { "V", ". . . _ " },
            { "W", ". _ _ " },
            { "X", "_ . . _ " },
            { "Y", "_ . . _ " },
            { "Z", "_ _ . . " },
            { "1", ". _ _ _ _ " },
            { "2", ". . _ _ _ " },
            { "3", ". . . _ _ " },
            { "4", ". . . . _ " },
            { "5", ". . . . . " },
            { "6", "_ . . . . " },
            { "7", "_ _ . . . " },
            { "8", "_ _ _ . . " },
            { "9", "_ _ _ _ . " },
            { "0", "_ _ _ _ _ " },
            { " ", "  " }
        };

    string[] animals = { "CHEVREUIL", "SANGLIER", "PERDRIX", "LAPIN", "FAISAN", "CERF" }; // lists of animals, numbers and directions
    string[] numbers = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
    string[] directions = { "GAUCHE", "DROITE", "HAUT", "BAS" };

    public static string animalWord;
    public static string numberWord;
    public static string directionWord;

    public static string animalMorse;
    public static string numberMorse;
    public static string directionMorse;

    

    public static string ToMorse(string word) // function to translate a word in morse
    {
        string wordMorse = "";
        foreach (char letter1 in word)
        {
            wordMorse = wordMorse + dict[letter1.ToString()] + "  ";
        }
        wordMorse = wordMorse.Remove(wordMorse.Length - 2); // delete the last two spaces
        return wordMorse;
    }
    

    // Start is called before the first frame update
    void Start()
    {

        animalWord = animals[Random.Range(0, animals.Length)];          // select randomly an animal, number and direction 
        numberWord = numbers[Random.Range(0, numbers.Length)];
        directionWord = directions[Random.Range(0, directions.Length)];
        Text textWords = GetComponent<Text>();
        textWords.text = animalWord + ", " + numberWord + ", " + directionWord;

        animalMorse = ToMorse(animalWord);
        numberMorse = ToMorse(numberWord);
        directionMorse = ToMorse(directionWord);
    }
}
