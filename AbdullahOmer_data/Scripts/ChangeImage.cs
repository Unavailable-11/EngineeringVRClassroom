

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeImage : MonoBehaviour
{
    public Image original;
    public Sprite newSprite;
    public Sprite newSprite1;
    public Sprite newSprite2;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void NewImage()
    {
        original.sprite = newSprite;
        newSprite = newSprite1;
        newSprite1 = newSprite2;
    }
}
