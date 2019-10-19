using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunSkillManager : MonoBehaviour {
    public float coldTime = 5;
    private float timer = 0;
    private Image cover;
    public KeyCode key;

    private bool isStart = false;
    // Start is called before the first frame update
    void Start() {
        cover = transform.Find("cover").GetComponent<Image>();
    }

    // Update is called once per frame 
    void Update() {
        if (Input.GetKeyDown(key)) {
            isStart = true;
        }
        if (isStart) {
            timer += Time.deltaTime;
            cover.fillAmount = (coldTime - timer) / coldTime;
            if (timer >= coldTime) {
                cover.fillAmount = 0;
                timer = 0;
                isStart = false;
            }
        }
    }

    public void OnClick() {
        isStart = true;
    }
}