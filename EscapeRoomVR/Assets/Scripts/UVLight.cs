using UnityEngine;


public class UVLight : MonoBehaviour
{
    private GameObject letter;

    [SerializeField] GameObject uvLight;

    private Light uvSpotLight;

    // Start is called before the first frame update
    void Start()
    {
        letter = GameObject.FindGameObjectWithTag("Finish");
        letter.SetActive(false);
        uvSpotLight = uvLight.GetComponent<Light>();
        Debug.Log(uvSpotLight.spotAngle);
    }

    void Update()
    {
        int layerMask = LayerMask.GetMask("Water");
        float radius;
        Vector3 direction;
        RaycastHit[] edgesHit = new RaycastHit[4];
        for (int i = 0; i < 4; i++)
        {
            direction = i < 2 ? Vector3.up : Vector3.right;

            Physics.Raycast(transform.position,
                transform.TransformDirection(Quaternion.AngleAxis(((-1) ^ i) * uvSpotLight.spotAngle / 2, direction) *
                                             Vector3.forward), out edgesHit[i], Mathf.Infinity,
                layerMask);
            Debug.DrawRay(uvLight.transform.position,
                transform.TransformDirection(
                    (Quaternion.AngleAxis((Mathf.Pow((-1), i)) * uvSpotLight.spotAngle / 2, direction) *
                     Vector3.forward)) * 1000, Color.green);
        }

        RaycastHit hit;
        Physics.Raycast(transform.position,
            transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity,
            layerMask);

        radius = hit.distance * Mathf.Tan(uvSpotLight.spotAngle);
        // Debug.Log(radius);
        if (Vector3.Distance(hit.point, letter.transform.position) < 0.6)
        {
            letter.SetActive(true);
        }
        else letter.SetActive(false);
    }
}