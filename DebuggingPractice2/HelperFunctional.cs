using LaYumba.Functional;

namespace DebuggingPractice
{
    public static class HelperFunctional
    {
        public static Option<T> Lift<T>(this T valueToLift) => valueToLift;
    }
}
