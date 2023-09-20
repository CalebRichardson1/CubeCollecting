using UnityEngine;

public class PlayerShipInput : MonoBehaviour
{
    private ShipCamera shipCam;
    private ShipMovement shipMove;
    private ShipTractorController tractorController;

    public bool CanUseTrackerBeam {get; private set;}
    public bool CanMove{get; private set;}
    // Start is called before the first frame update
    void Start()
    {
        CanUseTrackerBeam = true;
        CanMove = true;
        shipCam = GetComponent<ShipCamera>();
        shipMove = GetComponent<ShipMovement>();
        tractorController = GetComponent<ShipTractorController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1) && !tractorController.IsTractoring) shipCam.ZoomOut();
        if(Input.GetKeyUp(KeyCode.Mouse1) && !tractorController.IsTractoring) shipCam.DefaultZoom();
        if(CanUseTrackerBeam && Input.GetKeyDown(KeyCode.Space)) tractorController.AttemptTractorBeam();
    }

    // runs every 0.02 seconds
    void FixedUpdate() {
        if(CanMove) shipMove.Move(Input.GetAxis("Vertical"));
        shipMove.Rotate(Input.GetAxis("Horizontal"));
    }

    public void SetTrackerBeam(bool state)
    {
        CanUseTrackerBeam = state;
    }

    public void SetCanMove(bool state)
    {
        CanMove = state;
    }
}
