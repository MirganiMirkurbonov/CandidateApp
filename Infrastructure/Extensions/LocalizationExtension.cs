using Domain.Enumerators;

namespace Infrastructure.Extensions;

public static class LocalizationExtension
{
    public static string Localize(this ErrorCodeEnum errorCodeEnum)
    {
        /*
         * To handle localization for error codes, should follow these steps:
         * 1. Create new table  'localisation_data' in db.
         * 2. Fill the 'localisation_data' table with the localized strings for each error code.
         * 3. Implement a caching mechanism to store the localization data in memory for quick access.
         * 4. Retrieve the localized error message from the cache based on the error code.
         *
         * For now, this method simply returns the string representation of the error code.
         */
        return errorCodeEnum.ToString();
    }

}