using System.Collections;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField]
    private GameObject _respawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            var player = other.GetComponent<Player>();
            player?.Damage();

            var characterController = other.GetComponent<CharacterController>();

            characterController.enabled = false;

            other.transform.position = _respawnPoint.transform.position;

            StartCoroutine(CharacterControllerEnableRoutine(characterController));
        }
    }

    IEnumerator CharacterControllerEnableRoutine(CharacterController controller)
    {
        yield return new WaitForSeconds(1f);
        controller.enabled = true;
    }
}
