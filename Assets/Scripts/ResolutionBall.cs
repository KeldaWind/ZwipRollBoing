using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionBall : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Rigidbody ballBody;
    Vector3 normalPos;

    [Header("Rendering")]
    [SerializeField] Renderer ballRenderer;
    [SerializeField] Material prepaMat;
    [SerializeField] Material resolMat;

    public void SetUpBall()
    {
        normalPos = transform.position;
    }

    public void ResetBall()
    {
        transform.position = normalPos;
        transform.rotation = Quaternion.identity;
        ballBody.useGravity = false;
        ballBody.velocity = Vector3.zero;
        ballBody.angularVelocity = Vector3.zero;
        ballRenderer.material = prepaMat;
    }

    public void ActivateResolutionBall()
    {
        ballBody.useGravity = true;
        ballRenderer.material = resolMat;
    }

    #region Functions
    [Header("Functions : Zwip")]
    [SerializeField] float zwipMultiplier;

    public void Zwip(Collision collision)
    {
        Vector3 norm = new Vector3();

        foreach (ContactPoint contact in collision.contacts)
        {
            norm += contact.normal;
        }

        norm.Normalize();

        Vector3 dir = new Vector3(0, norm.z, -norm.y);

        if (dir.y < 0)
            dir = -dir;

        if (dir.y < 0.01f)
        {
            if (dir.z > 0)
            {
                dir = -dir;
            }
        }

        ballBody.AddForce(dir * zwipMultiplier);
    }

    public void Roll(Collision collision)
    {
        //Debug.Log("Roll");
    }

    [Header("Function : Boing")]
    [SerializeField] float boingMultiplier;

    public void Boing(Collision collision)
    {
        Vector3 dir = new Vector3();

        foreach(ContactPoint contact in collision.contacts)
        {
            dir += contact.normal;
        }

        dir.Normalize();

        ballBody.AddForce(dir * boingMultiplier);
    }
    #endregion

    public void OnCollisionEnter(Collision collision)
    {
        LevelObjectResolutionHitbox resolHitbox = collision.gameObject.GetComponent<LevelObjectResolutionHitbox>();
        if (resolHitbox != null)
        {
            switch (resolHitbox.GetObjectFunction())
            {
                case (LevelObjectFunction.Boing):
                    Boing(collision);
                    break;
            }
        }
    }

    public void OnCollisionStay(Collision collision)
    {
        LevelObjectResolutionHitbox resolHitbox = collision.gameObject.GetComponent<LevelObjectResolutionHitbox>();
        if (resolHitbox != null)
        {
            switch (resolHitbox.GetObjectFunction())
            {
                case (LevelObjectFunction.Zwip):
                    Zwip(collision);
                    break;

                case (LevelObjectFunction.Roll):
                    Roll(collision);
                    break;

            }
        }
    }
}
