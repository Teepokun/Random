using DebuggingPractice;
using LaYumba.Functional;

namespace DebuggingTest2
{
    public static class EzExtensions
    {
        public static Option<EDayOfWeek> ParseUsingExpressions(this string s)
        {
            return DebuggingPractice.ParseUsingExpressions.Parse<EDayOfWeek>(s);
        }

        public static Option<EDayOfWeek> ParseUsingDelegates(this string s)
        {
            return DebuggingPractice.ParseUsingDelegates.Parse<EDayOfWeek>(s);
        }
    }
}
