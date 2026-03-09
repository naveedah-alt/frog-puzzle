using UnityEngine;

public class LilyPad : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tongue")
        {
            Tongue tongue = other.GetComponent<Tongue>();
            tongue.hitLily();
        }
    }
}
