using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    public Animator playerAnim;
    float moveSpeed = 10;
    float energyCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
		{
            playerAnim.SetBool("running", true);
            transform.position += transform.forward * Time.deltaTime * moveSpeed;
            transform.rotation = Quaternion.Euler(0, 0, 0);
		}
        if (Input.GetKeyUp(KeyCode.W))
		{
            playerAnim.SetBool("running", false);
		}

        if (Input.GetKey(KeyCode.A))
		{
            playerAnim.SetBool("running", true);
            transform.position += transform.forward * Time.deltaTime * moveSpeed;
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            playerAnim.SetBool("running", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            playerAnim.SetBool("running", true);
            transform.position += transform.forward * Time.deltaTime * moveSpeed;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            playerAnim.SetBool("running", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            playerAnim.SetBool("running", true);
            transform.position += transform.forward * Time.deltaTime * moveSpeed;
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            playerAnim.SetBool("running", false);
        }

        if (GameManager.instance.levelTime <= 0)
		{
            moveSpeed = 0;
		}
        GameManager.instance.energyText.text = "Energy : " + energyCount;
        if (energyCount >= 50)
		{
            SceneManager.LoadScene("WinScene");
		}
        if (GameManager.instance.levelTime <= 0 || energyCount < 0)
		{
            SceneManager.LoadScene("LoseScene");
		}
    }
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "AddEnergy")
		{
            energyCount += 5;
            GameManager.instance.levelTime += 10;
            GameManager.instance.Instantiate4More();
            Destroy(collision.gameObject);
		}
        if (collision.gameObject.tag == "MinusEnergy")
		{
            energyCount -= 25;
            GameManager.instance.levelTime -= 25;
            Destroy(collision.gameObject);
		}
	}
}
