using UnityEngine;

public class TreeSap : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public PuzzleManager puzzleManager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tongue")
        {
            Tongue tongue = other.GetComponent<Tongue>();
            tongue.hitSap();
            puzzleManager.endPuzzle();
        }
    }
}
