using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public CharacterController controller; // Essa linha aplica o controle do player;
    [SerializeField] float speed = 7f;  // Isso e a velocidade dele;
    RaycastHit hit;  // A variavel necessaria para o player olhar para onde o mouse for;
    Rigidbody rb;   // Uma variavel para criar o Rigidbody;
    public Transform playerTransform;
    public Vector3 direction;

    [SerializeField]float MaxHealth;
    [SerializeField]float currentHealth;
    [SerializeField]float EnemyDamage;

    void Start()
    {
        currentHealth = MaxHealth;
    }
    void Update()
    {
        rb = GetComponent<Rigidbody>(); //Instanciamento do Rigidbody;
        float horizontal = Input.GetAxisRaw("Horizontal"); // Controle da Linha X (A,D);
        float vertical = Input.GetAxisRaw("Vertical");     // Controle da Linha Y (W,S);
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized; // Permite se mover para horizontal, vertical e trava o Eixo Z;
        controller.Move(direction * speed * Time.deltaTime);
        controller.Move(direction * speed * Time.deltaTime); // O calculo necessario para que a velocidade e direcao funcionem;
        if (direction.magnitude >= 0.1) //Isso influencia no controle da velocidade do player;
        {
            controller.Move(direction * speed * Time.deltaTime);
        }

        //Mec�nica que faz com que o player rotacione de acordo com o mouse;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
        {
            Vector3 playerToMouse = hit.point - transform.position;
            playerToMouse.y = 0;
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            rb.MoveRotation(newRotation);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        TakeDamage();
    }
    void TakeDamage(){
        currentHealth -= EnemyDamage;
        Debug.Log("the enemie gets hurts:"+currentHealth+" is remaining!");
        if(currentHealth <=0)
        Destroy(this.gameObject);
    }
}
