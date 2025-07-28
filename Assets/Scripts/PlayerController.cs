using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 15f;
    public float gridSize = 0.32f;
    public float moveCooldown = 0.01f;

    private Rigidbody2D rb;
    private Animator animator;
    private bool isMoving = false;
    private bool isJumping = false;
    private Vector2 inputDir;
    private Vector2 lastMoveDir = Vector2.down;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        // Body/Sprite ������ ������� Animator ��������
        Transform sprite = transform.Find("Sprite");
        if (sprite != null)
        {
            animator = sprite.GetComponent<Animator>();
        }

        if (animator == null)
        {
            Debug.LogError("Animator�� Body/Sprite���� ã�� �� �����ϴ�!");
        }
    }

    void Start()
    {
        rb.drag = 0f;
    }

    void FixedUpdate()
    {
        inputDir = Vector2.zero;

        if (Input.GetKey(KeyCode.UpArrow)) inputDir = Vector2.up;
        else if (Input.GetKey(KeyCode.DownArrow)) inputDir = Vector2.down;
        else if (Input.GetKey(KeyCode.LeftArrow)) inputDir = Vector2.left;
        else if (Input.GetKey(KeyCode.RightArrow)) inputDir = Vector2.right;

        bool isTryingToJump = Input.GetKeyDown(KeyCode.Space);

        // �ִϸ����� ������ �Ǿ� �ִٸ� �ִϸ��̼� �۵�
        if (animator != null)
        {
            animator.SetBool("isMoving", inputDir != Vector2.zero);
        }

        if (!isMoving && !isJumping)
        {
            if (isTryingToJump)
            {
                LookAtDirection(lastMoveDir);
                if (animator != null) animator.SetTrigger("Jump");
                StartCoroutine(JumpAnimationLock());
            }
            else if (inputDir != Vector2.zero)
            {
                Vector3 target = transform.position + (Vector3)inputDir * gridSize;
                if (!IsBlocked(target))
                {
                    LookAtDirection(inputDir);
                    StartCoroutine(MoveToPosition(target));
                    lastMoveDir = inputDir;
                }
            }
        }
        else if (isMoving && isTryingToJump && !isJumping)
        {
            LookAtDirection(lastMoveDir);
            if (animator != null) animator.SetTrigger("Jump");
            StopAllCoroutines(); // �̵� �� ���� �� �̵� ����
            isMoving = false;
            StartCoroutine(JumpAnimationLock());
        }
    }

    IEnumerator JumpAnimationLock()
    {
        isJumping = true;
        yield return new WaitForSeconds(0.4f); // ���� �ִϸ��̼� ���̿� ����
        isJumping = false;
    }

    bool IsBlocked(Vector3 target)
    {
        Collider2D hit = Physics2D.OverlapCircle(target, 0.05f);
        return hit != null && hit.gameObject.name == "Collision";
    }

    void LookAtDirection(Vector2 dir)
    {
        if (dir.x > 0)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        else if (dir.x < 0)
            transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    IEnumerator MoveToPosition(Vector3 target)
    {
        isMoving = true;

        while ((target - (Vector3)rb.position).sqrMagnitude > 0.01f)
        {
            Vector3 prev = rb.position;
            rb.MovePosition(Vector3.MoveTowards(rb.position, target, moveSpeed * Time.fixedDeltaTime));
            yield return null;

            if (((Vector3)rb.position - prev).sqrMagnitude < 0.0001f)
                break;
        }

        if (((Vector3)rb.position - target).sqrMagnitude < 0.05f)
            rb.MovePosition(target);

        yield return new WaitForSeconds(moveCooldown);
        isMoving = false;
    }
}
