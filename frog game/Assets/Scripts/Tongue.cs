using UnityEngine;

public class Tongue : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space)) {
            Resize(0.0125f);
        } else if (!Input.GetMouseButton(0) || !Input.GetKey(KeyCode.Space))
        {
            BackToNormal(0.0125f);
        }
    }

    void BackToNormal(float xFactor)
    {
        while (gameObject.transform.localScale.x > 1.0f)
        {
            gameObject.transform.localScale -= new Vector3(xFactor, 0.0f, 0.0f);
            gameObject.transform.Translate(new Vector3(xFactor/2, 0.0f, 0.0f));
        }
        // gameObject.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }

    void Resize(float xFactor)
    {
        gameObject.transform.localScale += new Vector3(xFactor, 0.0f, 0.0f);
        gameObject.transform.Translate(new Vector3(-xFactor/2, 0.0f, 0.0f));
    }
}
