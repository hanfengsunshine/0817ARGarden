using UnityEngine;
using System.Collections;
using Vuforia;

public class VirtualButtonEventHandler : MonoBehaviour,IVirtualButtonEventHandler{

    private GameObject Horse_obj;
    private GameObject Rabbit_obj;

    private Vector3 Horse_pos;
    private Vector3 Rabbit_pos;

    private Quaternion Horse_rot;
    private Quaternion Rabbit_rot;





	// Use this for initialization
	void Start () {



        VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour>();
        for (int i = 0; i < vbs.Length; ++i){
            vbs[i].RegisterEventHandler(this);
        }

        Horse_obj = GameObject.Find("Surface/Horse");
        Horse_pos = Horse_obj.transform.position;  
        Horse_rot = Horse_obj.transform.rotation;


        Rabbit_obj = GameObject.Find("Surface/Rabbit");
        Rabbit_pos = Rabbit_obj.transform.position;
        Rabbit_rot = Rabbit_obj.transform.rotation;


        Rabbit_obj.SetActive(true);
        Horse_obj.SetActive(false);

	}

    public void OnButtonPressed(VirtualButtonAbstractBehaviour vb)
    {
        switch (vb.VirtualButtonName)
        {

            case "HorseButton":
                Horse_obj.SetActive(true);
                Rabbit_obj.SetActive(false);
                Debug.Log("HorseButton Basildi");
                break;
            case "RabbitButton":
                Rabbit_obj.SetActive(true);
                Horse_obj.SetActive(false);
                Debug.Log("RabbitButton Basildi");

                break;
            case "ResetButton":
                Horse_obj.transform.position = Horse_pos;
                Horse_obj.transform.rotation = Horse_rot;

                Rabbit_obj.transform.position = Rabbit_pos;
                Rabbit_obj.transform.rotation = Rabbit_rot;
                Debug.Log("ResetButton Basildi");
                break;
        }

    }

    public void OnButtonReleased(VirtualButtonAbstractBehaviour vb){}
	void Update () {}




}
