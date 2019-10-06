using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject impactParticle;
    public GameObject projectileParticle;

    public float speed = 8.0f;
    public float liveTime = 10.0f;
    public MyTimer timer;

    [HideInInspector]
    public Vector3 impactNormal; //Used to rotate impactparticle.

    private void Awake()
    {
        timer = new MyTimer(liveTime);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        timer.Go();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.forward * Time.deltaTime * speed);
        timer.Tick();
        if(timer.state == MyTimer.STATE.FINISHED)
        {
            ObjectPoolManager.Instacne.RecycleGameObject("Bullet_Blue", transform.gameObject);
        }
    }

    

    private void OnCollisionEnter(Collision collision)
    {
        //impactParticle = Instantiate(impactParticle, transform.position, Quaternion.FromToRotation(Vector3.up, impactNormal)) as GameObject;
        impactParticle = ObjectPoolManager.Instacne.GetGameObject("Bullet_Explosion_Blue");
        impactParticle.transform.parent = null;
        impactParticle.transform.position = transform.position;
        ObjectPoolManager.Instacne.RecycleGameObject("Bullet_Blue", transform.gameObject);
        ObjectPoolManager.Instacne.RecycleGameObject("Bullet_Explosion_Blue", impactParticle,0.5f);  
    }
}
