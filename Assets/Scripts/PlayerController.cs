using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    private Animator anim;
    private Rigidbody2D rgdBody;
    private bool playerMoving;
    private Vector2 lastMove;

    
    // Start is called before the first frame update
    void Start() {
        anim = GetComponent<Animator>();
        rgdBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        //Idle par défaut
        playerMoving = false;
        //Horizontal (X)
        if(Input.GetAxisRaw("Horizontal") > 0.5F || Input.GetAxisRaw("Horizontal") < -0.5F) {
            //transform.Translate (new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0F, 0F));
            rgdBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rgdBody.velocity.y);
            playerMoving = true;
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        }

        //Vertical (Y)
        if (Input.GetAxisRaw("Vertical") > 0.5F || Input.GetAxisRaw("Vertical") < -0.5F) {
            //transform.Translate(new Vector3(0F, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0F));
            rgdBody.velocity = new Vector2(rgdBody.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed);
            playerMoving = true;
            lastMove = new Vector2(0, Input.GetAxisRaw("Vertical"));
        }

        //Le joueur ne glisse plus, quand la direction n'est pas pressée, le rigidBody reste immobile
        if (Input.GetAxisRaw("Horizontal") < 0.5 && Input.GetAxisRaw("Horizontal") > -0.5) {
            rgdBody.velocity = new Vector2(0f, rgdBody.velocity.y);
        }

        if (Input.GetAxisRaw("Vertical") < 0.5 && Input.GetAxisRaw("Vertical") > -0.5) {
            rgdBody.velocity = new Vector2(rgdBody.velocity.x, 0f);
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