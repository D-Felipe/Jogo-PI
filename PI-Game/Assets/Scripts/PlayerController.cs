using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public CharacterController controller; // Essa linha aplica o controle do player;
    public float speed = 7f;  // Isso e a velocidade dele;
    RaycastHit hit;  // A variavel necessaria para o player olhar para onde o mouse for;
    Rigidbody rb;   // Uma variavel para criar o Rigidbody;
    public Transform playerTransform;
    public Vector3 direction;
    [SerializeField]float MaxHealth;
    [SerializeField]float currentHealth;
    [SerializeField]float EnemyDamage;//que ele toma
    public HealthBarScript Healthbar;
    private Camera mainCamera;
    Vector3 lookPos;
    public GameObject spawnPoint;

    void Start()
    {
        Healthbar.SetMaxHealth(MaxHealth);
        currentHealth = MaxHealth;
        mainCamera = Camera.main;
        Gun.AmmoType = 0;
    }

    void Update()
    {
        
        rb = GetComponent<Rigidbody>(); //Instanciamento do Rigidbody;
        float horizontal = Input.GetAxisRaw("Horizontal"); // Controle da Linha X (A,D);
        float vertical = Input.GetAxisRaw("Vertical");     // Controle da Linha Y (W,S);
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized; // Permite se mover para horizontal, vertical e trava o Eixo Z;
        controller.Move(direction * speed * Time.deltaTime); // O calculo necessario para que a velocidade e direcao funcionem;
        if (direction.magnitude >= 0.1) //Isso influencia no controle da velocidade do player;
        {
            controller.Move(direction * speed * Time.deltaTime);

        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;     
        if(Physics.Raycast(ray, out hit,30))
        {
            lookPos = hit.point;
        }
        Vector3 lookDir = lookPos - transform.position;
        lookDir.y = 0;
        transform.LookAt(transform.position + lookDir, Vector3.up);
       
    
        
    }
    void TakeDamage(){
        currentHealth -= EnemyDamage;
        Debug.Log("the player gets hurts:"+currentHealth+" is remaining!");
        Healthbar.SetHealth(currentHealth);
        if (currentHealth <= 0)
            SceneManager.LoadScene("Tutorial");
    }
    void FireDamage()
    {
        
    }
    void OnTriggerEnter(Collider collider)
    {

    if(collider.gameObject.tag == "bullet")
    {
        TakeDamage();

    }

    if (collider.gameObject.tag == "FireAmmo")
    {
      
       print("sou a muniçao de fogo yay");
       Gun.AmmoType = 1;
    }
    
    }
}

    

