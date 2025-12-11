namespace Api;

public static class ApiEndpoints {
    private const string ApiBase = "api";

    public static class Categories {
        private const string Base = $"{ApiBase}/categories";

        public const string Create = $"{Base}";
        public const string List = $"{Base}";

        public const string Delete = $"{Base}/{{id:guid}}";
        public const string GetById = $"{Base}/{{id:guid}}";

        public const string Rename = $"{Base}/{{id:guid}}/title";

        public const string AddTodo = $"{Base}/{{categoryId:guid}}/todos/{{todoId:guid}}";
        public const string RemoveTodo = $"{Base}/{{categoryId:guid}}/todos/{{todoId:guid}}";
    }

    public static class Todos {
        private const string Base = $"{ApiBase}/todos";

        public const string Create = $"{Base}";
        public const string List = $"{Base}";

        public const string Update = $"{Base}/{{id:guid}}";
        public const string Delete = $"{Base}/{{id:guid}}";
        public const string GetById = $"{Base}/{{id:guid}}";
    }
}
