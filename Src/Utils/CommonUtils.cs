namespace AsaBloggerApi.Src.Utils
{
    public class CommonUtils
    {
        public static bool AllStringPropertyValuesAreNonEmpty(object myObject)
        {
            if (myObject == null)
            { return false; }
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            var allStringPropertyValues =
                from property in myObject.GetType().GetProperties()
                where property.PropertyType == typeof(string) && property.CanRead
                select (string)property.GetValue(myObject);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            return allStringPropertyValues.All(value => !string.IsNullOrEmpty(value));
        }
    }
}