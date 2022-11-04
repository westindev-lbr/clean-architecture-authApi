using alabarre.Application.Intefaces.Utiles;

namespace alabarre.Infrastructure.Utiles;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
