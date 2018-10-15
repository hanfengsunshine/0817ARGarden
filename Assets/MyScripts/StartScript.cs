using UnityEngine;
using System.Collections;
using Vuforia;

public class StartScript : MonoBehaviour, IVirtualButtonEventHandler {


    private GameObject button = new GameObject();
    private GameObject horse = new GameObject();

    //the speed, in units per second, we want to move towards the target
    public float speed = 1; 
    //move towards the center of the world (or where ever you like)
    public Vector3 targetPosition = new Vector3(0, 0, 0);
   
    private bool move = false;

	void Start () {
        button = GameObject.Find("StartButton");
        button.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        Debug.Log("Name" + button.name);
        horse = GameObject.Find("Surface/Horse");
        Debug.Log("Horse name" + horse.name);
	}
	
	// Update is called once per frame
	void Update () {
        if (move) {
        Vector3 currentPosition = horse.transform.position;
        //first, check to see if we're close enough to the target
        if (Vector3.Distance(currentPosition, targetPosition) > .1f)
        {
            Vector3 directionOfTravel = targetPosition - currentPosition;
            //now normalize the direction, since we only want the direction information
            directionOfTravel.Normalize();
            //scale the movement on each axis by the directionOfTravel vector components

            horse.transform.Translate(
                (directionOfTravel.x * speed * Time.deltaTime),
                (directionOfTravel.y * speed * Time.deltaTime),
                (directionOfTravel.z * speed * Time.deltaTime),
                Space.World);
        }
        }
	}

    public void OnButtonPressed( VirtualButtonAbstractBehaviour vb ){

        move = true;
        Debug.Log("Buton basildi");   
            
    }
         
    public void OnButtonReleased( VirtualButtonAbstractBehaviour vb ){
            
         
    }
    

  

   
    
 
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            