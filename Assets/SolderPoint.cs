using UnityEngine;

public class SolderPoint : MonoBehaviour
{
    public SolderComponent SolderComponent;

    private Material render;

    void Start()
    {
        render = GetComponent<Renderer>().material;

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Solder")
        {
            render.color = Color.red;
            SolderComponent.Increment();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Solder")
        {
            render.color = Color.blue;
            SolderComponent.Deincrement();
        }

    }

}
