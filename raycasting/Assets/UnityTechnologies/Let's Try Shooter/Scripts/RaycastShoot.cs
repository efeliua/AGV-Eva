using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RaycastShoot : MonoBehaviour
{
    #region propierties
    public int gunDamage = 1;
    public float fireRate= 0.25f; //how often can you shoot
    public float weaponRange = 50f;
    public float hitForce = 100f;
    private WaitForSeconds shotDuration = new WaitForSeconds(0.7f);
    private LineRenderer laserLine;
    private float nextFire;
    #endregion
    #region references
    public Transform gunEnd;  //Empty object position of end of the gun (spawn pos ig)
    private Camera fpsCam;
    private AudioSource gunAudio;
    #endregion
    #region methods
    private IEnumerator ShotEffect()
    {
        gunAudio.Play();
        laserLine.enabled = true; 
        //coroutine
        yield return shotDuration;
        laserLine.enabled = false;
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        laserLine= GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        fpsCam= GetComponentInParent<Camera>();

    }

// Update is called once per frame
void Update()
    {
        if(Input.GetButtonDown("Fire1")&&Time.time>nextFire) //time.time time since the beginning of the app
        {
            nextFire= Time.time+fireRate; //next shooting available time
            StartCoroutine(ShotEffect());
            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
            RaycastHit hit; //storing
            //start and end positions for Laserline
            laserLine.SetPosition(0,gunEnd.position);

            //did we hit smth?
            if(Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange)) 
            {
                laserLine.SetPosition(1, hit.point);

                ShootableBox health=hit.collider.GetComponent<ShootableBox>(); //si chocamos con un obj que contiene el script d targetbox pues eso le restamos
                if (health != null) health.Damage(gunDamage);

                //anyway, si chocamos con cualquiera cosa con cuerpo aplicamos fuerza
                if (hit.rigidbody != null) hit.rigidbody.AddForce(-hit.normal * hitForce); //hit.normal -> outward direction of the surface we hit
                
            }
            else //sino dibujamos sin más hasta donde alcanzaria
            {
               laserLine.SetPosition(1,rayOrigin+(fpsCam.transform.forward*weaponRange));
            }
        }


    }
}
