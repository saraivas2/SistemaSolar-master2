using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_nave1 : MonoBehaviour
{
    // Start is called before the first frame update
    public bool travarMouse = true;
    public float sensibilidade = 1.2f;
    private float velocidade;
    private float aceleracao = 3.0f;
    private float turbo = 1.0f;
    private Vector3 direcao;
    private float mouseX = 0.0f, mouseY = 0.0f;
    [SerializeField] private Camera camera;
    public float field;

    private void Awake()
    {
        
    }
    void Start()
    {
        velocidade = 2;
        direcao = Vector3.zero;
        camera = camera.GetComponent<Camera>(); 

        if (!travarMouse)
        {
            return;
        }
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.eulerAngles = new Vector3(transform.eulerAngles.x, camera.eulerAngles.y, transform.eulerAngles.z);
        InputPersonagem();
        transform.Translate(direcao * velocidade * Time.deltaTime);
       
        // Smoothly tilts a transform towards a target rotation.
        mouseY += Input.GetAxis("Mouse X") * sensibilidade;
        mouseX += Input.GetAxis("Mouse Y") * sensibilidade;

        transform.eulerAngles = new Vector3(mouseX, mouseY, 0);

        field = camera.fieldOfView;
        if (field > 50f)
        {
            camera.fieldOfView = 50f;
        }
        if (field < 35f)
        {
            camera.fieldOfView = 35f;
        }
    }

    void aproxima()
    {
        if (camera.fieldOfView > 35f)
        {
            camera.fieldOfView = field - 0.1f;
        }
    }

    void afasta()
    {
       if (camera.fieldOfView < 50f) 
        {
            field = camera.fieldOfView;
            camera.fieldOfView = field+0.1f;
        }
    }
    void InputPersonagem()
    {

        direcao = Vector3.zero;

        if (Input.GetKey(KeyCode.Q))
        {
            turbo = 4.0f;
        }
        else
        {
            turbo = 1.0f;
        }
        if (Input.GetKey(KeyCode.W))
        {
            direcao += Vector3.forward * aceleracao * turbo;
            if (field <= 50f)
            {
                afasta();
            }
            if (aceleracao < 50)
            {
                aceleracao += 0.5f;
            }

        }
        else
        {
            if (aceleracao > 5)
            {
                aceleracao -= 0.2f;
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0f, -1f, 0f), (float)(Time.deltaTime * 20));
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0f, 1f, 0f), (float)(Time.deltaTime * 20));
        }

        if (Input.GetKey(KeyCode.S))
        {
            direcao += Vector3.back * aceleracao * turbo;
            
            if (aceleracao < 50)
            {
                aceleracao += 0.5f;
            }
        }
        else
        {
            if (aceleracao > 5)
            {
                aceleracao -= 0.2f;
            }
        }

        if ((field>=34 & field < 51) & !Input.GetKey(KeyCode.W))
            {
                aproxima();
            }
        
    }
}
