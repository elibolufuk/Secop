namespace Secop.Core.ApiCommon.Constants.V1
{
    public class QueueNameConstants
    {
        public const string CreditApplicationCreatedEventQueueName = "v1-credit-application-created-queue";
        public const string ScoreCreditCreatedQueueName = "v1-score-credit-created-queue";
        public const string LoanApprovalCreatedEventQueueName = "v1-loan-approval-created-queue";

        public const string ScoreCreditNotCreatedEventQueueName = "v1-score-credit-not-created-queue";
        public const string LoanApprovalNotCreatedEventQueueName = "v1-loan-approval-not-created-queue";
    }
}
