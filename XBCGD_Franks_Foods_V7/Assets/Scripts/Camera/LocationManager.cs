using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationManager : MonoBehaviour
{
    //Deals with switching the camera between locations through interacting with the location menu. This is accessed through the radial menu

    //CAMERA
    public GameObject camera;

    //OTHERS
    public GameObject navMenu;
    public StockManager stockManagerObj;

    //BUTTONS
    public Button locationBtn;
    public Button faceMaskBtn;
    public Button storeBtn;
    public Button manageBtn;
    public Button sanitzerBtn;
    public Button glovesBtn;

    //SPRITES
    public Sprite elevator;
    public Sprite elevatorPan;

    //STRING
    string locationName;

    //BOOLS
    bool clicked = true;

    // Start is called before the first frame update
    void Start()
    {
        locationName = "Storefront";
        camera.gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        camera.gameObject.transform.position = new Vector3(0, 4, -12.7f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void LocationSelector()
    {


        if (clicked == true)
        {

            locationBtn.GetComponent<Image>().sprite = elevatorPan;

            sanitzerBtn.gameObject.SetActive(true);
            storeBtn.gameObject.SetActive(true);
            manageBtn.gameObject.SetActive(true);
            clicked = false;

            if (stockManagerObj.faceMaskAvailable == true)
            {
                faceMaskBtn.gameObject.SetActive(true);
            }
            if(stockManagerObj.glovesAvailable == true)
            {
                glovesBtn.gameObject.SetActive(true);
            }

           

        }
        else
        {
            locationBtn.GetComponent<Image>().sprite = elevator;
            faceMaskBtn.gameObject.SetActive(false);
            sanitzerBtn.gameObject.SetActive(false);
            glovesBtn.gameObject.SetActive(false);
            storeBtn.gameObject.SetActive(false);
            manageBtn.gameObject.SetActive(false);
            locationBtn.gameObject.SetActive(false);
            navMenu.SetActive(true);

            clicked = true;
        }


    }

    public void StoreBtn()
    {
        locationName = "Storefront";
        storeBtn.GetComponent<Image>().color = Color.gray;
        manageBtn.GetComponent<Image>().color = Color.white;
        faceMaskBtn.GetComponent<Image>().color = Color.white;
        sanitzerBtn.GetComponent<Image>().color = Color.white;
        glovesBtn.GetComponent<Image>().color = Color.white;
        camera.gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        camera.gameObject.transform.position = new Vector3(0, 4, -12.7f);
    }

    public void ManageBtn()
    {
        locationName = "Management";
        storeBtn.GetComponent<Image>().color = Color.white;
        manageBtn.GetComponent<Image>().color = Color.gray;
        faceMaskBtn.GetComponent<Image>().color = Color.white;
        sanitzerBtn.GetComponent<Image>().color = Color.white;
        glovesBtn.GetComponent<Image>().color = Color.white;
        camera.gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        camera.gameObject.transform.position = new Vector3(0, 34.5f, -13.7f);
    }

    public void FaceMaskBtn()
    {
        locationName = "FaceMask";
        storeBtn.GetComponent<Image>().color = Color.white;
        manageBtn.GetComponent<Image>().color = Color.white;
        faceMaskBtn.GetComponent<Image>().color = Color.gray;
        glovesBtn.GetComponent<Image>().color = Color.white;
        sanitzerBtn.GetComponent<Image>().color = Color.white;
        camera.gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        camera.gameObject.transform.position = new Vector3(0, -56.5f, -12.7f);
    }

    public void SanitizerBtn()
    {
        locationName = "Sanitizer";
        storeBtn.GetComponent<Image>().color = Color.white;
        manageBtn.GetComponent<Image>().color = Color.white;
        faceMaskBtn.GetComponent<Image>().color = Color.white;
        glovesBtn.GetComponent<Image>().color = Color.white;
        sanitzerBtn.GetComponent<Image>().color = Color.gray;
        camera.gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        camera.gameObject.transform.position = new Vector3(0, -26.5f, -12.7f);
    }

    public void GlovesBtn()
    {
        locationName = "Gloves";
        storeBtn.GetComponent<Image>().color = Color.white;
        manageBtn.GetComponent<Image>().color = Color.white;
        faceMaskBtn.GetComponent<Image>().color = Color.white;
        sanitzerBtn.GetComponent<Image>().color = Color.white;
        glovesBtn.GetComponent<Image>().color = Color.gray;
        camera.gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        camera.gameObject.transform.position = new Vector3(0, -86.5f, -12.7f);
    }

}
