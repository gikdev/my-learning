namespace TaskForge.Api.Constants;

public static class ApiEndpoints {
    private const string ApiBase = "api";

    public static class Labels {
        private const string Base = $"{ApiBase}/labels";

        public const string Create = $"{Base}";
        public const string List = $"{Base}";

        public const string Update = $"{Base}/{{id:guid}}";
        public const string Delete = $"{Base}/{{id:guid}}";
        public const string GetById = $"{Base}/{{id:guid}}";
    }
}
