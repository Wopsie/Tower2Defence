using UnityEngine;
using System.Collections;

public class UIScript : MonoBehaviour {

    [SerializeField]    private Transform scroll;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void FixedUpdate()
    {
        
    }
    public void UIEvent()
    {
        
    }
}
