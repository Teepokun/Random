using System;
using LaYumba.Functional;
using static LaYumba.Functional.F;
using Enum = System.Enum;
namespace DebuggingPractice
{
    public static class ParseUsingDelegates
    {
        public static Option<TEnum> Parse<TEnum>(string val) where TEnum : struct, IConvertible
            => typeof(TEnum).Lift()
                .Where(IsEnum) //make sure it is actually an enum cause our where is not so good
                .Map(t => val) // now we have dealt with enum lets actually deal with the string. 
                .Bind(TryParse<TEnum>);

        // Functions require seperate line
        private static readonly Func<Type, bool> IsEnum = (t) 
            => t.IsEnum;

        // Methods can use same line
        private static Option<TEnum> TryParse<TEnum>(this string s) where TEnum : struct, IConvertible
            => Enum.TryParse(s, out TEnum result) ? Some(result) : None;


        // Could be 'cleaned up' but this is to show all the ceremony involved
        public static TEnum ParseImperative<TEnum>(string val) where TEnum : struct, IConvertible
        {
            if (!typeof(TEnum).IsEnum)
            {
                throw new Exception("TEnum must be an enum!!!");
            }

            if (string.IsNullOrEmpty(val))
            {
                throw new ArgumentException($"string {nameof(val)} must not be null or empty");
            }

            if (!System.Enum.TryParse(val, out TEnum result))
            {
                throw new Exception("value could not be converted");
            }

            return result;
        }
    }
}
