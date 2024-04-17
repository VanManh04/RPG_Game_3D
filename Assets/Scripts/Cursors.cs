using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cursors : MonoBehaviour
{
    public GameObject cursorObject;
    public Image cursorImage;
    public Sprite cursorBasic;
    public Sprite cursorHand;
    void Start()
    {
        Cursor.visible = false;
    }
    void Update()
    {
        cursorObject.transform.position = Input.mousePosition;
        if(Input.GetMouseButton(1))
            cursorImage.sprite = cursorHand;
        else
            cursorImage.sprite = cursorBasic;
    }
}
