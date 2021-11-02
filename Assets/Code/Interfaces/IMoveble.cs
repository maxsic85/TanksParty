

namespace Tanks.Code
{
    public interface IMoveble
    {
        void Move();
    }

    public interface IShootable
    {
        int SetDamage();
    }

}

public interface IStepble
{
    bool EndStep();
}
