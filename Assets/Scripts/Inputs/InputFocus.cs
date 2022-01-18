using Assets.Scripts.Characters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Inputs
{
    [RequireComponent(typeof(Player))]
    public class InputFocus : MonoBehaviour
    {
        public SpriteRenderer SpriteRenderer = null;
        public float FadeTime = 0.3f;



        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.LeftShift))
                StartCoroutine(FadeTo(SpriteRenderer, 1f));
            else
                StartCoroutine(FadeTo(SpriteRenderer, 0f));


        }

        IEnumerator FadeTo(SpriteRenderer _sprite, float opacityGoal)
        {
            Color tmpColor = _sprite.color;

            if (opacityGoal < tmpColor.a)
            {
                while (opacityGoal < tmpColor.a)
                {
                    tmpColor.a -= Time.deltaTime * FadeTime;
                    _sprite.color = tmpColor;

                    if (opacityGoal > tmpColor.a)
                        tmpColor.a = opacityGoal;

                    yield return null;
                }
            }
            if (opacityGoal > tmpColor.a)
            {
                while (opacityGoal > tmpColor.a)
                {
                    tmpColor.a += Time.deltaTime * FadeTime;
                    _sprite.color = tmpColor;

                    if (opacityGoal < tmpColor.a)
                        tmpColor.a = opacityGoal;

                    yield return null;
                }
            }

            _sprite.color = tmpColor;
        }


    }

}
