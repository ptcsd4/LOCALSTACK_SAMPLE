namespace ecs_sample
{
    public class EnvironmentVariable
    {
        private static string SQS_ENDPOINT = GetEnvironmentVariable("SQS_ENDPOINT", "http://localstack:4566");
        private static string SQS_NAME = GetEnvironmentVariable("SQS_NAME", "sqs");

        public static string GET_SQS_ENDPOINT() => EnvironmentVariable.SQS_ENDPOINT;

        public static string GET_SQS_NAME() => EnvironmentVariable.SQS_NAME;

        private static string GetEnvironmentVariable(string name, string defaultValue = default(string))
        {
            var variable = Environment.GetEnvironmentVariable(name);

            if (string.IsNullOrEmpty(variable))
            {
                return defaultValue;
            }

            return variable;
        }
    }
}