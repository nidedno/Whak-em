using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] [Range(1,5)] private int maxHealth;
    [SerializeField] GameObject _hearth;
    [SerializeField] float offsetY = 0.5f;
    int currentHealth;

    float lastoffsetY;
    List<GameObject> created = new List<GameObject>();

    public static HealthBar Instance;


    void Start()
    {
        currentHealth = maxHealth;
        Instance = this;

        for (int i = 0; i < maxHealth; i++){
            lastoffsetY = i * offsetY;
            CreateHearth(i * offsetY);
        }
        
    }

    void CreateHearth(float position)
    {
       GameObject hearth = Instantiate(_hearth,transform.position,transform.rotation);
       hearth.name = ""+lastoffsetY/offsetY;
       hearth.transform.position = new Vector3(0,position,0);
       hearth.transform.SetParent(transform, false);
       created.Add(hearth);

    }

    public void TakeDamage(int dmg = 1)
    {
        if(currentHealth - 1 >= 0){
            var low = created[currentHealth - 1].GetComponent<Hearth>();
            bool change = Mathf.Sign(dmg) > 0 ? false : true;
            low.ChangeSprite(change );
        }
        currentHealth -= dmg;
        

        if(currentHealth <= 0 )
        {
            // stop game by gameController
        }
    }

}
