using Assets.Scripts.Characters;
using UnityEngine;

namespace Assets.Scripts.Inputs
{
    [RequireComponent(typeof(Player), typeof(Rigidbody2D))]
    public class InputMovement : MonoBehaviour
    {
        public float defaultMovementSpeed = 5f;
        Rigidbody2D rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        void FixedUpdate()
        {
            Vector3 currentPos = transform.position;
            /*
            if(Input.GetAxis("Horizontal") < 0f)
                currentPos.x -= Time.deltaTime * defaultMovementSpeed;
            if (Input.GetAxis("Horizontal") > 0f)
                currentPos.x += Time.deltaTime * defaultMovementSpeed;

            if (Input.GetAxis("Vertical") < 0f)
                currentPos.y -= Time.deltaTime * defaultMovementSpeed;
            if (Input.GetAxis("Vertical") > 0f)
                currentPos.y += Time.deltaTime * defaultMovementSpeed;*/


            float xMovement = Input.GetAxisRaw("Horizontal")/* * Time.deltaTime */;
            float yMovement = Input.GetAxisRaw("Vertical")/* * Time.deltaTime */;

            /*
            currentPos.x += xMovement;
            currentPos.y += yMovement;
            transform.position = currentPos;
            */

            rb.velocity = new Vector2(xMovement, yMovement).normalized * Consts.OVERALL_MOVING_SPEED * defaultMovementSpeed;

            // depends on key
        }
    }
}
