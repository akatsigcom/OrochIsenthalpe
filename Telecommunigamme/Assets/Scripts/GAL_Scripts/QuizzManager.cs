using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.Xml.Serialization;

public class QuizzManager : MonoBehaviour
{
    public Button AnswerButton1;
    public Text TextButton1;
    public Button AnswerButton2;
    public Text TextButton2;
    public Button AnswerButton3;
    public Text TextButton3;


    private bool WaitAnswer;

    public Text QuestionText;

    private List<int> listResult = new List<int>();

    private void Start()
    {
        // AnswerButton1.enabled = false;
        // AnswerButton2.enabled = false;
        //AnswerButton3.enabled = false;
        // QuestionText.enabled = false;
        WaitAnswer = false;

    }

    private void Update()
    {
       /* AnswerButton1.enabled = WaitAnswer;
        AnswerButton2.enabled = WaitAnswer;
        AnswerButton3.enabled = WaitAnswer;
        QuestionText.enabled = WaitAnswer;
        */
    }



    public void StartQuizz(TreeDialogue quizz)
    {
        Debug.Log("Execution Start Quizz");

        int node_id = 0;


        while (node_id != -1)
        {
            node_id = Run_node(quizz.Nodes[node_id]);
        }
        Debug.Log("fin du quizz");
        Debug.Log(listResult[listResult.Count - 1]);

    }

    public int Run_node(TreeDialogueNode node)
    {
        Debug.Log("execution d'un noeud");
        Debug.Log(node.Text.discution[0].name);
        
        int nextNode = -1;

        FindObjectOfType<OnClickDialogueTrigger>().TriggerDialogue(node.Text);

        bool flag1 = true;

        while (flag1)
        {
            if (FindObjectOfType<OnClickDialogueManager>().animator.GetBool("IsOpen") == false)
            {
                flag1 = false;
            }
            else { }
        }

        Debug.Log("le dialogue s'est fini");

         
        WaitAnswer = true;

        TextButton1.text = node.Options[0].Text;
        TextButton2.text = node.Options[1].Text;
        TextButton3.text = node.Options[2].Text;
        QuestionText.text = node.Question;

        /*bool flag2 = true;
        while (flag2)
        {
            if (WaitAnswer == false)
            {
                flag2 = false;
            }
            else { }
        }
        
        AnswerButton1.enabled = false;
        AnswerButton2.enabled = false;
        AnswerButton3.enabled = false;
        QuestionText.enabled = false;

        nextNode = node.Options[listResult[listResult.Count -1]].DestinationNodeID;*/
        return nextNode;
    }

    public void SendAnswer1()
    {
        listResult.Add(0);
        Debug.Log(listResult[listResult.Count -1]);
        WaitAnswer = false;
    }
    public void SendAnswer2()
    {
        listResult.Add(1);
        Debug.Log(listResult[listResult.Count - 1]);
        WaitAnswer = false;
    }
    public void SendAnswer3()
    {
        listResult.Add(2);
        Debug.Log(listResult[listResult.Count - 1]);
        WaitAnswer = false;
    }



}
