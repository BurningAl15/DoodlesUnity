using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject bombs;
    public InputField changeParameter;
    public GameObject camera;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(changeParameter.text.Length==0)
        {
            bombs.GetComponent<PlayerBehaviour>().vibratePower = 500;
        }
        else
        {
            long.TryParse(changeParameter.text, out bombs.GetComponent<PlayerBehaviour>().vibratePower);
        }

       
    }
    private void LateUpdate()
    {
        if (bombs.GetComponent<PlayerBehaviour>().destroyed)
        {
            camera.GetComponent<CameraController>().Shake();
            Debug.Log("Destroyed");
        }
    }

    private void OnMouseDown()
    {
        //if (Input.GetMouseButtonDown(0))
            Instantiate(bombs, Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f)), bombs.transform.rotation);
    }

    public void Quit()
    {
        Application.Quit();
    }


}
