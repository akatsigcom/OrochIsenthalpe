using UnityEngine.SceneManagement;
using UnityEngine;

public class CleanTransition : MonoBehaviour
{
    public Animator animator;
    public int nextScene;
    private int sceneToLoad;
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        FadeToLevel(nextScene);
    }

    public void FadeToLevel(int levelIndex)
    {
        sceneToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
