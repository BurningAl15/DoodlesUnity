using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    public float time;
    Vector3 newPosition;
    SpriteRenderer rend;
    [SerializeField]
    Color color;

    public long vibratePower;
    public bool destroyed;

    public GameObject sparks;
    public GameObject explosion;
    GameObject currentSpark;
    // Use this for initialization
    void Start () {
        rend = GetComponent<SpriteRenderer>();
        color = rend.material.color;
        color.r = Random.Range(0f, 1f);
        color.g = Random.Range(0f, 1f);
        color.b = Random.Range(0f, 1f);

        rend.material.color = color;
        destroyed = false;
        currentSpark= Instantiate(sparks, transform.position, transform.rotation);
    }
	
	// Update is called once per frame
	void Update () {
        //offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
        Animation();

        time -= Time.deltaTime;
        if(time>0f && time<=0.5f)
        {
            Vibration.Vibrate(vibratePower);
            destroyed = true;
        }
        if (time<=0)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject,0.5f);
        }
    }

    void Animation()
    {
        var localScale = new Vector3(1f, 1f, 1f)*0.3f;
        var size = 5f;

        //transform.localScale = localScale * Mathf.Cos(Time.deltaTime*100)*size;
        //var v= localScale * Mathf.Lerp(0.7f, Mathf.Sin(Time.deltaTime *0.05f) * size * 10, 0.3f);
        var time = Time.fixedTime;
        var v = localScale * Mathf.Sin(time)* size;
        Debug.Log(Time.fixedTime);
        if (currentSpark != null)
            currentSpark.transform.position = new Vector3(transform.position.x, transform.position.y + 0.3f,transform.position.z);
        transform.localScale = v;
        
        //Vector3.Lerp(transform.localScale, v, 0.5f);    
    }

    void Dragging()
    {
        //if (Input.GetMouseButtonDown(0))
        //    newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
        //else if(Input.GetMouseButtonUp(0))      
        //    transform.position = Camera.main.ScreenToWorldPoint(newPosition) /*+ offset*/;
    }


    //private void OnMouseDown()
    //{
    //    offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
    //}

    //private void OnMouseDrag()
    //{
    //    Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
    //    transform.position = Camera.main.ScreenToWorldPoint(newPosition) + offset;
    //}
}
