using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class joystickScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private Image joystickBG;
    private Image joystick;
    private Vector2 inputVector; //���������� ��������
    private Rigidbody sausageRb;
    public GameObject sausage;
    public float force;
    public Ballistica ballistica;
    public GameObject center;
    public Text text;
    private death death;
    private bool pressed = false;

    // Start is called before the first frame update
    void Start()
    {//�������� �������
        joystickBG = GetComponent<Image>();
        joystick = transform.GetChild(0).GetComponent<Image>();
        death = sausage.GetComponent<death>();
        sausageRb = sausage.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {   //��������� ���������� ���� ���� �������
        if(sausage.transform.position.x < -45)
        {
            text.text = "� ���!1!!!!";
        }
        else
        {
            text.text = "";
        }
        if(pressed)
            ballistica.ShowTrajectory(center.transform.position, new Vector3(inputVector.x * force / 50, inputVector.y * -force / 50, 0f));
    }

    public void OnPointerDown(PointerEventData ped)
    {
        pressed = true;
        OnDrag(ped);
    }

    public void OnPointerUp(PointerEventData ped)
    {
        if (death.onGround)
        {//���� ������� ����������, ��������� �� �����������
            Vector3 vec = new Vector3(inputVector.x * force, inputVector.y * -force, 0f);
            sausageRb.velocity = Vector3.zero;
            sausageRb.angularVelocity = Vector3.zero;
            sausageRb.AddForce(vec);
        }        
        //�������� ��������� ��������
        inputVector = Vector2.zero;
        joystick.rectTransform.anchoredPosition = Vector2.zero;

        //������� ����������
        ballistica.ClearTrajectory();
        pressed = false;
    }

    public void OnDrag(PointerEventData ped)
    {
        Vector2 pos;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickBG.rectTransform, ped.position, ped.pressEventCamera, out pos))
        {
            //�������� ���������� ������� �����
            pos.x = (pos.x / joystickBG.rectTransform.sizeDelta.x);
            pos.y = (pos.y / joystickBG.rectTransform.sizeDelta.y);

            //��������� ���������
            inputVector = new Vector2(pos.x * 2, pos.y * 2);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

            //��������� ����� � ��������� ����
            joystick.rectTransform.anchoredPosition = new Vector2(inputVector.x * (joystickBG.rectTransform.sizeDelta.x / 2), inputVector.y * (joystickBG.rectTransform.sizeDelta.y / 2));

        }
    }
}
