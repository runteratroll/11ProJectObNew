
using UnityEngine;
using System;


public class PlayerController : MonoBehaviour
{
    public static bool canMove = false;

    public CameraShake cameraShacke;
    public event Action OnMouseClick;

    public GameObject Paticle;
    public DataInput inputData;
    public LayerMask layerToCollideWith;


    public float moveSpeed = 5f;
    public float currentSpeed = 20f;

    Vector3 m_dir;
    Vector3 m_clickPos;
    Vector3 m_releasPos;


    public Rigidbody2D m_rigid2D;

    
    Camera m_cam;
    PlayerVFx m_playerVFX;
    Animator anim;

    bool m_hitBlock;
    float CurrentSpeed;

  
    void Start()
    {
       
        currentSpeed = moveSpeed;
        GetComponents();
        
    }

    void GetComponents()
    {
        m_rigid2D = GetComponent<Rigidbody2D>();
        m_playerVFX = GetComponent<PlayerVFx>();
        anim = GetComponent<Animator>();
        m_cam = FindObjectOfType<Camera>();

    }


    void Update()
    {
        HandleMovement();
    }


    void InputAttack()
    {
        if(Input.GetMouseButtonDown(0) && isMoving)
        {
            anim.SetTrigger("attack");
        }
    }
    bool isMoving = false;
    void HandleMovement()
    {
        // 20 > 5 크니 트루

       


        if (inputData.isPressed == true )
        {
            Debug.Log("dsdsd");
            m_clickPos = m_cam.ScreenToWorldPoint(Input.mousePosition);
            m_clickPos = new Vector3(m_clickPos.x, m_clickPos.y, 0f);
            isMoving = false;
            //StartCoroutine(CameraShake.Instance.ShakeCoroutin());
            m_hitBlock = CheckIfHitBlock();

            if (m_hitBlock)
                return;

            
            //moveSpeed = currentSpeed;

            
        
            //ResetPlayerPos();

            m_playerVFX.SetDotStartPos(transform.position);

            m_playerVFX.ChangeDotActiveState(true);
            m_playerVFX.ChangeTrailState(false, 0f);



            if (OnMouseClick != null)
                OnMouseClick();

            OnMouseClick?.Invoke();
           
        }
        if(inputData.isHeld == true )
        {
            if (m_hitBlock)
                return;

            
            m_playerVFX.MakeBallPulse();
            
            
            //CalculateDirection();
            
            m_playerVFX.SetDotPos(transform.position, m_cam.ScreenToWorldPoint(Input.mousePosition));
        }

        if(inputData.isReleased == true )
        {

            if (m_hitBlock)
                return;
            
            m_releasPos = m_cam.ScreenToWorldPoint(Input.mousePosition);
            m_releasPos = new Vector3(m_releasPos.x, m_releasPos.y, 0f);
            isMoving = true;

            m_playerVFX.ChangeDotActiveState(false);

            CalculateDirection();
            m_playerVFX.ResetBallSize();
            m_playerVFX.ChangeTrailState(true, 0.75f);
            MovePlayerInDirectiion();
            
            moveSpeed = currentSpeed;
        }
        
    }

    void CalculateDirection()
    {
        m_dir = (m_releasPos - transform.position ).normalized;
    }

    void MovePlayerInDirectiion()
    {
        m_rigid2D.velocity = m_dir * moveSpeed;
    }

    public void ResetPlayerPos()
    {
        transform.position = m_clickPos;
        m_rigid2D.velocity = Vector3.zero;
    }

    public bool isWall = false;
    bool isBlock =false;


    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(m_rigid2D.velocity);

        if (collision.gameObject.CompareTag("Block") && !isBlock)
        {



            StartCoroutine(cameraShacke.ShakeCoroutin());
            //isBlock = true;
            Vector2 _wallNormal = collision.contacts[0].normal; //첫번째로 닿는 면의 법선
            m_dir = Vector2.Reflect(m_rigid2D.velocity, _wallNormal).normalized;

            moveSpeed = currentSpeed;
            m_rigid2D.velocity = m_dir * moveSpeed;
            Invoke(nameof(BlockW), 0.2f);



        }
        isBlock = false;

        

        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Wall") && !isWall)
        {
            //isWall = true;
            StartCoroutine(cameraShacke.ShakeCoroutin());


            Vector2 _wall1Normal = collision.contacts[0].normal; //첫번째로 닿는 면의 법선
            m_dir = Vector2.Reflect(m_rigid2D.velocity, _wall1Normal).normalized;

            moveSpeed -= 3f;
            Debug.Log("Wall +" + moveSpeed);

            Debug.Log(m_rigid2D.velocity);
            Debug.Log(_wall1Normal);
            Debug.Log(m_dir);
            m_rigid2D.velocity = m_dir * moveSpeed;
            Invoke(nameof(MoveSPeed), 0.3f);
        }

        ContactPoint2D contactPoint2D = collision.contacts[0]; //가장 가까운 접촉면
                                                               //충돌한 객체의 '접촉면'에 대한 정보가 담긴 클래스 충돌한 객체의 접촉면 정보가 담김
        SoundManager.instance.PlaySE("Block"); //레이저총이라면 이효과음이 나므로 변해하 하면 변수
        var RecochetClone = Instantiate(Paticle, contactPoint2D.point, Quaternion.LookRotation(contactPoint2D.normal));
      
        Destroy(RecochetClone, 1f);
        //PoolManager.ReturnToPool(gameObject);


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Zone"))
        {
            moveSpeed = 60;
        }
    }
    void MoveSPeed()
    {
        isWall = false;
    }

    void BlockW()
    {
        isBlock = false;
    }
   
    bool CheckIfHitBlock()
    {
        Ray _ray = m_cam.ScreenPointToRay(Input.mousePosition);

        RaycastHit2D _hitBlock =  Physics2D.Raycast(_ray.origin, _ray.direction, 100f, layerToCollideWith);

        return _hitBlock;
    }
}
