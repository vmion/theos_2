using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Char_ani :  MonoBehaviour
{    
    [SerializeField]
    private Transform Char;
    [SerializeField]
    private Transform Cam;
    Animator ani;
    public Image hp;
    public static float moveSpeed;
    //Vector2 centerPos;
    //Vector2 LcenterPos;
    //public Image JoyStick;
    //public Image JoyStick_Lever;
    //Vector2 CcenterPos;
    //Vector2 LCcenterPos;
    //public Image Rotate_Camera;
    //public Image Camera_Lever;
    [SerializeField]
    private Image Skill_1;
    [SerializeField]
    private Image Skill_2;
    [SerializeField]
    private Image Skill_3;
    [SerializeField]
    private Image Skill_4;
    [SerializeField]
    private Image Portion;

    public ParticleSystem buff;
    public AudioSource skillAudio1;

    public GameObject marker;
    public GameObject minimpaCam;
    
    void Start()
    {
        Char = Character_Manager.instance.transform.GetChild(0);
        ani = Char.GetComponent<Animator>();
        moveSpeed = 3f;
        //centerPos = JoyStick.rectTransform.position;
        //CcenterPos = Rotate_Camera.rectTransform.position;
        ani.SetBool("Dead", false);
    }    
    public void Move()
    {        
        //LcenterPos = JoyStick_Lever.rectTransform.position;
        //Vector2 moveVec = (LcenterPos - centerPos).normalized;
        //Vector2 moveInput = new Vector2(moveVec.x, moveVec.y);
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        bool isMove = moveInput.magnitude != 0;        
        ani.SetBool("isMove", isMove); 
        if(isMove)
        {
            Vector3 lookforward = new Vector3(Cam.forward.x, 0f, Cam.forward.z).normalized;
            Vector3 lookRight = new Vector3(Cam.right.x, 0f, Cam.right.z).normalized;
            Vector3 moveDir = lookforward * moveInput.y + lookRight * moveInput.x;
            Char.forward = lookforward;            
            transform.position += moveDir * moveSpeed * Time.deltaTime; 
        }        
        if (hp.fillAmount == 0)
        {
            moveSpeed = 0;
            ani.SetBool("Dead", true);
        }        
    }  
    
    public void LookAround()
    {        
        //LCcenterPos = Camera_Lever.rectTransform.position;
        //Vector2 moveVec = (LCcenterPos - CcenterPos).normalized;
        //Vector2 rotateInput = new Vector2(moveVec.x, moveVec.y);
        Vector2 rotateInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        Vector3 camAngle = Cam.rotation.eulerAngles;
        float x = camAngle.x - rotateInput.y;

        if (x < 180f)
        {
            x = Mathf.Clamp(x, -1f, 70f);
        }
        else
        {
            x = Mathf.Clamp(x, 335f, 361f);
        }
        Cam.rotation = Quaternion.Euler(x, camAngle.y + rotateInput.x, camAngle.z);
    }
    public void ButtonSkill()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(Skill_1.fillAmount == 1)
            {                
                StartCoroutine(CoolTime(Skill_1, 1));                
                ani.SetTrigger("Attack");                
                skillAudio1.Play();
            }
            else
            {
                Debug.Log("쿨타임입니다.");                
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (Skill_2.fillAmount == 1)
            {
                StartCoroutine(CoolTime(Skill_2, 3));
                ani.SetTrigger("Swing");
            }
            else
            {
                Debug.Log("쿨타임입니다.");
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (Skill_3.fillAmount == 1)
            {
                StartCoroutine(CoolTime(Skill_3, 5));
                ani.SetTrigger("Sting");
            }
            else
            {
                Debug.Log("쿨타임입니다.");
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (Skill_4.fillAmount == 1)
            {
                StartCoroutine(CoolTime(Skill_4, 0));
                ani.SetTrigger("Buff");
                StartCoroutine(OnBuff(20));
                Vector3 rotation = new Vector3(-90, 0, 0);
                ParticleSystem instance = Instantiate(buff, transform.position, Quaternion.Euler(rotation));
                Destroy(instance.gameObject, instance.main.duration);
            }
            else
            {
                Debug.Log("쿨타임입니다.");
            }
        }
    }    
    public void ButtonPortion()
    {
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (Portion.fillAmount == 1 && hp.fillAmount != 1)
            {
                hp.fillAmount += 0.2f;
                StartCoroutine(CoolTime(Portion, 10));
            }
            else
            {
                Debug.Log("쿨타임입니다.");
            }
            if(hp.fillAmount == 1)
            {
                Debug.Log("HP가 가득 차 있습니다.");
            }
        }
    }
    IEnumerator OnBuff(int time)
    {
        while(time > 0)
        {                                          
            time--;
            yield return new WaitForSecondsRealtime(0.1f);
        }
        
    }
    IEnumerator CoolTime(Image _image, float cool)
    {
        while(cool > 1.0f)
        {
            cool -= Time.deltaTime;
            _image.fillAmount = (1.0f / cool);
            yield return new WaitForFixedUpdate();
        }
    }
   
    void Update()
    {        
        //LookAround();
        Move();
        ButtonSkill();
        ButtonPortion();

        marker.transform.position = new Vector3(Char.transform.position.x, marker.transform.position.y,
            Char.transform.position.z);
        marker.transform.forward = -(Char.transform.forward);
        minimpaCam.transform.position = new Vector3(Char.transform.position.x, minimpaCam.transform.position.y,
            Char.transform.position.z);
    }    
}
