using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    GameObject director;
    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;

    public AudioClip pin;
    AudioSource aud;

    // Use this for initialization
    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");
        this.director = GameObject.Find("GameDirector");

        this.aud = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision other)
    {
        this.aud.PlayOneShot(this.pin);
        if (other.gameObject.tag == "SmallStarTag")
        {
            this.director.GetComponent<GameDirector>().GetSmallStar();
        }
        else if (other.gameObject.tag == "LargeStarTag")
        {
            this.director.GetComponent<GameDirector>().GetLargeStar();
        }
        else if (other.gameObject.tag == "SmallCloudTag")
        {
            this.director.GetComponent<GameDirector>().GetSmallCloud();
        }
        else if (other.gameObject.tag == "LargeCloudTag")
        {
            this.director.GetComponent<GameDirector>().GetLargeCloud();
        }
    }


    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("GameScene");
            }
        }
    }
}