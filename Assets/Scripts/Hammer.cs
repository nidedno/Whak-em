using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    [Header("Main")]
    [SerializeField] float timeToComeback;


    [Header("Settings")]
    [SerializeField] Vector3 offSet;
    [SerializeField] Transform hitEffectPoint;
    [SerializeField] Transform passivePosition;

    public static Hammer Instance;

    private bool isActive;
    Animator animator;
    float comebackTimer = 0f;
    Vector3 defRotatiion;

    void Awake()
    {
        Instance = this;
        defRotatiion = transform.eulerAngles;
    }
    void Start()
    {
        transform.position = passivePosition.position;
        
        animator = GetComponent<Animator>();
        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Hit(Input.mousePosition);
        }
        if(isActive)
        {
            comebackTimer -= Time.deltaTime;
            if(comebackTimer <= 0){
                transform.position = passivePosition.position;
                transform.localEulerAngles = defRotatiion;
                isActive = false;
            }
        }
    }

    void Hit(Vector2 hitPos)
    {
        var _hitPos = Camera.main.ScreenToWorldPoint(hitPos);
        _hitPos.z = 0;

        transform.position = _hitPos + offSet;

        transform.localEulerAngles = new Vector3(0, 0, 35);
        
        animator.SetTrigger("hit");

        isActive = true;
        comebackTimer = timeToComeback;
    }

    public void SetDefaultRotation()
    {
        transform.localEulerAngles = defRotatiion;
    }
}
