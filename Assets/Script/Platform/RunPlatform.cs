using UnityEngine;

public class RunPlatform : MonoBehaviour
{
    [SerializeField] private float motorSpeed = 5f;
    private SliderJoint2D sliderJoint;
    private JointMotor2D setMotor;
    void Start()
    {
        sliderJoint = GetComponent<SliderJoint2D>();
        setMotor = sliderJoint.motor;
    }

    void Update()
    {
        RunJoint();
    }
    private void RunJoint()
    {
        if (sliderJoint.limitState == JointLimitState2D.LowerLimit) { setMotor.motorSpeed = motorSpeed; sliderJoint.motor = setMotor; }
        if (sliderJoint.limitState == JointLimitState2D.UpperLimit) { setMotor.motorSpeed = -motorSpeed; sliderJoint.motor = setMotor; }
    }
}
