using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public List<GameObject> tongues;
    public List<GameObject> flies;
    GameObject mostRecentTongue;
    public GameObject prefab;
    bool puzzleOver;
    bool puzzleSolved;
    void Start()
    {
        mostRecentTongue = tongues[tongues.Count-1].gameObject;
        puzzleOver = false;
        puzzleSolved = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (puzzleSolved)
        {
            puzzleOver = true;
        }
        mostRecentTongue = tongues[tongues.Count-1];
        if (Input.GetKeyDown(KeyCode.A) && tongues.Count > 0) {
            GameObject previous = tongues[tongues.Count - 1];
            Tongue previousTongue = previous.GetComponent<Tongue>();
            Vector3 newPosition = previousTongue.getEndpoint();
            if (!previousTongue.enabled && !puzzleOver)
            {
                mostRecentTongue = Instantiate(prefab, newPosition, Quaternion.identity);
                tongues.Add(mostRecentTongue);
                Debug.Log("another tongue instantiated");
            } else
            {
                Debug.Log("Tongue must hit/touch obstacle!");
            }
            
            
        }
        if (Input.GetKeyDown(KeyCode.U) && tongues.Count > 0)
        {
            // Tongue destroyTongue = tongues[tongues.Count - 1];
            if (tongues.Count > 1)
            {
                tongues.RemoveAt(tongues.Count - 1);
                Destroy(mostRecentTongue);
            }
            if (tongues.Count == 1)
            {
                tongues.RemoveAt(tongues.Count - 1);
                Destroy(mostRecentTongue);
                mostRecentTongue = Instantiate(prefab, new Vector3(0.0f, 0.5f, -8.485f), Quaternion.identity);
                tongues.Add(mostRecentTongue);
            }
            
        }
        foreach (GameObject fly in flies)
        {
            Fly currentFly = fly.GetComponent<Fly>();
            if (!currentFly.hit)
            {
                puzzleSolved = false;
                break;
            } else if (currentFly.hit)
            {
                puzzleSolved = true;
            }
        }
    }

    public void endPuzzle()
    {
        Debug.Log("puzzle over");
        puzzleOver = true;
    }
}
