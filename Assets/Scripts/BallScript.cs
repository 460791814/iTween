using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

    public GameObject cursor;
    public GameObject ball;
    public  Vector3[] v3=new Vector3[3];
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.tag == "cb")
            {
             //   print(hit.point);
                //point 碰撞点在世界坐标系的位置。Position物体的中心点在世界坐标系的位置
                iTween.MoveUpdate(cursor, new Vector3(hit.point.x, 0.1f, hit.point.z), 0.1f);
                if (Input.GetMouseButtonDown(0))
                {
                  
                    //Quaternion.identity无旋转 ，默认
                    GameObject g=  Instantiate(ball,new Vector3(0,0,0),Quaternion.identity) as GameObject;
                    Destroy(g, 2f);
                    v3[0] = new Vector3(0,0,0);
                    v3[1] = new Vector3(hit.point.x/2,3,hit.point.z/2);
                    v3[2] = hit.point;
                    iTween.MoveTo(g, iTween.Hash("path", v3, "easetype", iTween.EaseType.linear,"time",1f));
                }

            }
        }
    }

    void OnDrawGizmos()
    {
        iTween.DrawLine(v3,Color.blue);
        iTween.DrawPath(v3,Color.red);
    }
}
