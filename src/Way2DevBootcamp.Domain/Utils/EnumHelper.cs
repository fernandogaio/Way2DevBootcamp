using System.ComponentModel;

namespace Way2DevBootcamp.Domain.Utils;
public static class EnumHelper {
    public static string GetDescriptionFromEnumValue(Enum value) {
        var attribute = value.GetType()
            .GetField(value.ToString())
            .GetCustomAttributes(typeof(DescriptionAttribute), false)
            .SingleOrDefault() as DescriptionAttribute;

        return attribute is null ? value.ToString() : attribute.Description;
    }

    public static T GetEnumValueFromDescription<T>(string description) {
        var type = typeof(T);
        if (!type.IsEnum)
            throw new ArgumentException();

        var fields = type.GetFields();
        var field = fields
            .SelectMany(f => f.GetCustomAttributes(typeof(DescriptionAttribute), false),
                                                  (f, a) => new { Field = f, Att = a })
            .Where(a => ((DescriptionAttribute)a.Att).Description == description)
            .SingleOrDefault();

        return field is null ? default(T) : (T)field.Field.GetRawConstantValue();
    }
}