using UnityEngine;

[ExecuteInEditMode]
public class WorldCurver : MonoBehaviour
{
    private float curveStrength;
    private float curveStrength2;

    private int m_CurveStrengthID;
    private int m_CurveStrengthID2;

    public float maxStrength = 0.004f;
    public float maxStrength2 = 0.003f;

    public float randomSeed = 0.0f; // Seed for the random offset

    private void OnEnable()
    {
        // Add a random offset to the curve strength values
        curveStrength = Random.Range(0, 1f) * maxStrength + Random.Range(-randomSeed, randomSeed);
        curveStrength2 = Random.Range(-1f, 1f) * maxStrength2 + Random.Range(-randomSeed, randomSeed);

        m_CurveStrengthID = Shader.PropertyToID("_CurveStrength");
        m_CurveStrengthID2 = Shader.PropertyToID("_CurveStrength2");
    }

    void Update()
    {
        Shader.SetGlobalFloat(m_CurveStrengthID, curveStrength);
        Shader.SetGlobalFloat(m_CurveStrengthID2, curveStrength2);
    }
}