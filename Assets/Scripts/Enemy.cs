using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public Animator anim;
    public float delay = 0f;
    public AudioSource AudioSource;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.Play();
        if (tag == "Enemy")
        {
            if (collision.gameObject.tag == "Shuriken")
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
            else if (collision.gameObject.tag == "Slash")
            {
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.tag == "Player")
            {
                Destroy(collision.gameObject);
                SceneManager.LoadScene(2);
            }
        }
        if (tag == "Dummy")
        {
            if (collision.gameObject.tag == "Shuriken")
            {
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.tag == "Slash")
            {
                Destroy(collision.gameObject);
                anim.SetBool("isDead", true);
                Destroy(gameObject, anim.GetCurrentAnimatorStateInfo(0).length + delay);
            }
            else if (collision.gameObject.tag == "Player")
            {
                Destroy(collision.gameObject);
                SceneManager.LoadScene(2);
            }
        }
    }
}
