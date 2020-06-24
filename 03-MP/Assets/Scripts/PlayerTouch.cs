using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouch : MonoBehaviour
{
    public GameObject blueStick;
    public GameObject redStick;
    public GameObject[] screenSticks = new GameObject[4];

    private GameObject gameArea;
    private RectTransform areaTransform;

    void Start()
    {
        gameArea = this.gameObject;
        areaTransform = gameArea.GetComponent<RectTransform>();

    }

    void Update()
    {
        foreach(Touch touch in Input.touches){
            Vector3 screenPos = new Vector3(touch.position.x, touch.position.y, 10); 
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
            if(touch.phase == TouchPhase.Began){
                GameObject temp;
                if(touch.position.y < areaTransform.sizeDelta.y/2){
                    temp = Instantiate(blueStick,worldPos,Quaternion.identity);
                }else{
                    temp = Instantiate(redStick,worldPos,Quaternion.identity);
                }
                temp.transform.SetParent(gameArea.transform);
                screenSticks[touch.fingerId] = temp;
            }
            if(touch.phase == TouchPhase.Moved){
                screenSticks[touch.fingerId].transform.position = worldPos;
            }
            if(touch.phase == TouchPhase.Ended){
                Destroy(screenSticks[touch.fingerId]);
            }

        }
    }
}
