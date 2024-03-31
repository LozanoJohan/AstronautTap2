public class Plannet : PushingObject
{
    public override float PullbackMultiplier => 3f;
    void Start()
    {
        // Esto asegura que no la cagamos en el editor como los humanos retrasados que somos.
        gameObject.tag = Tags.PLANNET;
    }
}