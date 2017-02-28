using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DamageDisplayObject : MonoBehaviour
{
    float Lifetime;

	// Use this for initialization
	void Start ()
    {
        transform.SetParent(GameObject.FindGameObjectWithTag("UI").transform, false);
        Lifetime = 1.0f;

        SetDamageNumberColor();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Lifetime > 0)
            Lifetime -= Time.deltaTime * 0.5f;
        else
            Destroy(gameObject);

        gameObject.GetComponent<Text>().color = new Color(gameObject.GetComponent<Text>().color.r, gameObject.GetComponent<Text>().color.g, gameObject.GetComponent<Text>().color.b, Lifetime);

        transform.GetComponent<RectTransform>().localPosition = new Vector3(transform.GetComponent<RectTransform>().localPosition.x, transform.GetComponent<RectTransform>().localPosition.y + 10 * Time.deltaTime, 0);
	}

    void SetDamageNumberColor()
    {
        
        int damage = System.Convert.ToInt32(GetComponent<Text>().text);


        // Really wanted to use a multiple ternary operator here, 
        if (damage <= 200)
        {
            gameObject.GetComponent<Text>().color = Color.blue;
            gameObject.GetComponent<Text>().fontSize = 17;
        }
        else if (damage > 200 && damage < 1000)
        {
            gameObject.GetComponent<Text>().color = Color.yellow;
            gameObject.GetComponent<Text>().fontSize = 22;
        }
        else
        {
            gameObject.GetComponent<Text>().color = Color.red;
            gameObject.GetComponent<Text>().fontSize = 29;
        }
    }
}
