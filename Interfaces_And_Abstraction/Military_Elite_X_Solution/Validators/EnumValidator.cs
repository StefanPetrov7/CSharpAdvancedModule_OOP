using System;
using Military_Elite.Enumerations;
using Military_Elite.Exceptions;

namespace Military_Elite.Validators
{
    static class EnumValidator
    {
        public static Corps ValidateCorps(string strEnum)
        {

            bool isParsed = Enum.TryParse<Corps>(strEnum, out Corps corps);

            if (!isParsed)
            {
                throw new InvalidCorps();
            }

            return corps;
        }

        public static Progress ValidateProgress(string strEnum)
        {

            bool isParsed = Enum.TryParse<Progress>(strEnum, out Progress status);

            if (!isParsed)
            {
                throw new InvalidStatus();
            }

            return status;
        }
    }
}
