using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ANQ_Catch : MonoBehaviour      // catch butterfly in Alaia's scene
{
    public GameObject butterfly;
    public int butterflyNumber;

    void Start()    // instantiate the butterflies
    {
        for (int i = 0; i <= butterflyNumber; i++)
        {
            Instantiate(butterfly, new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), 0), Quaternion.identity);
        }
    }

    void Update()   // if space pressed butterflies in catch area are caught
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (Collider2D col in colliders)
            {
                col.gameObject.SetActive(false);
            }
        }
    }

    private List<Collider2D> colliders = new List<Collider2D>();
    public List<Collider2D> GetColliders() { return colliders; }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!colliders.Contains(other)) { colliders.Add(other); }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        colliders.Remove(other);
    }

}
