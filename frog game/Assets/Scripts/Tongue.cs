using Unity.VisualScripting;
using UnityEngine;

public class Tongue : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float growFactor;
    float shrinkFactor;
    bool hitLilypad;
    bool hitTreeSap;
    public bool enabled;
    void Start()
    {
        growFactor = 0.125f;
        shrinkFactor = 0.125f;
        hitLilypad = false;
        enabled = true;
    }

    // void OnCollisionEnter(Collision collision)
    // {
    //     if (collision.gameObject.tag == "Lilypad")
    //     {
    //         Debug.Log("hit lilly");
    //         hitLilypad = true;
    //     }
    // }

    public void hitLily()
    {
        enabled = false;
        hitLilypad = true;
    }

    public void hitSap()
    {
        enabled = false;
        hitTreeSap = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && !hitLilypad && !hitTreeSap) {
            Resize(growFactor, 'l');
        }
        if (Input.GetKey(KeyCode.RightArrow) && !hitLilypad && !hitTreeSap) {
            Resize(growFactor, 'r');
        }
        if (Input.GetKey(KeyCode.UpArrow) && !hitLilypad && !hitTreeSap) {
            Resize(growFactor, 'u');
        }
        if (Input.GetKey(KeyCode.DownArrow) && !hitLilypad && !hitTreeSap) {
            Resize(growFactor, 'd');
        }
        else if ((!Input.anyKey) && !hitLilypad && !hitTreeSap)
        // if ((!Input.GetKey(KeyCode.LeftArrow)) && !hitLilypad)
        {
            BackToNormal(shrinkFactor);
        }
    }

    void BackToNormal(float Factor)
    {
        if (gameObject.transform.localScale.x > 1.0f)
        {
            while (gameObject.transform.localScale.x > 1.0f)
            {
                gameObject.transform.localScale -= new Vector3(Factor, 0.0f, 0.0f);
                gameObject.transform.Translate(new Vector3(Factor/2, 0.0f, 0.0f));
            }
        }
        if (gameObject.transform.localScale.x < 1.0f)
        {
            while (gameObject.transform.localScale.x < 1.0f)
            {
                gameObject.transform.localScale += new Vector3(Factor, 0.0f, 0.0f);
                gameObject.transform.Translate(new Vector3(-Factor/2, 0.0f, 0.0f));
            }
        }
        if (gameObject.transform.localScale.z > 1.0f)
        {
            while (gameObject.transform.localScale.z > 1.0f)
            {
                gameObject.transform.localScale -= new Vector3(0.0f, 0.0f, Factor);
                gameObject.transform.Translate(new Vector3(0.0f, 0.0f, Factor/2));
            }
        }
        if (gameObject.transform.localScale.z < 1.0f)
        {
            while (gameObject.transform.localScale.z < 1.0f)
            {
                gameObject.transform.localScale += new Vector3(0.0f, 0.0f, Factor);
                gameObject.transform.Translate(new Vector3(0.0f, 0.0f, -Factor/2));
            }
        }
        
        // gameObject.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }

    void Resize(float Factor, char direction)
    {
        if (direction == 'l')
        {
            gameObject.transform.localScale += new Vector3(Factor, 0.0f, 0.0f);
            gameObject.transform.Translate(new Vector3(-Factor/2, 0.0f, 0.0f));
        }
        if (direction == 'r')
        {
            gameObject.transform.localScale += new Vector3(-Factor, 0.0f, 0.0f);
            gameObject.transform.Translate(new Vector3(Factor/2, 0.0f, 0.0f));
        }
        if (direction == 'u')
        {
            gameObject.transform.localScale += new Vector3(0.0f, 0.0f, -Factor);
            gameObject.transform.Translate(new Vector3(0.0f, 0.0f, Factor/2));
        }
        if (direction == 'd')
        {
            gameObject.transform.localScale += new Vector3(0.0f, 0.0f, Factor);
            gameObject.transform.Translate(new Vector3(0.0f, 0.0f, -Factor/2));
        }
        
    }

    public Vector3 getEndpoint()
    {
        float newX = gameObject.transform.position.x;
        float newZ = gameObject.transform.position.z;
        if (gameObject.transform.localScale.x > 1.0f)
        {
            newX = (gameObject.transform.position.x * 2.0f)+0.4f;
        }
        if (gameObject.transform.localScale.z > 1.0f)
        {
            newZ = gameObject.transform.localScale.z/2.0f - Mathf.Abs(gameObject.transform.position.z) - 3.2f;
        }
        if (gameObject.transform.localScale.x < 1.0f)
        {
            newX = (Mathf.Abs(gameObject.transform.position.x) * 2.0f)-2.8f;
        }
        if (gameObject.transform.localScale.z < 1.0f)
        {
            newZ = -gameObject.transform.localScale.z/2.0f - Mathf.Abs(gameObject.transform.position.z) - 0.8f;
        }
        Vector3 endpoint = new Vector3(newX, 0.5f, newZ);
        return endpoint;
    }
}
