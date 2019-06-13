using UnityEngine.SceneManagement;
using UnityEngine;

public class CleanTransition : MonoBehaviour
{
    public Animator animator;
    public int colliderNumber;
    public int nextScene;
    // Update is called once per frame
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        //if (col.name == "Player")
        //{
            FadeToLevel(nextScene);
        //}
    }
    public void FadeToLevel(int levelIndex)
    {
       animator.SetTrigger("FadeOut");
       GameManager.instance.OnFadeComplete(colliderNumber, levelIndex);
    }


}
