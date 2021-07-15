public class Tween {
    double _original;
    double _distance;
    double _current;
    double _totalTimePassed = 0;
    double _totalDuration = 5;
    bool _finished = false;
    TweenFunction _tweenF = null;
    public delegate double TweenFunction(double timePassed, double start, double distance, double duration);

    public double Value() {
        return _current;
    }

    public bool IsFinished() {
        return _finished;
    }

    public static double Linear(double timePassed, double start, double distance, double duration) {
        // TODO: finish writing this. 
    }
}