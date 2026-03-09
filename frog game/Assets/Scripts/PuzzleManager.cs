using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public List<Tongue> tongues;
    public Tongue prefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && tongues.Count > 0) {
            Tongue previousTongue = tongues[tongues.Count - 1];
            Vector3 newPosition = previousTongue.getEndpoint();
            tongues.Add(Instantiate(prefab, newPosition, Quaternion.identity));
            Debug.Log("another tongue instantiated");
            
        } else if ((!Input.anyKey))
        {
            
        }
    }
}
