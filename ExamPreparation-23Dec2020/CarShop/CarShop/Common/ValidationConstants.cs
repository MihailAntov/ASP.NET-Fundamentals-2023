namespace CarShop.Common
{
    public static class ValidationConstants
    {
        public static class Car
        {
            public const int ModelMinLength = 5;
            public const int ModelMaxLength = 20;
            public const string PlateRegex = @"^[A-Z]{2}[\d]{4}[A-Z]{2}$";
        }

        public static class Issue
        {
            public const int DescriptionMinLength = 5;
        }
    }
}
