namespace GitApp.Common
{
    public static class ValidationConstants
    {
        public static class Repository
        {
            public const int NameMaxLength = 10;
            public const int NameMinLength = 3;
        }

        public static class Commit
        {
            public const int DescriptionMinLength = 5;
        }
    }
}
