using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject impactParticle;
    public GameObject projectileParticle;

    public float speed = 8.0f;
    public float liveTime = 10.0f;

    [HideInInspector]
    public Vector3 impactNormal; //Used to rotate impactparticle.


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        ObjectPoolManager.Instacne.RecycleGameObject("Bullet_Blue", transform.gameObject, liveTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
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
