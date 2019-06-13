using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.Xml.Serialization;

public class QuizzManager : MonoBehaviour
{
    public GameObject AnswerButton1;
    public Text TextButton1;
    public GameObject AnswerButton2;
    public Text TextButton2;
    public GameObject AnswerButton3;
    public Text TextButton3;
    public Text QuestionText;
    public GameObject Panel;

    private TreeDialogue quizz;

    public string quizzPath;

    private bool WaitAnswer;

    private TreeDialogueNode node;

    public OnClickDialogueManager Manager;

    private List<int> listResult = new List<int>();



    private void Start()
    {
        WaitAnswer = false;
        AnswerButton1.SetActive(false);
        AnswerButton2.SetActive(false);
        AnswerButton3.SetActive(false);
        Panel.SetActive(false);

       //quizz = load_quizz(quizzPath);
        //Manager.StartDialogue(quizz.Nodes[0].Text);

        StartQuizz();

    }

    private void Update()
    {
        AnswerButton1.SetActive(WaitAnswer);
        AnswerButton2.SetActive(WaitAnswer);
        AnswerButton3.SetActive(WaitAnswer);
        Panel.SetActive(WaitAnswer);

    }



    public void StartQuizz()
    {
        quizz = load_quizz(quizzPath);

        StartCoroutine(run());

    }


    public IEnumerator run()
    {
        int node_id = 0;

        while (node_id != -1)
        {
            node = quizz.Nodes[node_id];


            Manager.StartDialogue(node.Text);
    
            yield return new WaitForSeconds(1.25f);


            while (Manager.animator.GetBool("IsOpen") == true)
            {
                yield return new WaitForSeconds(0.25f);
            }

            Debug.Log("le dialogue s'est fini");

            WaitAnswer = true;

            TextButton1.text = node.Options[0].Text;
            TextButton2.text = node.Options[1].Text;
            TextButton3.text = node.Options[2].Text;
            QuestionText.text = node.Question;

            while (WaitAnswer == true)
            {
                yield return new WaitForSeconds(0.25f);
            }
            node_id = node.Options[listResult[listResult.Count - 1]].DestinationNodeID;

        }

        ShowResult();
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

    private static TreeDialogue load_quizz(string path)
    {
        XmlSerializer serz = new XmlSerializer(typeof(TreeDialogue));
        StreamReader reader = new StreamReader(path);

        TreeDialogue dia = (TreeDialogue)serz.Deserialize(reader);
        Debug.Log("chargement du quizz réussi");
        return dia;
    }

    private void ShowResult()
    {
        return;
    }
}
