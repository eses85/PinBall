using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    GameObject pointText;
    public int point = 0;

    public void GetSmallStar()
    {
        this.point += 100;
    }
    public void GetLargeStar()
    {
        this.point += 20;
    }
    public void GetSmallCloud()
    {
        this.point += 40;
    }
    public void GetLargeCloud()
    {
        this.point -= 20;
    }
    // Use this for initialization
    void Start()
    {
        this.pointText = GameObject.Find("Point");

    }

    // Update is called once per frame
    void Update()
    {
        this.pointText.GetComponent<Text>().text = this.point.ToString() + "point";

    }
}
