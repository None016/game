using UnityEngine;

public class Control : MonoBehaviour
{
    public float moveSpeed = 5f; // Скорость перемещения
    public float moveRun = 10f; //
    public AnimationCurve jumpCurve; // Кривая для прыжка
    public float jumpHeight = 5f; // Максимальная высота прыжка
    public float jumpDuration = 1f; // Длительность прыжка
    public float autoJumpThreshold = 0.2f; // Расстояние до платформы для автоматического прыжка

    public Animator anim;
    public SpriteRenderer spriteRenderer;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isWall;
    private bool isJumping;
    private bool isJumpRequested; // Флаг для запроса прыжка
    private float jumpTimer;
                                                                 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Перемещение влево и вправо

        if (!(isGrounded == false && isWall == true))
        {
            if (Input.GetKey(KeyCode.D))
            {
                rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
                anim.SetInteger("moveX", 1);
                spriteRenderer.flipX = false;
            } else if (Input.GetKey(KeyCode.A))
            {
                rb.linearVelocity = new Vector2(-moveSpeed, rb.linearVelocity.y);
                anim.SetInteger("moveX", 1);
                spriteRenderer.flipX = true;
            }
            else
            {
                anim.SetInteger("moveX", 0);
                rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);
            }


            if (Input.GetKey(KeyCode.D) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
            {
                rb.linearVelocity = new Vector2(moveRun, rb.linearVelocity.y);
                anim.SetBool("run", true);
                spriteRenderer.flipX = false;
            }
            else if (Input.GetKey(KeyCode.A) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
            {
                rb.linearVelocity = new Vector2(-moveRun, rb.linearVelocity.y);
                anim.SetBool("run", true);
                spriteRenderer.flipX = true;
            }
            else
            {
                anim.SetBool("run", false);
            }
        }


        // Начало прыжка
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                StartJump();
            }
            else
            {
                // Если персонаж в воздухе, запрашиваем прыжок
                isJumpRequested = true;
            }
        }

        // Обработка прыжка
        if (isJumping)
        {
            // Если кнопка прыжка зажата, продолжаем прыжок
            if (Input.GetKey(KeyCode.Space) && jumpTimer < jumpDuration)
            {
                anim.SetInteger("moveX", 0);
                anim.SetInteger("jump", 2);
                jumpTimer += Time.deltaTime;

                // Применение силы прыжка по кривой
                float jumpProgress = jumpTimer / jumpDuration;
                float jumpForce = jumpCurve.Evaluate(jumpProgress) * jumpHeight;

                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            }
            else
            {
                // Если кнопка отпущена или время прыжка истекло, завершаем прыжок
                anim.SetInteger("moveX", 0);
                anim.SetInteger("jump", 3);
                isJumping = false;
            }
        }

        // Проверка на автоматический прыжок при приземлении
        if (isJumpRequested && isGrounded)
        {
            StartJump();
            isJumpRequested = false;
        }

        if (isGrounded)
        {
            anim.SetInteger("jump", 4);
        }
    }

    private void StartJump()
    {
        isJumping = true;
        jumpTimer = 0f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("plotform"))
        {
            isGrounded = true;
            anim.SetInteger("jump", 4);

            // Проверка расстояния до платформы
            float distance = Mathf.Abs(collision.transform.position.y - transform.position.y);
            if (distance <= autoJumpThreshold && isJumpRequested)
            {
                anim.SetInteger("moveX", 0);
                anim.SetInteger("jump", 2);
                StartJump();
                isJumpRequested = false;
            }
        }

        if (collision.gameObject.CompareTag("wall"))
        {
            isWall = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("plotform"))
        {
            isGrounded = false;
        }

        if (collision.gameObject.CompareTag("wall"))
        {
            isWall = false;
        }
    }


}