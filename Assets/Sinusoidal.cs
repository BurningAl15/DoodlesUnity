using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sinusoidal : MonoBehaviour {

    [SerializeField]
    float moveSpeed;

    [SerializeField]
    float frequency;

    [SerializeField]
    float magnitude;

    bool facingRight = true;

    Vector3 pos, localscale;

    SpriteRenderer rend;

    [Range(0f, 1f)]
    public float fadeAmount;

    public float fadingSpeed;

    public Color mainColor;

	// Use this for initialization
	void Start () {
        pos = transform.position;
        localscale = transform.localScale;
        rend = GetComponent<SpriteRenderer>();

        mainColor = rend.material.color;

        //mainColor.g = 1f;
        //mainColor.b = 1f;

        rend.material.color = mainColor;
        //StartFade();
    }
	
	// Update is called once per frame
	void Update () {
        CheckWhereToFace();

        if (facingRight)
            Move(1);
        else
            Move(-1);

        OFade();

    }

    void CheckWhereToFace()
    {
        if (pos.x < -7f)
            facingRight = true;
        else if (pos.x > 7f)
            facingRight = false;
        if (((facingRight) && (localscale.x < 0)) || ((!facingRight) && (localscale.x > 0)))
            localscale.x *= -1;
        
        transform.localScale = localscale;
    }

    void Move(int direction)
    {
        pos += transform.right * Time.deltaTime * moveSpeed*direction;
        transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
    }

    void OFade()
    {
        var i = Mathf.Sin(Time.time * frequency) /** magnitude*/;
        mainColor.r = i;
        mainColor.g = i;
        mainColor.b = i;
        rend.material.color = mainColor;
    }

    IEnumerator Fade()
    {
        for(float i=1f;i>=fadeAmount;i-=0.05f)
        {
            //Color c = rend.material.color;
            //c.r = i;
            //c.g = i;
            //c.b = i;
            mainColor.r = i;
            mainColor.g = i;
            mainColor.b = i;
            rend.material.color = mainColor;

            //yield return new WaitForSeconds(fadingSpeed);
            yield return null;
        }
        for (float i = 0f; i <= 1; i += 0.05f)
        {
            mainColor.r = i;
            mainColor.g = i;
            mainColor.b = i;
            rend.material.color = mainColor;

            //yield return new WaitForSeconds(fadingSpeed);
            yield return null;
        }

    }

    public void StartFade()
    {
        StartCoroutine("Fade");
    }

}
