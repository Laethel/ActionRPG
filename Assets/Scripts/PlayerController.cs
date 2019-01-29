using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    private Animator anim;
    private bool playerMoving;
    private Vector2 lastMove;

    
    // Start is called before the first frame update
    void Start() {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        //Idle par défaut
        playerMoving = false;
        //Horizontal (X)
        if(Input.GetAxisRaw("Horizontal") > 0.5F || Input.GetAxisRaw("Horizontal") < -0.5F) {
            transform.Translate (new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0F, 0F));
            playerMoving = true;
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        }

        //Vertical (Y)
        if (Input.GetAxisRaw("Vertical") > 0.5F || Input.GetAxisRaw("Vertical") < -0.5F) {
            transform.Translate(new Vector3(0F, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0F));
            playerMoving = true;
            lastMove = new Vector2(0, Input.GetAxisRaw("Vertical"));
        }

        //On fait passer à l'animator les valeurs de déplacement du player 
        //via les variables MoveX/Y qu'on lui a déclarées en interne
        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
    }
}