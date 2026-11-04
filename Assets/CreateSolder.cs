using UnityEngine;

public class CreateSolder : MonoBehaviour
{
    public GameObject solder;

    public Material render;

    bool soldering = false;
    float time = 0;
    public float time_solder_steps = 0.75F;

    private void OnTriggerEnter(Collider other)
    {

     if (other.gameObject.tag == "Iron")
        {
            soldering = true;
            Debug.Log(other.gameObject.tag);
            render.color = Color.red;
            CreateObject();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Iron")
        {
            soldering = false;
            Debug.Log(other.gameObject.tag);
            render.color = Color.blue;
        }
            
    }

    private void CreateObject()
    {
        Instantiate(solder, transform.position, Quaternion.identity);
    }

    private void Update()
    {
        if (soldering)
        {
            time += Time.deltaTime;
            if (time > time_solder_steps)
            {
                CreateObject();
                time = 0F;
            }
        }
    }
}
