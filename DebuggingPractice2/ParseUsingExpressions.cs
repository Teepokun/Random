using System;
using LaYumba.Functional;

namespace DebuggingPractice
{
    public static class ParseUsingExpressions
    {
        private static bool IsEnum(this Type t) => t.IsEnum;

        private static Option<TEnum> TryParse<TEnum>(this string s) where TEnum : struct, IConvertible
            => System.Enum.TryParse(s, out TEnum result) ? F.Some(result) : F.None;

        public static Option<TEnum> Parse<TEnum>(string val) where TEnum : struct, IConvertible
            => typeof(TEnum).Lift()
                .Where(IsEnum) //make sure it is actually an enum cause our where is not so good
                .Map(t => val) // now we have dealt with enum lets actually deal with the string. 
                .Bind(TryParse<TEnum>);
    }
}
