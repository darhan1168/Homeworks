namespace Homework4;

public static class LibraryForMapping
{
    public static void MapTo<TSource, TDestination>(this TSource source, TDestination destination)
    {
        var sourceProperties = typeof(TSource).GetProperties();
        var destinationProperties = typeof(TDestination).GetProperties();

        foreach (var sourceProperty in sourceProperties)
        {
            var destinationProperty = destinationProperties.FirstOrDefault(x => x.Name == sourceProperty.Name);
            if (destinationProperty != null)
            {
                destinationProperty.SetValue(destination, sourceProperty.GetValue(source));
            }
        }
    }

    public static void MapToSpecificProperties<TSource, TDestination>(this TSource source, TDestination destination,
        string[] sourceProperties, string[] destinationProperties)
    {
        foreach (var sourceProperty in sourceProperties)
        {
            var sourceProp = typeof(TSource).GetProperty(sourceProperty);
            if (sourceProp == null)
            {
                continue;
            }

            var destinationProperty = destinationProperties.FirstOrDefault(x => x == sourceProperty);
            if (destinationProperty != null)
            {
                var destinationProp = typeof(TDestination).GetProperty(destinationProperty);
                if (destinationProp != null)
                {
                    destinationProp.SetValue(destination, sourceProp.GetValue(source));
                }
            }
        }
    }
}