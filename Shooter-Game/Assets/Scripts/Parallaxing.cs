using UnityEngine;
using System.Collections;


public class Parallaxing : MonoBehaviour
{

    private float[] objectScales;      // how fast move foreground and background sprites according to distance
    public float transition = 1f;   //how fast transition will be
    public Transform[] objects;     //Array of foreground and background objects to parallax

    private new Transform camera;       //main camera from game
    private Vector3 startCameraPosition; //variable to store camera position which will be needed to calculate parallax


    void Awake()
    {
        camera = Camera.main.transform;     //reference to camera in main scene
    }

    // Start is called before the first frame update
    void Start()
    {
        objectScales = new float[objects.Length];

        startCameraPosition = camera.position;

        for(int i = 0; i < objects.Length; i++)
        {
            objectScales[i] = objects[i].position.z * (-1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float parallax, objectPosition;
        Vector3 newObjectPosition;
        for(int i = 0; i < objects.Length; i++)
        {
            parallax = (startCameraPosition.x - camera.position.x) * objectScales[i];

            objectPosition = objects[i].position.x + parallax;

            newObjectPosition = new Vector3(objectPosition, objects[i].position.y, objects[i].position.z);

            objects[i].position = Vector3.Lerp(objects[i].position, newObjectPosition, Time.deltaTime * transition);
        }

        startCameraPosition = camera.position;
    }
}
