using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickController : MonoBehaviour
{

    //      VARIABLES & DECLARATIONS

    //      RAYCAST STUFF
    private RaycastHit hit;
    public float rayLength;
    //private bool isClicked;
    public Camera camera;
    public float range;

    //InspPanel Items
    public Text num1text;
    public Text num2text;
    public Text num3text;
   

    public InspectorEventTimer inspTime;


    public static ClickController Instance { get; private set; }



    //          BOOLS       //
    bool isClicked;


                //      STRINGS     
    public static string objName; //name of the object (not the txt object)

            //GAMEOBJECTS

  //  public GameObject objectText; //to attach the name text to the object

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))  //when the left mouse button is clicked, call the object checker class
        {
          //  Debug.Log("Boom");
            ObjectChecker();
        }
    }

    private void ObjectChecker() //checks the object by firing a ray to see if it hits the right object. The information is returned and if the tag is right, it'll destory that object.
    {
        Ray aim = camera.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(aim, out hit, range)) //out passes in a variable and it writes to the variable and sends it back. This allows us to send back multiple values
        {
            Debug.Log(hit.transform.tag);  //just for testing purposes

            if(hit.transform.tag == "Spray")
            {
    
                Destroy(hit.transform.gameObject);

            }
            if (hit.transform.tag == "Pump")
            {

                Destroy(hit.transform.gameObject);

            }
            if (hit.transform.tag == "Squeeze")
            {

                Destroy(hit.transform.gameObject);

            }
        }

    }

    private void OnMouseDown() //deals with the actual point and click hidden object aspect --> objects clicked are removed. Score is increased and updated in the ui.
    {
        if (gameObject.tag == "Spray")
        {
            objName = gameObject.name;
            Debug.Log(objName);
            inspTime.num1 --;
           
            num1text.text =  + inspTime.num1 + "x";
            Destroy(gameObject);
        }
        if(gameObject.tag == "Pump")
        {
            objName = gameObject.name;
            Debug.Log(objName);

            inspTime.num2--; 
            num2text.text =  inspTime.num2 + "x";
            Destroy(gameObject);
        }
        if(gameObject.tag == "Squeeze")
        {
            objName = gameObject.name;
            Debug.Log(objName);
            inspTime.num3--;
         
            num3text.text =  inspTime.num3 + "x";
            Destroy(gameObject);

        }

    }
}
