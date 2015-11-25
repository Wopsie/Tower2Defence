using UnityEngine;
using System.Collections;

public class ScrollScript : MonoBehaviour {

    private Animator anim;

	// Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnMouseDown()
    {
        anim.SetBool("fall", true);
    }
}
