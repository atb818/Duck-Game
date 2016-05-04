using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DuckCharacterController : MonoBehaviour
{

    CharacterController cc;
    float yPos;
    public GameObject DB;

    //added by O--------------------
    public Animator deadDemonAnim;
    //------------------------------

    public float speed;
    public float normalSpeed;
    public float chasingSpeed;
    Quaternion smoothRotate;
    Quaternion startRot;

    public GameObject[] Nodes;
    public GameObject StartNode;

    //SEE BREAD
    GameObject target;
    float breadDist;
    public float eatDist;
    public float restTime;
    bool getBread = false;
    bool isResting = false;
    public GameObject[] ducks;

    //SEE PLAYER
    bool chasingPlayer = false;
    bool targetIsPlayer = false;
    //Distance
    float playerDist;
    public float detectDist;
    public float fovDist;
    bool playerInDist = false;
    bool playerDetected = false;
    //Angle
    float playerAngle;
    public float fovAngle;
    bool playerInAngle = false;
    public GameObject FOV;
    bool playerHiding = false;

    //DUCKS RETURN
    Vector3 startPos;
    GameObject start;

    //DUCK TYPE
    public bool isBasicDuck;
    public bool isPatrolDuck;
    public bool isGymDuck;
    public bool isStageDuck;
    public bool isOutsideDuck;
    public bool isDemonDuck;

    //PATROL DUCK
    int currentNode;
    bool returning = false;

    //GYM DUCK
    public GameObject spot;
    public GameObject stageduck;

    //OUTSIDE DUCK
    bool ODSeesPlayer = false;

    //DEMON DUCK
    public GameObject soul;
    bool dying = false;

    //DEBUG SPEED CHECK
    Vector3 lastPos;


    void Start()
    {
        currentNode = 0;
        if (isBasicDuck)
        {
            start = (GameObject)Instantiate(StartNode, transform.position, Quaternion.identity);
        }
        if (isPatrolDuck)
        {
            start = null;
            transform.position = new Vector3(Nodes[currentNode].transform.position.x, Nodes[currentNode].transform.position.y, Nodes[currentNode].transform.position.z);
        }
        startPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, transform.eulerAngles.z);
        startRot.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);

        cc = GetComponent<CharacterController>();
        cc.detectCollisions = true;
        target = null;
        yPos = transform.position.y + 0.1f;

        ducks = GameObject.FindGameObjectsWithTag("Duck");
        FOV.SetActive(false);

        if (isGymDuck)
        {
            if (!isStageDuck){
            	LookAtTarget(stageduck);
            }
        }
        else
        {
            spot = null;
        }
    }

    void Update()
    {

        if (dying)
        {
            cc.detectCollisions = false;
            chasingPlayer = false;
            //transform.position = new Vector3(transform.position.x, transform.position.y - 0.05f, transform.position.z);
        }
        else if (!dying)
        {
            transform.position = new Vector3(transform.position.x, yPos, transform.position.z);


            playerDist = Vector3.Distance(DB.transform.position, transform.position);
            Vector3 playerDir = DB.transform.position - transform.position;
            Vector3 duckDir = transform.forward;
            playerAngle = Vector3.Angle(playerDir, duckDir);

            RayCheck();

            bool isPatrolling = false;

            if (chasingPlayer)
            {
                speed = chasingSpeed;
            }
            else
            {
                speed = normalSpeed;
            }

            if (isBasicDuck && !getBread)
            {
                GetPlayer();
            }
            else if (isPatrolDuck)
            {
                if (!getBread)
                {
                    GetPlayer();
                }
                if (!chasingPlayer && !getBread)
                {
                    Patrolling();
                    isPatrolling = true;
                }
            }

            //Soggy Moldy Toasty
            if (target != null && (target.CompareTag("Bread") || target.CompareTag("Soggy") || target.CompareTag("Toasty") || target.CompareTag("Moldy")))
            {
                if (!dying){
                    EatBread2();
                }
            }
            else if (target == null && !isResting && !playerInDist && !chasingPlayer && !isPatrolling)
            {
                ReturnToPost();
            }

            //DEBUG measure speed
            /*
			float velocity = Vector3.Distance(lastPos, transform.position) / Time.deltaTime;
			print(velocity);
			lastPos = transform.position;
			*/
        }

    }

    public void LookAtTarget(GameObject t)
    {
        smoothRotate.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        var newRotation = Quaternion.LookRotation(t.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(smoothRotate, newRotation, .85f);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }

    void ReturnToPost()
    {
        chasingPlayer = false;
        float returnDist;

        if (isBasicDuck && !isGymDuck)
        {
            returnDist = Vector3.Distance(start.transform.position, transform.position);
            LookAtTarget(start);
            if (returnDist > 0.5f)
            {
                cc.Move(transform.forward * Time.deltaTime * speed);
            }
            else
            {
                transform.rotation = startRot;
            }
        }
        else if (isPatrolDuck)
        {
            returnDist = Vector3.Distance(Nodes[currentNode].transform.position, transform.position);
            LookAtTarget(Nodes[currentNode]);
            if (returnDist > 0.5f)
            {
                cc.Move(transform.forward * Time.deltaTime * speed);
            }
            else
            {
                transform.rotation = startRot;
            }
        }

        playerInDist = false;
        playerInAngle = false;
        playerDetected = false;
    }

    public void GetPlayer()
    {
        if (isOutsideDuck == false)
        {
            if (goInside.insideLockerGlobal == false)
            {
                if (isResting == false)
                {
                    //Get distance to player
                    if (playerDist <= fovDist)
                    {
                        playerInDist = true;
                        //print ("duck sees player");
                    }
                    if (playerDist <= detectDist)
                    {
                        playerDetected = true;
                    }
                    //Get angle to player
                    if (playerAngle <= fovAngle)
                    {
                        playerInAngle = true;
                    }
                    //Get player
                    if ((playerInDist && playerInAngle && targetIsPlayer) || playerDetected)
                    {
                        //transform.LookAt(DB.transform);
                        chasingPlayer = true;
                    }
                    if (chasingPlayer)
                    {
                        LookAtTarget(DB);
                        //cc.Move(transform.forward * Time.deltaTime * speed);
                        Vector3 moveVector = DB.transform.position - transform.position;
                        moveVector.y = 0;
                        moveVector = Vector3.Normalize(moveVector); //Normalizing a vector always standardizes it back to a length of 1
                        cc.Move(moveVector * Time.deltaTime * speed);
                    }
                    //Eat player
                    if (playerDist <= eatDist && chasingPlayer)
                    {
                        HealthBar.hitPoints -= .005f;
                    }
                }
            }
            else
            {
                chasingPlayer = false;
                playerInDist = false;
                playerInAngle = false;
                playerDetected = false;
                targetIsPlayer = false;
            }
        }
        else if (isOutsideDuck)
        {
            if (chasingPlayer)
            {
                ODSeesPlayer = true;
            }
            if (goInside.insideLockerGlobal == false && (ODSeesPlayer == false || ODSeesPlayer))
            {
                if (isResting == false)
                {
                    //Get distance to player
                    if (playerDist <= fovDist)
                    {
                        playerInDist = true;
                        //print ("duck sees player");
                    }
                    if (playerDist <= detectDist)
                    {
                        playerDetected = true;
                    }
                    //Get angle to player
                    if (playerAngle <= fovAngle)
                    {
                        playerInAngle = true;
                    }
                    //Get player
                    if ((playerInDist && playerInAngle && targetIsPlayer) || playerDetected)
                    {
                        //transform.LookAt(DB.transform);
                        chasingPlayer = true;
                    }
                    //Demon Duck Get Player
                    if ((playerInDist && playerInAngle && isDemonDuck))
                    {
                        chasingPlayer = true;
                    }
                    if (chasingPlayer)
                    {
                        ODSeesPlayer = true;
                        LookAtTarget(DB);
                        //cc.Move(transform.forward * Time.deltaTime * speed);
                        Vector3 moveVector = DB.transform.position - transform.position;
                        moveVector.y = 0;
                        moveVector = Vector3.Normalize(moveVector); //Normalizing a vector always standardizes it back to a length of 1
                        cc.Move(moveVector * Time.deltaTime * speed);
                    }
                    //Eat player
                    if (playerDist <= eatDist && chasingPlayer)
                    {
                        HealthBar.hitPoints -= .005f;
                    }
                }
            }
            else if (goInside.insideLockerGlobal == true && ODSeesPlayer == false)
            {
                chasingPlayer = false;
                playerInDist = false;
                playerInAngle = false;
                playerDetected = false;
                targetIsPlayer = false;

            }
            else if (goInside.insideLockerGlobal == true && ODSeesPlayer)
            {
                if (isResting == false)
                {
                    //Get distance to player
                    if (playerDist <= fovDist)
                    {
                        playerInDist = true;
                        //print ("duck sees player");
                    }
                    if (playerDist <= detectDist)
                    {
                        playerDetected = true;
                    }
                    //Get angle to player
                    if (playerAngle <= fovAngle)
                    {
                        playerInAngle = true;
                    }
                    //Get player
                    if ((playerInDist && playerInAngle && targetIsPlayer) || playerDetected)
                    {
                        //transform.LookAt(DB.transform);
                        chasingPlayer = true;
                    }
                    if (chasingPlayer)
                    {
                        ODSeesPlayer = true;
                        LookAtTarget(DB);
                        //cc.Move(transform.forward * Time.deltaTime * speed);
                        Vector3 moveVector = DB.transform.position - transform.position;
                        moveVector.y = 0;
                        moveVector = Vector3.Normalize(moveVector); //Normalizing a vector always standardizes it back to a length of 1
                        cc.Move(moveVector * Time.deltaTime * speed);
                    }
                    //Eat player
                    if (playerDist <= eatDist && chasingPlayer)
                    {
                        HealthBar.hitPoints -= .005f;
                    }
                }
            }
        }
    }

    void RayCheck()
    {
        //Raycast to Check if Player is hidden behind obstacle
        Vector3 ray = transform.forward;
        RaycastHit rayHit = new RaycastHit();
        Debug.DrawRay(transform.position, ray * 100f, Color.yellow);
        if (Physics.Raycast(transform.position, ray, out rayHit))
        {
            if (rayHit.collider.CompareTag("Player") || playerDetected)
            {
                targetIsPlayer = true;
            }
            else
            {
                targetIsPlayer = false;
            }
        }
    }

    public void EatBread(GameObject bread)
    {
        target = bread.gameObject;
        getBread = true;
    }

    void EatBread2()
    {
        playerInDist = false;
        playerInAngle = false;
        playerDetected = false;
        breadDist = Vector3.Distance(target.transform.position, transform.position);
        if (getBread && !isResting)
        {
            LookAtTarget(target);
            cc.Move(transform.forward * Time.deltaTime * speed);
        }
        if (breadDist <= eatDist)
        {
            if (target.CompareTag("Moldy"))
            {
                print("dead duck");

                // calling the animator to trigger the death scene
                deadDemonAnim.SetBool("Dead", true);

                Destroy(target.gameObject);
                soul.SetActive(true);
                playerInDist = false;
                playerInAngle = false;
                playerDetected = false;
                target = null;
                dying = true;
            }
            else if (target.CompareTag("Soggy"))
            {
                Destroy(target.gameObject);
                StartCoroutine("Resting");
            }
            else
            {
                StartCoroutine("Resting");
            }
        }
    }

    public void ClearTarget()
    {
        target = null;
        getBread = false;
        transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, transform.eulerAngles.z);
    }

    IEnumerator Resting()
    {
        if (target != null)
        {
            Destroy(target.gameObject);
        }

        playerInDist = false;
        playerInAngle = false;
        playerDetected = false;
        isResting = true;
        transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, transform.eulerAngles.z);
        target = null;
        yield return new WaitForSeconds(restTime);
        foreach (GameObject d in ducks)
        {
            d.GetComponent<DuckCharacterController>().ClearTarget();
        }
        chasingPlayer = false;
        playerInDist = false;
        playerInAngle = false;
        playerDetected = false;
        targetIsPlayer = false;
        isResting = false;
        getBread = false;
    }

    void Patrolling()
    {
        target = Nodes[currentNode];

        float nodeDist = Vector3.Distance(target.transform.position, transform.position);

        if (nodeDist <= .5f)
        {
            if (!returning)
            {
                if (currentNode >= Nodes.Length - 1)
                {
                    currentNode--;
                    returning = true;
                }
                else
                {
                    currentNode++;
                }
            }
            else
            {
                if (currentNode <= 0 && returning)
                {
                    currentNode++;
                    returning = false;
                }
                else
                {
                    currentNode--;
                }
            }
        }

        LookAtTarget(target);
        cc.Move(transform.forward * Time.deltaTime * speed);

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Basketball") && isGymDuck)
        {
            spot.SetActive(true);
            foreach (GameObject d in ducks)
            {
                if (d.GetComponent<DuckCharacterController>().isGymDuck)
                {
                    d.GetComponent<DuckCharacterController>().LookAtTarget(DB);
                    d.GetComponent<DuckCharacterController>().PlayerInGym();
                }
            }
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;
        if (body != null)
        {
            Rigidbody rb = hit.gameObject.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 200);
        }
    }

    public void PlayerInGym()
    {
        playerDetected = true;
    }

}
