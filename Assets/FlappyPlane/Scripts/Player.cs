using UnityEngine;

namespace MinigameFlap
{
    public class Player : MonoBehaviour
    {
        // Start is called before the first frame update
        Animator animator;
        Rigidbody2D _rigidbody;

        public float flapforce = 6f;
        public float forwardspeed = 3f;
        public bool isDead = false;
        float deathCooldown = 0f;

        bool isFlap = false;

        public bool godMode = false;

        GameManager gameManager;





        void Start()
        {
            gameManager = GameManager.Instance;

            animator = GetComponentInChildren<Animator>();
            _rigidbody = GetComponent<Rigidbody2D>();

            if (animator == null)
            {
                Debug.LogError("�ִϸ����͸� ã�� �� �����ϴ�");
            }

            if (_rigidbody == null)
            {
                Debug.LogError("�����ٵ� ã�� �� �����ϴ�");
            }

        }

        // Update is called once per frame
        void Update()
        {
            if (isDead)
            {   //����� ���� ��
                if (deathCooldown <= 0)
                {
                    //���� �����
                    if (Input.GetKey(KeyCode.Space) || Input.GetMouseButtonDown(0))
                    {
                        gameManager.GameOver();
                    }
                }
                else
                {
                    deathCooldown -= Time.deltaTime;
                }
            }
            else
            {
                if (Input.GetKey(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    isFlap = true;
                }
            }


        }

        private void FixedUpdate()
        {
            // ȸ���� �ִ� �κ�
            if (isDead) return;
            Vector3 velocity = _rigidbody.velocity;
            velocity.x = forwardspeed;

            if (isFlap)
            {
                velocity.y = flapforce;
                isFlap = false;
            }

            _rigidbody.velocity = velocity;

            float angle = Mathf.Clamp((_rigidbody.velocity.y * 10f), -90, 90);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }


        private void OnCollisionEnter2D(Collision2D collision)
        {
            //�����浹 ���� / ����ִϸ��̼���ȯ
            if (godMode) return;

            if (isDead) return;

            isDead = true;

            deathCooldown = 1f;

            animator.SetInteger("IsDie", 1);
            gameManager.GameOver();

        }

    }
}