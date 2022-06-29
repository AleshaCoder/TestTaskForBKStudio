using UnityEngine;
using UnityEngine.UI;

public class FinishChecker : MonoBehaviour, ICameraPursued
{
    private const string Finish = "Finish";
    private const string WinText = "WIN";

    [SerializeField] private Text _winnerText = null;

    public Transform TransformForFollowing => transform;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Finish)
        {
            Debug.Log("Win");
            if (_winnerText != null)
                _winnerText.text = WinText;
        }
    }
}
