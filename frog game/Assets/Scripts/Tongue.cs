using UnityEngine;

public class Tongue : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float growFactor;
    float shrinkFactor;
    bool hitLilypad;
    void Start()
    {
        growFactor = 0.0125f;
        shrinkFactor = 0.0125f;
        hitLilypad = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Lilypad")
        {
            hitLilypad = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && !hitLilypad) {
                Resize(growFactor, 'l');
        }
        if (Input.GetKey(KeyCode.RightArrow) && !hitLilypad) {
            Resize(growFactor, 'r');
        }
        if (Input.GetKey(KeyCode.UpArrow) && !hitLilypad) {
            Resize(growFactor, 'u');
        }
        if (Input.GetKey(KeyCode.DownArrow) && !hitLilypad) {
            Resize(growFactor, 'd');
        }
        else if ((!Input.anyKey) && !hitLilypad)
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
}
