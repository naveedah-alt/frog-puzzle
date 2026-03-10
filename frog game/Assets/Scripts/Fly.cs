using UnityEngine;

public class Fly : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public bool hit;

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
            hit = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        hit = false;
    }
}
