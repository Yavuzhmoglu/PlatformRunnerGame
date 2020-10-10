using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
   
    public bool isPlaying;
    [SerializeField] float forwardSpeed;
    Rigidbody myRgb;
    [SerializeField] float sideLerpSpeed;
    Animator animator;
    [SerializeField] Transform Zone;
    Transform transformPlayer;

    public int distance;
    public bool Win;

    public GameObject Brush;
    public float BrushSize;
    public GameObject Wall;

    public GameObject Bullet;
    public Transform BulletZone;
    int bullets;

    public Text BulletText;
    public GameObject TouchText;
    public GameObject PaintSText;
    public GameObject NextButton;
    public GameObject FireButton;
    void Start()
    {

        myRgb = GetComponent<Rigidbody>();

        transformPlayer = GetComponent<Transform>();

        animator = GetComponent<Animator>();
        bullets = 1;
    }

    void Update()
    {

        distance = (int)(Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Wall").GetComponent<Transform>().position));
        BulletText.text = "Bullet : " + bullets.ToString();
        if (isPlaying)
        {
            MoveForward();
            TouchText.SetActive(false);
            if(bullets > 0)
            {
                FireButton.GetComponent<Button>().interactable = true;

            }
            else
            {
                FireButton.GetComponent<Button>().interactable = false;

            }

        }

       
      
       
        if (Input.GetMouseButton(0))
        {

            animator.SetBool("Start", true);

            if (isPlaying == false)
            {
             
                isPlaying = true;
                
            }
            MoveSideways();

        }
        paint();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            transformPlayer.position = Zone.position;
            
        }
        if (other.tag == "Bulletstation")
        {
            bullets++;
            other.gameObject.SetActive(false);
        }

        if (other.tag == "finish")
        {
            forwardSpeed = 0;
            sideLerpSpeed = 0;
            animator.SetBool("dance", true);
            transform.Rotate(0,180,0);
            other.gameObject.SetActive(false);
            Win = true;
            PaintSText.SetActive(true);
        }
    }
    void MoveForward()
    {
        myRgb.velocity = Vector3.forward * forwardSpeed;

    }
    void MoveSideways()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(hit.point.x, transform.position.y, transform.position.z), sideLerpSpeed * Time.deltaTime);
        }

    }
    public void Fire()
    {
        if ( bullets > 0)
        {


            GameObject b = Instantiate(Bullet, BulletZone.position, Quaternion.identity);
            bullets--;
            Rigidbody rb = b.GetComponent<Rigidbody>();

            rb.velocity = transformPlayer.forward * 3000 * Time.deltaTime;

            Destroy(b, 3.0f);

        }
    }
    void paint()
    {
        if (Input.GetMouseButton(0))
        {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit2;
        if (Physics.Raycast(ray, out hit2, 300))
        {
            if (hit2.collider.gameObject.tag == "Wall")
            {

               

                Instantiate(Brush, hit2.point + Vector3.up * BrushSize, Quaternion.identity);
                    PaintSText.SetActive(false);
                    NextButton.SetActive(true);

                }

        }


       
        }

    }

}

