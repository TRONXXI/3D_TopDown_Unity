using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is used for player movement using mouse button
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3f;//speed of the player
    private GridTile currentTile;//tile player standing on
    private bool isMoving = false;//player is moving or not
    public Animator anim;//animator component

    void Start()
    {
        gameObject.tag = "Player";//using player tag
        
        RaycastHit hit;
        //raycast to check player is on tile and make it currenttile
        if (Physics.Raycast(transform.position + Vector3.up, Vector3.down, out hit))
        {
            currentTile = hit.collider.GetComponent<GridTile>();
            if (currentTile != null)
                currentTile.isOccupied = true;
        }
    }

    void Update()
    {
        if (!isMoving && Input.GetMouseButtonDown(0))//clicking mouse button, left click
        {
            //here raycast hits the tile and makes player move to the tile
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                GridTile targetTile = hit.collider.GetComponent<GridTile>();

                if (targetTile != null && !targetTile.isOccupied)
                {
                    if (currentTile != null)
                        currentTile.isOccupied = false;

                    StartCoroutine(MoveToTile(targetTile));
                }
            }
        }
    }

    IEnumerator MoveToTile(GridTile targetTile)
    {
        isMoving = true;
        anim.SetFloat("Speed", 1f);// walk animation
        Vector3 startPosition = transform.position;// start position
        Vector3 endPosition = targetTile.transform.position;//end position
        float elapsedTime = 0f;

        //this while loop runs for 1 second and make smooth movement instead of snaping
        while (elapsedTime < 1f)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime);
            elapsedTime += Time.deltaTime * moveSpeed;
            yield return null;
        }

        transform.position = endPosition;//moves to end position
        targetTile.isOccupied = true;//make that tile as occupied
        currentTile = targetTile;
        anim.SetFloat("Speed", 0f);//idle animation
        isMoving = false;
    }
}
