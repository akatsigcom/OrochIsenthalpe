using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ANQ_GenerateBigButterfly : MonoBehaviour
{
    public GameObject bigButterfly;

    string[] telecomWords = { "Shannon", "Telecom", "Huffman" };  
    public static string rightBrailleWord;
    int setBigButterflyNumber;
    public static int bigButterflyNumber;

    private int inOrder = 0;
    public static bool rightOrder = false;

    List<GameObject> cloneButterfly = new List<GameObject>();
    public List<Sprite> butterflyImages = new List<Sprite>();



    void Awake()
    {
        rightBrailleWord = telecomWords[Random.Range(0, telecomWords.Length)];  // select randomly a word
        setBigButterflyNumber = rightBrailleWord.Length + 1; // +1 for capital letters
        bigButterflyNumber = setBigButterflyNumber-1;
    }

    void Start()
    {
        for (int i = 0; i <= bigButterflyNumber; i++)  // butterflies identified by number and then a corresponding image is given to them 
        {
            cloneButterfly.Add((GameObject)Instantiate(bigButterfly, new Vector3(2*i-bigButterflyNumber, 0, 0), Quaternion.identity));
            cloneButterfly[i].GetComponent<Image>().sprite=butterflyImages[i];
        }

        for(int j=0 ; j<=10; j++)   // shuffling
        {
            Swap(cloneButterfly[Random.Range(0, cloneButterfly.Count)], cloneButterfly[Random.Range(0, cloneButterfly.Count)]);
        }
    }

    private void Update()
    {
        orderComparison();
    }

    void Swap(GameObject butterfly1,GameObject butterfly2)
    {
        Vector3 pos1 = butterfly1.transform.position;
        butterfly1.transform.position = butterfly2.transform.position;
        butterfly2.transform.position = pos1;
    }

    void orderComparison()  // if right order boolean for interaction ok
    {
        for (int i = 0; i < bigButterflyNumber; i++)
        {
            if (cloneButterfly[i].transform.position.x < cloneButterfly[i + 1].transform.position.x)
            {
                inOrder++;
            }
        }
        if (inOrder == bigButterflyNumber)
        {
            rightOrder = true;
        }
        else
        {
            rightOrder = false;
        }
        inOrder = 0;
    }
  
}
