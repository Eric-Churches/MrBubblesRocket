
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Movement : MonoBehaviour
{
    private Rigidbody _rb;// WE PUT rigidbody into a variable
    private AudioSource _audioSource;

    [SerializeField] float mainThrust = 1000f;

    [SerializeField] private float rotationThrust = 100f;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();// the value of the variable
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       ProcessThrust();// the methods
       ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _rb.AddRelativeForce(Vector3.up * (mainThrust * Time.deltaTime));
            if (!_audioSource.isPlaying)
            {
                _audioSource.Play();
            }
           
        }
        else
        {
            _audioSource.Stop();
        }

        

        
    }

    void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationThrust);
        }
    }

    void ApplyRotation(float rotationThisFrame)
    {
        _rb.freezeRotation = true;//freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * (rotationThisFrame * Time.deltaTime));
        _rb.freezeRotation = false;// back to the physics machine
    }
}
