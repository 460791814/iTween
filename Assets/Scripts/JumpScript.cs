using UnityEngine;
using System.Collections;

public class JumpScript : MonoBehaviour {
    Vector3[] v3 = new Vector3[3];
    private bool isJump=true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)&&isJump)
        {
            v3[0] = transform.position;
            v3[2]=new Vector3(transform.position.x+1.8f,transform.position.y,transform.position.z);
            v3[1] = new Vector3((v3[0].x + v3[2].x) / 2, transform.position.y+2, transform.position.z);
               //是否先从原始位置走到路径中第一个点的位置
           //    args.Add("movetopath",true);
	        //是否让模型始终面朝当面目标的方向，拐弯的地方会自动旋转模型
          //如果你发现你的模型在寻路的时候始终都是一个方向那么一定要打开这个
            // args.Add("orienttopath", true);  lookahead 0-1 面朝的方向不变，1完全从一个面去看
            iTween.MoveTo(this.gameObject, iTween.Hash("path", v3, "easetype", iTween.EaseType.linear, "time", 2, "movetopath", true, "orienttopath", true, "lookahead", 0, "onstart", "StartJump", "onstarttarget", this.gameObject, "oncomplete", "EndJump", "oncompletetarget", this.gameObject,"islocal",true));
                
        }
	}

    void StartJump()
    {
        isJump = false;
    }
    void EndJump()
    {
        isJump = true;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "crate")
        {
            iTween.Pause(this.gameObject);
            isJump = true;
        }
    }
}
