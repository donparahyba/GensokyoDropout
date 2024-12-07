using UnityEngine;

public class ReimuWalks : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f; // velocidade
    private Rigidbody2D body; // provem fisica
    private Vector2 axisMovement; // vetor de duas dimensoes
    public Animator animator;

    void Start()
    {
        body = GetComponent<Rigidbody2D>(); // Pega o componente do objeto atrelado ao script
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Atualiza os valores de axisMovement com os inputs do jogador. Input.GetAxisRaw retorna -1, 0 ou 1 dependendo da entrada
        axisMovement.x = Input.GetAxisRaw("Horizontal");
        axisMovement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        // FixedUpdate é chamado em intervalos constantes, independente da taxa de quadros do jogo. É mais adequado para transformações físicas.
        Move();
    }

    private void Move()
    {
        // Aplica a movimentação ao Rigidbody2D, normalizando o vetor de movimento para garantir uma velocidade constante em todas as direções.
        body.linearVelocity = axisMovement.normalized * speed;

        if(axisMovement.x < 0)
        {
            animator.SetBool("WalkingLeft", true);
        }
        else
        {
            animator.SetBool("WalkingLeft", false);
        }

        if (axisMovement.x > 0)
        {
            animator.SetBool("WalkingRight", true);
        }
        else
        {
            animator.SetBool("WalkingRight", false);
        }
    }
}