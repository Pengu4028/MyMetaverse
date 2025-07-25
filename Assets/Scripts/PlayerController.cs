using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 15f;
    public float gridSize = 0.32f;
    public float moveCooldown = 0.01f;

    private Rigidbody2D rb;
    private bool isMoving = false;
    private bool isJumping = false;
    private Vector2 inputDir;
    private Vector2 lastMoveDir = Vector2.down; // 기본 방향 (아래)


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb.drag = 0f;
    }

    void Update()
    {
        inputDir = Vector2.zero;

        if (Input.GetKey(KeyCode.UpArrow)) inputDir = Vector2.up;
        else if (Input.GetKey(KeyCode.DownArrow)) inputDir = Vector2.down;
        else if (Input.GetKey(KeyCode.LeftArrow)) inputDir = Vector2.left;
        else if (Input.GetKey(KeyCode.RightArrow)) inputDir = Vector2.right;

        bool isTryingToJump = Input.GetKey(KeyCode.Space);

        if (!isMoving && !isJumping)
        {
            if (isTryingToJump)
            {
                if (inputDir == Vector2.zero)
                {
                    // 제자리 점프
                    LookAtDirection(lastMoveDir);
                    StartCoroutine(JumpInPlace());
                }
                else
                {
                    // 이동방향 점프 (2칸)
                    Vector2 jumpDir = inputDir;
                    Vector3 target = transform.position + (Vector3)jumpDir * gridSize * 2f;

                    if (!IsBlocked(target))
                    {
                        LookAtDirection(jumpDir);
                        StartCoroutine(JumpToPosition(target));
                        lastMoveDir = jumpDir;
                    }
                }
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
            // 이동 중에 점프 시도 (이동 방향 2칸 점프)
            Vector2 jumpDir = lastMoveDir;
            Vector3 target = transform.position + (Vector3)jumpDir * gridSize * 2f;

            if (!IsBlocked(target))
            {
                LookAtDirection(jumpDir);
                StopAllCoroutines(); // 이동 코루틴 멈추고 점프 시작
                isMoving = false;
                StartCoroutine(JumpToPosition(target));
            }
        }
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

    IEnumerator JumpToPosition(Vector3 target)
    {
        isJumping = true;

        Vector3 start = rb.position;
        float duration = 0.25f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float t = elapsed / duration;
            float height = Mathf.Sin(Mathf.PI * t) * 0.2f;

            // y축 위치는 고정, 점프 효과는 자식 오브젝트 등에서 구현
            Vector3 newPos = Vector3.Lerp(start, target, t);
            newPos.y = start.y; // y 고정

            rb.MovePosition(newPos);

            // 만약 점프 비주얼을 위해 별도 Sprite 위치 조절 가능 (아래 참고)
            elapsed += Time.deltaTime;
            yield return null;
        }

        rb.MovePosition(target);

        yield return new WaitForSeconds(moveCooldown);
        isJumping = false;
    }


    // 제자리 점프 코루틴 (x, z 좌표 고정, y축만 튀어오름)
    IEnumerator JumpInPlace()
    {
        isJumping = true;

        Vector3 start = rb.position;
        float duration = 0.25f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float t = elapsed / duration;
            float height = Mathf.Sin(Mathf.PI * t) * 0.5f;
            Vector3 newPos = start;
            newPos.y += height;

            rb.MovePosition(newPos);

            elapsed += Time.deltaTime;
            yield return null;
        }

        rb.MovePosition(start);

        yield return new WaitForSeconds(moveCooldown);
        isJumping = false;
    }

    IEnumerator MoveToPosition(Vector3 target)
    {
        isMoving = true;

        while ((target - (Vector3)rb.position).sqrMagnitude > 0.01f)
        {
            Vector3 prev = rb.position;
            rb.MovePosition(Vector3.MoveTowards(rb.position, target, moveSpeed * Time.deltaTime));
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
