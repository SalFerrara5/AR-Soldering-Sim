using Oculus.Interaction;
using Oculus.Voice.Windows;
using UnityEngine;

public class SolderComponent : MonoBehaviour
{
    public int AmountOverlapNeeded;
    private int AmountOverlapped = 0;
    public void Increment()
    {
        AmountOverlapped += 1;
        CheckSolderFilled();
    }

    public void Deincrement()
    {
        AmountOverlapped -= 1;
        CheckSolderFilled();
    }
    private Rigidbody rb;
    private void CheckSolderFilled()
    {
        if (AmountOverlapped + 1 >= AmountOverlapNeeded)
        {
            Debug.Log("Change to not grabbable");
            GetComponent<Grabbable>().enabled = false;
            rb = GetComponent<Rigidbody>();

            // Freeze all position axes (X, Y, and Z)
            rb.constraints = RigidbodyConstraints.FreezePosition;
        } 
        else
        {
            Debug.Log("Change to grabbable");
        }
    }
}
