using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateManager : MonoBehaviour
{
    public RoleManager roleManager;
    public int HP;
    public CapsuleCollider capsuleCollider;
    public Text text;
    public Text gameover;
    public Image blood;
    public Image dead;
    void Awake() {
        capsuleCollider = GetComponent<CapsuleCollider>();
        blood = GameObject.Find("show").GetComponent<Image>();
        blood.fillAmount = 1;
        text = GameObject.Find("num").GetComponent<Text>();
        dead = GameObject.Find("dead").GetComponent<Image>();
        dead.enabled = false;
        gameover = GameObject.Find("gameover").GetComponent<Text>();
        gameover.text = "";
        GameObject.Find("Continue").GetComponent<Image>().enabled = false;
        GameObject.Find("con").GetComponent<Text>().enabled = false;
        GameObject.Find("Quit").GetComponent<Image>().enabled = false;
        GameObject.Find("qui").GetComponent<Text>().enabled = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        HP = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("EnemyWeapon"))
        {
            DoDamage();
        }
    }

    private void DoDamage()
    {
        HP--;
        blood.fillAmount -= 0.2f;
        text.text = (int.Parse(text.text) - 20) + "";
        if (HP <= 0) {
            capsuleCollider.enabled = false;
            roleManager.SetTrigger("die");
            dead.enabled = true;
            gameover.text = "Game Over";
            GameObject.Find("Continue").GetComponent<Image>().enabled = true;
            GameObject.Find("con").GetComponent<Text>().enabled = true;
            GameObject.Find("Quit").GetComponent<Image>().enabled = true;
            GameObject.Find("qui").GetComponent<Text>().enabled = true;
        }
        else
        {
            roleManager.SetTrigger("hit");
        }
    }
}
