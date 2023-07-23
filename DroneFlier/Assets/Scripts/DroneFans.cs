
public static class DroneFans
{
    public static readonly int FRONT_LEFT_FAN = 1;
    public static readonly int FRONT_RIGHT_FAN = 2;
    public static readonly int BACK_LEFT_FAN = 4;
    public static readonly int BACK_RIGHT_FAN = 8;

    public static int GetForwardValue()
    {
        return BACK_LEFT_FAN | BACK_RIGHT_FAN;
    }

    public static int GetBackwardValue()
    {
        return FRONT_LEFT_FAN | FRONT_RIGHT_FAN;
    }

    public static int GetLeftValue()
    {
        return FRONT_RIGHT_FAN | BACK_RIGHT_FAN;
    }

    public static int GetRightValue()
    {
        return FRONT_LEFT_FAN | BACK_LEFT_FAN;
    }

    public static int GetUpValue()
    {
        return FRONT_LEFT_FAN | FRONT_RIGHT_FAN | BACK_LEFT_FAN | BACK_RIGHT_FAN;
    }
}
