using UnityEngine;
using System.Collections;

public class DemoScript : MonoBehaviour {

    public GameObject cube;//立方块
    public GameObject currentObj;//当前选中的立方块
    public GameObject shpere;//圆球
    private Vector3[] points = new Vector3[2];
    int currentPoint = 0;
    private GameObject currentShpereCube;//当前球体所在的立方块
	// Use this for initialization
    void Start()
    {

        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                GameObject obj = Instantiate(cube, new Vector3(i, 0, j), Quaternion.identity) as GameObject;
                //obj.transform.position = new Vector3(i,obj.transform.position.y,j);
                if ((i + j) % 2 == 0)
                {
                    iTween.ColorTo(obj, Color.black, 0f);
                }
            }
        }
    }
	
	// Update is called once per frame
    void Update()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.transform.tag == "cb")
            {
                if (points[1].x == hitInfo.transform.position.x && points[0].z
                    == hitInfo.transform.position.z)
                {

                }
                else
                {


                    UpdateObj(hitInfo.transform.gameObject);
                    currentObj = hitInfo.transform.gameObject;

                    if (Input.GetMouseButtonDown(0))
                    {
                        if (currentShpereCube != null)
                        {
                            if ((currentShpereCube.transform.position.x + currentShpereCube.transform.position.z) % 2 == 0)
                            {
                                iTween.ColorTo(currentShpereCube, Color.black, 2f);
                            }
                            else
                            {

                                iTween.ColorTo(currentShpereCube, Color.white, 2f);
                            }
                        }
                        points[0] = new Vector3(shpere.transform.position.x, shpere.transform.position.y, hitInfo.transform.position.z);
                        points[1] = new Vector3(hitInfo.transform.position.x, shpere.transform.position.y, hitInfo.transform.position.z);
                        currentPoint = 0;
                        MoveObject();
                        currentShpereCube = hitInfo.transform.gameObject;
                        iTween.ColorTo(hitInfo.transform.gameObject, Color.red, 0f);
                        iTween.MoveTo(hitInfo.transform.gameObject, new Vector3(hitInfo.transform.position.x, 0, hitInfo.transform.position.z), 0f);
                    }

                }
            }
        }
        else
        {

            if (currentObj != null)
            {
                if (currentObj != currentShpereCube)
                {
                    iTween.MoveTo(currentObj, new Vector3(currentObj.transform.position.x, 0f, currentObj.transform.position.z), 3f);
                    if ((currentObj.transform.position.x + currentObj.transform.position.z) % 2 == 0)
                    {
                        iTween.ColorTo(currentObj, Color.black, 2f);
                    }
                    else
                    {

                        iTween.ColorTo(currentObj, Color.white, 2f);
                    }
                }
            }
        }
    }
    void MoveObject()
    {


        if (currentPoint < 2)
        {
            iTween.MoveTo(shpere, iTween.Hash("position", points[currentPoint], "speed", 5f, "easetype", "linear", "oncomplete", "MoveObject", "oncompletetarget", this.gameObject));//,"oncomplete","hehe","concompletetarget",this.gameObject
            currentPoint++;
        }
    }

    void UpdateObj(GameObject obj)
    {

        if (currentObj == obj || currentObj == null)
        {
            iTween.MoveTo(obj, new Vector3(obj.transform.position.x, 0.5f, obj.transform.position.z), 3f);
            iTween.ColorTo(obj, Color.green, 0f);

        }
        else
        {
            if (currentObj != currentShpereCube)
            {
                iTween.MoveTo(currentObj, new Vector3(currentObj.transform.position.x, 0f, currentObj.transform.position.z), 3f);
                if ((currentObj.transform.position.x + currentObj.transform.position.z) % 2 == 0)
                {
                    iTween.ColorTo(currentObj, Color.black, 2f);
                }
                else
                {

                    iTween.ColorTo(currentObj, Color.white, 2f);
                }

            }
        }

    }
}
