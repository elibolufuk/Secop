namespace Secop.Core.ApiCommon.Constants
{
    public class QueueNameConstants
    {
        public const string CreditApplicationCreatedEventQueueName = "credit-application-created-queue";
        public const string ScoreCreditCreatedQueueName = "score-credit-created-queue";
        public const string LoanApprovalCreatedEventQueueName = "loan-approval-created-queue";

        public const string ScoreCreditNotCreatedEventQueueName = "score-credit-not-created-queue";
        public const string LoanApprovalNotCreatedEventQueueName = "loan-approval-not-created-queue";
    }
}
